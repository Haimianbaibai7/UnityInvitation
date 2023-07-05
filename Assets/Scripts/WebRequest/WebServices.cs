using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WebServices
{

    private static WebServices instance;

    public static WebServices Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WebServices();
            }
            return instance;
        }
    }

    private string portHost = "http://127.0.0.1:33333/";

    private readonly HttpListener controller = new HttpListener();

    private HttpListener listener = new HttpListener();

    public void InitServiceAndStart()
    {
        try
        {
            Debug.Log("start ResourceStore Heartbeat Thread !");
            // Add proxy and host port   
            controller.Prefixes.Add(portHost);

            // Start HTTP listen and start get content from client
            controller.Start();
            controller.BeginGetContext(ContextPhrase, controller);
        }
        catch (Exception e)
        {
            Debug.Log("start ResourceStore Heartbeat Thread !!" + e.Message);
        }
    }

    private void ContextPhrase(IAsyncResult ar)
    {
        Debug.Log("ContextPhrase");
        try
        {
            // Get listener from controller
            listener = ar.AsyncState as HttpListener;

            // Check listener is null or duplicate initialize
            if (listener == null || !listener.IsListening) return;

            // Let listener start get content from client  
            HttpListenerContext context = listener.EndGetContext(ar);
            listener.BeginGetContext(ContextPhrase, listener);

            // Phrase content to different type data
            HttpListenerRequest request = context.Request;
            HttpStatusCode returnCode = HttpStatusCode.BadRequest;
            string returnMsg = "";

            switch (request.HttpMethod)
            {
                case "POST":
                    string headers = request.Headers.Get("Content-Type");
                    Debug.Log("Get-Code:" + headers);
                    if (headers == "application/json")
                    {
                        System.IO.Stream body = request.InputStream;
                        System.Text.Encoding encoding = request.ContentEncoding;
                        System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                        string jsonString = reader.ReadToEnd();
                        //TODO:
                        InformationData informationData = JsonUtility.FromJson<InformationData>(jsonString);
                        Debug.Log($"WebService--------- {informationData.Name} : {informationData.PhoneNember} : {informationData.CompanyOrSchool} : {informationData.Phase}");
                        CreateExcel(informationData);

                    }
                    break;
            }
            ResponseRequest(context, returnCode, returnMsg);
        }
        catch (Exception e)
        {
            Debug.Log("ContextPhrase:" + e.Message);
        }
    }

    private void ResponseRequest(HttpListenerContext context, HttpStatusCode resCode, string resDes)
    {
        HttpListenerResponse response = context.Response;
        response.StatusCode = (int)resCode;
        response.ContentType = "application/json;charset=UTF-8";
        response.ContentEncoding = new UTF8Encoding(false);

        response.Close();
    }

    void CreateExcel(InformationData informationData)
    {
        string outPutDir = "C:\\UnityWork\\WebServices\\Assets\\" + "AnniversarySignInForm.json";
        FileInfo newFile = new FileInfo(outPutDir);

        InformationDataList informationDataList = new InformationDataList();

        if (newFile.Exists)
        {
            using (FileStream fs = File.Open(outPutDir,FileMode.Open,FileAccess.Read,FileShare.None)) 
            {
                byte[] bs = new byte[fs.Length];
                fs.Read(bs,0,bs.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(bs);
                Debug.Log("newFile.Exists" + jsonString);
                informationDataList = JsonUtility.FromJson<InformationDataList>(jsonString);
               
            }
            newFile.Delete();
        }
        else
        {
            informationDataList.DataList = new List<InformationData>();
        }
      
        informationDataList.DataList.Add(informationData);

        using (FileStream fs =new FileStream(outPutDir, FileMode.Create))
        {
            string jsonString = JsonUtility.ToJson(informationDataList);

            byte[] bs = Encoding.UTF8.GetBytes(jsonString);
            fs.Write(bs, 0, bs.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
    }
}


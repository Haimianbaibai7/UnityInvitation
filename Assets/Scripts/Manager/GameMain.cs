using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;

public class GameMain : MonoBehaviour
{
    public static GameMain Instance;
    public GameObject InformationPanel;
    public GameObject TicketPanel;
    public BlurMask BlurMask;
    public AudioManager AudioManager;
    public ItemFactory ItemFactory;
    public PlayableDirector Director;
    private InformationPanel m_InformationPanel;
    private TicketPanel m_TicketPanel;
    public string WebRequestUrl = "http://124.222.18.199:80/";

    private InformationData m_infomationData;

    private void Awake()
    {
        Instance = this;
        m_InformationPanel = InformationPanel.GetComponent<InformationPanel>();
        m_TicketPanel = TicketPanel.GetComponent<TicketPanel>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlayBackGroundMusic();
        CreateItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInformationPanel()
    {
        m_InformationPanel.Show();
    }

    public void DelayShowInformationPanel()
    {
            
        StartCoroutine(Wait());
        

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(2.5f);

            ShowInformationPanel();
            GameMain.Instance.AudioManager.PlayEffectMusic(GameMain.Instance.AudioManager.PaperSilde);

        }
    }



    public void CloseInformationPanel()
    {
        m_InformationPanel.Close();
    }

    public void ShowTicketPanel()
    {
        m_TicketPanel.Name.text = m_infomationData.Name;
        m_TicketPanel.Show();
    }

    public void CloseTicketPanel()
    {
        m_InformationPanel.Close();
    }



    public void DelayShowTicketPanel()
    {
        StartCoroutine(Wait());
        

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);

            ShowTicketPanel();
            GameMain.Instance.AudioManager.PlayEffectMusic(GameMain.Instance.AudioManager.FinalPaper);

        }
    }



    public void Blur()
    {
        BlurMask.Blur();
    }

    public void Sharp()
    {
        BlurMask.Sharp();
    }


    public void RegisterUserInfo(InformationData infomationData)
    {
        m_infomationData = infomationData;
        //TODO:上传服务端 不用等待回调

        //StartCoroutine(CallWebRequest());
        CreateExcel();

        //生成专属票根

        CloseInformationPanel();
        DelayShowTicketPanel();

    }

    private IEnumerator CallWebRequest()
    {
        string sendString = JsonUtility.ToJson(m_infomationData);
        Debug.Log("data:" + sendString);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendString);

        //WWWForm form = new WWWForm();
        //form.AddField("Content-Type","application/json");
        //form.AddBinaryData("file", bytes);
        UnityWebRequest webRequest = new (WebRequestUrl, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bytes);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("success!");
        }
        else
        {
            Debug.LogError("web error!");
        }
        webRequest.Dispose();
    }

    private void CreateItems()
    {
        StartCoroutine(enumerator());
        IEnumerator enumerator()
        {
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateLetter();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
            yield return new WaitForSeconds(1f);
            ItemFactory.CreateUnityBoy();
        }

    }

    void CreateExcel()
    {
        string sendString = JsonUtility.ToJson(m_infomationData);
        //string outPutDir = "/www/wwwroot/studentdata/" + "UniversarySignInForm.txt";
        string outPutDir = Application.streamingAssetsPath+ "/UniversarySignInForm.txt";
        Debug.Log(outPutDir);
        FileInfo newFile = new FileInfo(outPutDir);

        string jsonString = "";

        if (newFile.Exists)
        {
            using (FileStream fs = File.Open(outPutDir, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] bs = new byte[fs.Length];
                fs.Read(bs, 0, bs.Length);
                jsonString = System.Text.Encoding.UTF8.GetString(bs);

            }
            newFile.Delete();
        }

        using (FileStream fs = new FileStream(outPutDir, FileMode.Create))
        {
            jsonString = jsonString + "\r\n" + sendString;
            //Console.WriteLine("CreateExcel:" + outPutDir);
            byte[] bs = Encoding.UTF8.GetBytes(jsonString);
            fs.Write(bs, 0, bs.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
    }

}

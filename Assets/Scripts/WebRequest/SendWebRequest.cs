using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendWebRequest : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        WebServices.Instance.InitServiceAndStart();
 
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(CallWebRequest());
        //}
    }



    private InformationData CreateTestData() 
    {
        InformationData informationData = new InformationData();
        informationData.Name = "�����"+i;
        informationData.PhoneNember = "13940681721" + i;
        informationData.CompanyOrSchool = "Unity�й�" + i;
        informationData.Phase = "Unity��ѧʮ����" + i;
        i++;
        return informationData;
    }
}

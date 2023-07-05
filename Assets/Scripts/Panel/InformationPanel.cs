using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationPanel : PanelBase
{
    public TMP_InputField Name;
    public TMP_InputField Phone;
    public TMP_InputField School;
    public TMP_InputField Num;
    public Button Comfirm;
    public InformationData infomationData =new InformationData();

    // Start is called before the first frame update
    void Start()
    {
        Comfirm.onClick.AddListener(RegisterUserInfo);
    }

    public void RegisterUserInfo()
    {
        if(string.IsNullOrEmpty(Name.text)|| string.IsNullOrEmpty(Phone.text)|| string.IsNullOrEmpty(School.text)|| string.IsNullOrEmpty(Num.text))
        {
            return;
        }

        infomationData.Name = Name.text;
        infomationData.PhoneNumber = Phone.text;
        infomationData.CompanyOrSchool = School.text;
        infomationData.Phase = Num.text;

        GameMain.Instance.RegisterUserInfo(infomationData);
    }
}

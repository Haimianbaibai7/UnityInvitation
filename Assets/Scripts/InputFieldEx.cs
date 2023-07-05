using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using System;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldEx : MonoBehaviour, ISelectHandler
{

    [DllImport("__Internal")]
    private static extern string ShowKeyboard(string str);

    string str;

    private TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void Update()
    {
        if (str != null && str != "" && !string.IsNullOrEmpty(str))
        {
            inputField.text = str;
        }
    }

    public void OnSelect(BaseEventData data)
    {

#if UNITY_EDITOR
        return;
#endif
        str = ShowKeyboard(inputField.text);
    }


}

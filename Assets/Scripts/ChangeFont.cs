using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    public TMP_FontAsset font;


    [ContextMenu("ChangeFont")]
    public void ChangeFontFun()
    {
        TMP_Text[] Texts = GameObject.FindObjectsOfType<TMP_Text>();
        foreach(var t in Texts)
        {
            t.font = font;
        }

        TMP_InputField[] inputFields=FindObjectsOfType<TMP_InputField>();
        foreach(var i in inputFields)
        {
            i.fontAsset = font;
            
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    private bool isOn=false;
    private RectTransform m_rectTransform;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            m_rectTransform.anchoredPosition = Vector2.Lerp(m_rectTransform.anchoredPosition, Vector2.zero, 0.05f);
            
        }
        else
        {
            m_rectTransform.anchoredPosition = Vector2.Lerp(m_rectTransform.anchoredPosition, new Vector2(0,1344), 0.05f);
            
        }
    }

    public void Show()
    {
        isOn = true;
    }

    public void Close()
    {
        isOn = false; 
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class BlurMask : MonoBehaviour
{
    private Image m_Image;
    private Material m_Material;

    private bool isBlur = false;
    public float lerpFloat = 0.2f;

    private Color m_Color=Color.white;
    private float m_Size=0;

    public Color TargetColor = new Color(0.8f, 0.8f, 0.8f);
    public float TargetSize = 1;



    private void Awake()
    {
        m_Image = GetComponent<Image>();
        m_Material = m_Image.material;

        
    }

    private void Start()
    {
        //Blur();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlur)
        {
            m_Color = Color.Lerp(m_Color, TargetColor, lerpFloat);
            m_Size= Mathf.Lerp(m_Size, TargetSize, lerpFloat);
        }
        else
        {
            m_Color = Color.Lerp(m_Color, Color.white, lerpFloat);
            m_Size = Mathf.Lerp(m_Size, 0f, lerpFloat);
        }

        m_Material.SetColor("_Color", m_Color);
        m_Material.SetFloat("_Size", m_Size);

    }

    [ContextMenu("Blur")]
    public void Blur()
    {
        isBlur = true;
    }

    [ContextMenu("Sharp")]
    public void Sharp()
    {
        isBlur = false;
    }

    private void OnDestroy()
    {
        m_Material.SetColor("_Color", new Color(1, 1, 1));
        m_Material.SetFloat("_Size", 0f);
    }
}

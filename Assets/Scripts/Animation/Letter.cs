using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;


public class Letter : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    public GameObject ClickEffect;

    public Sprite letter;
    public Sprite letter_OnClick;

    private SpriteRenderer m_spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickEffect.SetActive(true);
        GameMain.Instance.AudioManager.PlayEffectMusic(GameMain.Instance.AudioManager.ClickMail);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_spriteRenderer.sprite = letter_OnClick;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_spriteRenderer.sprite = letter;
    }

    public void ClickEffectDone()
    {
        ClickEffect.SetActive(false);
        //播放timeline
        GameMain.Instance.Director.Play();
        GameMain.Instance.AudioManager.PlayEffectMusic(GameMain.Instance.AudioManager.OpenMail);
        GameMain.Instance.Blur();
        //this.gameObject.SetActive(false);
    }


}

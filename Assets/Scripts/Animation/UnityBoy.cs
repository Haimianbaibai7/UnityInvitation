using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UnityBoy : MonoBehaviour, IPointerClickHandler
{
    int count = 0;

    private void Start()
    {
        count = Random.Range(1, transform.childCount);
        transform.GetChild(count).gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameMain.Instance.AudioManager.PlayEffectMusic(GameMain.Instance.AudioManager.ClickBoy);
        Vector3 position = transform.GetChild(count).position;
        transform.GetChild(count).gameObject.SetActive(false);
        count++;
        if (count >= transform.childCount)
        {
            count = 0;
        }
        transform.GetChild(count).gameObject.SetActive(true);
        transform.GetChild(count).position = position;

    }
}

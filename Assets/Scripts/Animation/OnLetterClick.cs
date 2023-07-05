using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLetterClick : MonoBehaviour
{
    public void Disable()
    {
        SendMessageUpwards("ClickEffectDone");
    }
}

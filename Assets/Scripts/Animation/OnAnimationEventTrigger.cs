using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEventTrigger : MonoBehaviour
{
    public string massage;
    public void OnEventTrigger()
    {
        SendMessageUpwards(massage);
    }
}

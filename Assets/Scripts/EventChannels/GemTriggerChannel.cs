using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Gem Trigger Channel")]
public class GemTriggerChannel : ScriptableObject
{
    [HideInInspector]
    public UnityEvent gemTriggerEvent;

    public void RaiseEvent()
    {
        if (gemTriggerEvent != null)
        {
            gemTriggerEvent.Invoke();
        }
    }
}

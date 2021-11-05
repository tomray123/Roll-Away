using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Fall Trigger Channel")]
public class FallTriggerChannel : ScriptableObject
{
    [HideInInspector]
    public UnityEvent fallTriggerEvent;

    public void RaiseEvent()
    {
        if (fallTriggerEvent != null)
        {
            fallTriggerEvent.Invoke();
        }
    }
}

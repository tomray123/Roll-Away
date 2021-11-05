using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Fall Trigger Channel")]
public class FallTriggerChannel : ScriptableObject
{
    // This event is called when player falls from track.
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

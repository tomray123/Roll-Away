using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Gem Trigger Channel")]
public class GemTriggerChannel : ScriptableObject
{
    [HideInInspector]
    public UnityAction<GameObject> gemTriggerEvent;

    public void RaiseEvent(GameObject sender)
    {
        if (gemTriggerEvent != null)
        {
            gemTriggerEvent.Invoke(sender);
        }
    }
}

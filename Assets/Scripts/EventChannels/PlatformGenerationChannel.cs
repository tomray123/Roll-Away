using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Platform Generation Channel")]
public class PlatformGenerationChannel : ScriptableObject
{
    // This event is called when part of track had been generated.
    [HideInInspector]
    public UnityEvent platformGenerationEvent;

    public void RaiseEvent()
    {
        if (platformGenerationEvent != null)
        {
            platformGenerationEvent.Invoke();
        }
    }
}

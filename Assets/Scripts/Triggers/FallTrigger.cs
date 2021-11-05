using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raise event if player fell down from track.
public class FallTrigger : MonoBehaviour
{
    [Header("Fall Trigger Event Channel")]
    [SerializeField]
    private FallTriggerChannel gtChannel;

    private void OnTriggerEnter(Collider other)
    {
        gtChannel.RaiseEvent();
    }
}

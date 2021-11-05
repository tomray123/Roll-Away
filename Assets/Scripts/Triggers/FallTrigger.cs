using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    // Event channel for gems triggers.
    [SerializeField]
    private FallTriggerChannel gtChannel;

    private void OnTriggerEnter(Collider other)
    {
        gtChannel.RaiseEvent();
    }
}

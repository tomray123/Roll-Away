using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTrigger : MonoBehaviour
{
    // Event channel for gems triggers.
    [SerializeField]
    private GemTriggerChannel gtChannel;

    private void OnTriggerEnter(Collider other)
    {
        gtChannel.RaiseEvent(gameObject);
    }
}

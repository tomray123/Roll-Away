using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raise event if player collected a gem.
public class GemTrigger : MonoBehaviour
{
    [Header("Gem Trigger Event Channel")]
    [SerializeField]
    private GemTriggerChannel gtChannel;

    private void OnTriggerEnter(Collider other)
    {
        gtChannel.RaiseEvent();
        // Returning gem to pool.
        PoolController.Instance.ReturnToPool(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Return to pool tile if tile entered platform destroyer.
public class PlatformDestroyer : MonoBehaviour
{
    [Header("Platform Generator Scriptable Object")]
    [SerializeField]
    private PlatformGeneratorData pgData;

    private void OnTriggerEnter(Collider other)
    {
        // Returning tile back to pool.
        PoolController.Instance.ReturnToPool(other.gameObject);
        // Trowing tile out from queue.
        pgData.tileStorage.Dequeue();
    }
}

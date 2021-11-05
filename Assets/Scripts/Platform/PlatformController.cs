using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : PooledObject, IPooledObject
{
    // Initial platform scale.
    Vector3 initialScale;

    // Start is called before the first frame update
    void Awake()
    {
        initialScale = transform.localScale;
    }

    // Called when object spawns.
    public void OnObjectSpawn()
    {

    }

    // Called when object returns to pool.
    public void OnObjectDestroy()
    {
        // Detaching from old parent.
        transform.parent = null;

        // Getting gem from tile.
        Transform gem;
        if (transform.childCount > 0)
        {
            gem = transform.GetChild(0);

            // Returning gem to pool.
            PoolController.Instance.ReturnToPool(gem.gameObject);
        }

        // Detaching all gems.
        transform.DetachChildren();
        
        // Setting normal size.
        transform.localScale = initialScale;
    }
}

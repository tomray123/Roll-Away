using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject: MonoBehaviour
{
    // Auxiliary Variables.
    [HideInInspector]
    public string poolTag;
    [HideInInspector]
    public int objIdPool;
}

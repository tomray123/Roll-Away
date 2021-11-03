using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platform Move Data")]
public class PlatformMoveData : ScriptableObject
{
    public float speed;

    // Defines the direction of movement of the platform.
    [HideInInspector]
    public bool moveDirectionLeft;

    public void InitializeData()
    {
        // Direction is left initially.
        moveDirectionLeft = true;
    }
}

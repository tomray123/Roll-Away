using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GemGenerationType
{
    Randomly,
    Consistently
}

[CreateAssetMenu(menuName = "Gem Generator Data")]
public class GemGeneratorData : ScriptableObject
{
    [Header("Gem Generation Settings")]
    public GameObject gemPrefab;
    // Defines how gems are generated.
    public GemGenerationType generationType = GemGenerationType.Randomly;

    // Defines the gem position when consistently generation type is used.
    [HideInInspector]
    public int gemPosition;

    public void InitializeData()
    {
        // Starting from first tile.
        gemPosition = 1;
    }
}

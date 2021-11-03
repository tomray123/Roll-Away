﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelDifficulty
{
    high,
    medium,
    low
}

[CreateAssetMenu(menuName = "Platform Generator Data")]
public class PlatformGeneratorData : ScriptableObject
{
    [Header("Track settings")]
    public GameObject tilePrefab;
    // Defines track thickness (low - 3 tiles, medium - 2 tiles, high - 1 tile).
    public LevelDifficulty levelDifficulty = LevelDifficulty.high;
    // Defines the length of track's generated part.
    public int trackLength = 30;
    // Defines the maximal possible length of track's straight part.
    public int trackLineLength = 7;

    // Other auxiliary variables.
    // Defines the track width in tiles.
    [HideInInspector]
    public int trackWidth;
    // Defines the maximal possible length of track's straight part.
    [HideInInspector]
    public Vector3 lastTilePosition;
    // Size of one side of a tile.
    [HideInInspector]
    public float tileSize;
    // Corrective shift along the local x-axis during platform rotation.
    [HideInInspector]
    public float xShift;
    // Corrective shift along the local z-axis during platform rotation.
    [HideInInspector]
    public float zShift;

    public void InitializeData()
    {
        trackWidth = (int)levelDifficulty + 1;

        // Assuming that the top plane of the tile is always square.
        tileSize = tilePrefab.transform.localScale.x;
        
        // Calculating corrective shifts.
        xShift = tileSize * (trackWidth + 1) / 2;
        zShift = tileSize * (trackWidth - 1) / 2;

        // Initial position will be different for every track width.
        lastTilePosition = new Vector3(tileSize - zShift, - (tilePrefab.transform.localScale.y / 2), tileSize);
    }
}
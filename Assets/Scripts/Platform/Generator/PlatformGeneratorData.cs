using System.Collections;
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
    public int trackLineLength = 5;

    [Header("The distance after which to generate a new part of the track")]
    public float spawnEndDistance;

    // Other auxiliary variables.
    // Defines the track width in tiles.
    [HideInInspector]
    public int trackWidth;
    // Defines the last generated tile position.
    [HideInInspector]
    public Vector3 lastTilePosition;
    // Defines initial position for track.
    [HideInInspector]
    public Vector3 initialTilePosition;
    // Size of one side of tile prefab.
    [HideInInspector]
    public float originalTileSize;
    // Size of one side of a new tile.
    [HideInInspector]
    public float tileSize;
    // Corrective shift along the local z-axis during platform rotation.
    [HideInInspector]
    public float xShift;
    // Storage for track part and gem generation.
    [HideInInspector]
    public List<GameObject> generatedTrackPart;
    // Storage for every tile on level.
    [HideInInspector]
    public Queue<GameObject> tileStorage;
    // Initial track orientation to start from.
    [HideInInspector]
    public bool isLeft = true;
    // New scale for tiles (if track width is more than 1 in tiles).
    [HideInInspector]
    public Vector3 newTileScale;

    public void InitializeData()
    {
        // Initializing tiles storages.
        generatedTrackPart = new List<GameObject>();
        tileStorage = new Queue<GameObject>();

        trackWidth = (int)levelDifficulty + 1;

        // The length must be divisible by 5 in order to generate crystals.
        trackLength -= trackLength % 5;

        // Assume that track always go left at the start of the game.
        isLeft = true;

        // Assuming that the top plane of the tile is always square.
        originalTileSize = tilePrefab.transform.localScale.x;
        tileSize = originalTileSize * trackWidth;
        newTileScale = new Vector3(tileSize, originalTileSize, tileSize);

        // Calculating corrective shifts.
        xShift = originalTileSize * (trackWidth - 1) / 2;

        // Initial position will be different for every track width.
        initialTilePosition = new Vector3(originalTileSize, -(tilePrefab.transform.localScale.y / 2), originalTileSize);
        lastTilePosition = initialTilePosition - new Vector3(xShift, 0, xShift);
    }
}

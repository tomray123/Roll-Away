using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorController: MonoBehaviour
{
    [HideInInspector]
    public PlatformGeneratorData pgData;

    // Generates start platform (3x3)
    public void GenerateStartPlatform()
    {
        // Setting initial position.
        Vector3 initPosition = new Vector3(0, -(pgData.originalTileSize / 2), 0);
        Vector3 platformScale = new Vector3(pgData.originalTileSize * 3, pgData.originalTileSize, pgData.originalTileSize * 3);

        // Generating start platform (3x3).

        /*
        for (int i = 0; i < 3; i++)
        {
            nextPosition = initPosition;
            nextPosition += new Vector3(-pgData.originalTileSize * i, 0, 0);
            for (int j = 0; j < 3; j++)
            {
                GameObject tile = PoolController.Instance.SpawnFromPool(pgData.tilePrefab, nextPosition, Quaternion.identity);
                tile.transform.parent = transform;
                pgData.tileStorage.Enqueue(tile);
                nextPosition += new Vector3(0, 0, -pgData.originalTileSize);
            }
        }
        */

        GameObject tile = PoolController.Instance.SpawnFromPool(pgData.tilePrefab, initPosition, Quaternion.identity);
        tile.transform.localScale = platformScale;
        tile.transform.parent = transform;
        pgData.tileStorage.Enqueue(tile);
    }

    // Generates part of track.
    public void GenerateTrack()
    {
        // Length of next part of the track in tiles.
        int nextpartLength;
        // Defines required number of tiles to finish the track.
        int tilesLeft = pgData.trackLength;
        // Defines the maximal possible length of track's straight part.
        int maxLineLength = pgData.trackLineLength;

        // Spawning until tiles will finish.
        while (tilesLeft > 0)
        {
            if (maxLineLength > tilesLeft)
            {
                maxLineLength = tilesLeft;
            }

            nextpartLength = Random.Range(1, maxLineLength);
            tilesLeft -= nextpartLength;

            // Shifts for modifying spawn position.
            Vector3 shiftLeft = new Vector3(0, 0, pgData.tileSize);
            Vector3 shiftRight = new Vector3(pgData.tileSize, 0, 0);
            Vector3 direction = Vector3.zero;

            // Choose shift.
            if (pgData.isLeft)
            {
                direction += shiftLeft;
            }
            else
            {
                direction += shiftRight;
            }

            GenerateLine(nextpartLength, direction, pgData.newTileScale);

            // Changing direction.
            pgData.isLeft = !pgData.isLeft;
        }
    }

    // Generates straight line of tiles.
    private void GenerateLine(int length, Vector3 direction, Vector3 scale)
    {
        // Spawning the tiles.
        for (int i = 0; i < length; i++)
        {
            Vector3 nextPosition = pgData.lastTilePosition + direction;
            GameObject tile = PoolController.Instance.SpawnFromPool(pgData.tilePrefab, nextPosition, Quaternion.identity);
            tile.transform.parent = transform;

            // Adding tile to storages.
            pgData.generatedTrackPart.Add(tile);
            pgData.tileStorage.Enqueue(tile);

            // Changing scale of spawned tile.
            tile.transform.localScale = scale;
            // Setting new position to next tile.
            pgData.lastTilePosition = nextPosition;
        }
    }

    // Cleaning every tile.
    public void DeleteTrack()
    {
        // Destroying start platform.
        foreach (GameObject tile in pgData.tileStorage)
        {
            if (tile)
            {
                PoolController.Instance.ReturnToPool(tile);
            }
        }

        // Clearing storages.
        pgData.tileStorage.Clear();
        pgData.generatedTrackPart.Clear();
    }
}

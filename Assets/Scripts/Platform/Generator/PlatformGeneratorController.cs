using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorController: MonoBehaviour
{
    [HideInInspector]
    public PlatformGeneratorData pgData;

    public void GenerateStartPlatform()
    {
        // Setting initial position.
        Vector3 initPosition = pgData.initialTilePosition;
        Vector3 nextPosition;

        // Generating start platform.
        for (int i = 0; i < 3; i++)
        {
            nextPosition = initPosition;
            nextPosition += new Vector3(-pgData.originalTileSize * i, 0, 0);
            for (int j = 0; j < 3; j++)
            {
                GameObject tile = Instantiate(pgData.tilePrefab, nextPosition, Quaternion.identity, transform);
                pgData.tileStorage.Enqueue(tile);
                nextPosition += new Vector3(0, 0, -pgData.originalTileSize);
            }
        }
    }

    public void GenerateTrack()
    {
        // Length of next part of the track in tiles.
        int nextpartLength;
        // Defines required number of tiles to finish the track.
        int tilesLeft = pgData.trackLength;
        // Defines the maximal possible length of track's straight part.
        int maxLineLength = pgData.trackLineLength;

        while (tilesLeft > 0)
        {
            if (maxLineLength > tilesLeft)
            {
                maxLineLength = tilesLeft;
            }

            nextpartLength = Random.Range(1, maxLineLength);
            tilesLeft -= nextpartLength;

            Vector3 shiftLeft = new Vector3(0, 0, pgData.tileSize);
            Vector3 shiftRight = new Vector3(pgData.tileSize, 0, 0);
            Vector3 direction = Vector3.zero;

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

    private void GenerateLine(int length, Vector3 direction, Vector3 scale)
    {
        // Spawning the tiles.
        for (int i = 0; i < length; i++)
        {
            Vector3 nextPosition = pgData.lastTilePosition + direction;
            GameObject tile = Instantiate(pgData.tilePrefab, nextPosition, Quaternion.identity, transform);

            // Adding tile to storages.
            pgData.generatedTrackPart.Add(tile);
            pgData.tileStorage.Enqueue(tile);

            // Changing scale of spawned tile.
            tile.transform.localScale = scale;
            // Setting new position to next tile.
            pgData.lastTilePosition = nextPosition;
        }
    }

    public void DeleteTrack()
    {
        // Destroying start platform.
        foreach (GameObject tile in pgData.tileStorage)
        {
            if (tile)
            {
                Destroy(tile);
            }
        }

        // Clearing storages.
        pgData.tileStorage.Clear();
        pgData.generatedTrackPart.Clear();
    }
}

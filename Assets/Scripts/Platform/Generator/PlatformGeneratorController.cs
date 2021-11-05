using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorController: MonoBehaviour
{
    [HideInInspector]
    public PlatformGeneratorData pgData;

    public void GenerateTrack()
    {
        // Length of next part of the track in tiles.
        int nextpartLength;
        // Defines required number of tiles to finish the track.
        int tilesLeft = pgData.trackLength;
        // Defines the maximal possible length of track's straight part.
        int maxLineLength = pgData.trackLineLength;
        // Defines new tile scale depending on level difficulty.
        Vector3 newTileScale;

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
                newTileScale = new Vector3(pgData.tileSize * pgData.trackWidth, pgData.tileSize, pgData.tileSize);
                direction += shiftLeft;
            }
            else
            {
                newTileScale = new Vector3(pgData.tileSize, pgData.tileSize, pgData.tileSize * pgData.trackWidth);
                direction += shiftRight;
            }

            GenerateLine(nextpartLength, direction, newTileScale);

            // Changing direction.
            pgData.isLeft = !pgData.isLeft;
            // Correcting position while turning.
            if (pgData.isLeft)
            {
                pgData.lastTilePosition += new Vector3(-pgData.zShift, 0, pgData.zShift);
            }
            else
            { 
                pgData.lastTilePosition += new Vector3(pgData.zShift, 0, -pgData.zShift);
            }
        }
    }

    private void GenerateLine(int length, Vector3 direction, Vector3 scale)
    {
        // Spawning the tiles.
        for (int i = 0; i < length; i++)
        {
            Vector3 nextPosition = pgData.lastTilePosition + direction;
            GameObject tile = Instantiate(pgData.tilePrefab, nextPosition, Quaternion.identity, transform);

            // Adding tile to storage.
            pgData.tileStorage.Add(tile);
            // Changing scale of spawned tile.
            tile.transform.localScale = scale;
            // Setting new position to next tile.
            pgData.lastTilePosition = nextPosition;
        }
    }

    public void DeleteTrack()
    {
        foreach (GameObject tile in pgData.tileStorage)
        {
            Destroy(tile);
        }
        pgData.tileStorage.Clear();
    }
}

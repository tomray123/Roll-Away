using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGeneratorController : MonoBehaviour
{
    [HideInInspector]
    public PlatformGeneratorData pgData;
    [HideInInspector]
    public GemGeneratorData gemsData;

    // Called when gems have to be generated randomly.
    public void GenerateGemsRandomly()
    {
        int gemsNumber = pgData.generatedTrackPart.Count / 5;

        // A shift designed to keep the gems above the tile.
        Vector3 gemShift = new Vector3(0, pgData.originalTileSize, 0);

        // Spawning gems.
        for (int i = 0; i < gemsNumber; i++)
        {
            int randomPosition = Random.Range(1, 5) + i * 5 - 1;
            GameObject gem = PoolController.Instance.SpawnFromPool(gemsData.gemPrefab, pgData.generatedTrackPart[randomPosition].transform.position + gemShift, gemsData.gemPrefab.transform.rotation);
            gem.transform.parent = pgData.generatedTrackPart[randomPosition].transform;
        }
    }

    // Called when gems have to be generated consistently.
    public void GenerateGemsConsistently()
    {
        int gemsNumber = pgData.generatedTrackPart.Count / 5;

        // A shift designed to keep the gems above the tile.
        Vector3 gemShift = new Vector3(0, pgData.originalTileSize, 0);

        // Spawning gems.
        for (int i = 0; i < gemsNumber; i++)
        {
            int randomPosition = gemsData.gemPosition + i * 5 - 1;
            GameObject gem = PoolController.Instance.SpawnFromPool(gemsData.gemPrefab, pgData.generatedTrackPart[randomPosition].transform.position + gemShift, gemsData.gemPrefab.transform.rotation);
            gem.transform.parent = pgData.generatedTrackPart[randomPosition].transform;

            gemsData.gemPosition++;

            // Reset counter.
            if (gemsData.gemPosition > 5)
            {
                gemsData.gemPosition = 1;
            }
        }
    }
}

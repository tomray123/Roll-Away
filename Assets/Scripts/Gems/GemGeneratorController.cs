using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGeneratorController : MonoBehaviour
{
    [HideInInspector]
    public PlatformGeneratorData pgData;
    [HideInInspector]
    public GemGeneratorData gemsData;

    public void GenerateGemsRandomly()
    {
        int gemsNumber = pgData.tileStorage.Count / 5;

        // A shift designed to keep the gems above the tile.
        Vector3 gemShift = new Vector3(0, pgData.tilePrefab.transform.localScale.y / 2 + pgData.tileSize / 2, 0);

        for (int i = 0; i < gemsNumber; i++)
        {
            int randomPosition = Random.Range(1, 5) + i * 5 - 1;
            GameObject gem = Instantiate(gemsData.gemPrefab, pgData.tileStorage[randomPosition].transform.position + gemShift, Quaternion.identity);
            gem.transform.parent = pgData.tileStorage[randomPosition].transform;
        }
    }

    public void GenerateGemsConsistently()
    {
        int gemsNumber = pgData.tileStorage.Count / 5;

        // A shift designed to keep the gems above the tile.
        Vector3 gemShift = new Vector3(0, pgData.tilePrefab.transform.localScale.y / 2 + pgData.tileSize / 2, 0);

        for (int i = 0; i < gemsNumber; i++)
        {
            int randomPosition = gemsData.gemPosition + i * 5 - 1;
            GameObject gem = Instantiate(gemsData.gemPrefab, pgData.tileStorage[randomPosition].transform.position + gemShift, Quaternion.identity);
            gem.transform.parent = pgData.tileStorage[randomPosition].transform;

            gemsData.gemPosition++;

            // Reset counter.
            if (gemsData.gemPosition > 5)
            {
                gemsData.gemPosition = 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorMain: MonoBehaviour
{
    [SerializeField]
    private PlatformGeneratorData pgData;    
    private PlatformGeneratorController pgController; 

    private void Start()
    {
        pgController = GetComponent<PlatformGeneratorController>();

        pgData.InitializeData();
        pgController.GenerateTrack(pgData);   
    }

    private void Update()
    {
        // Checking for new last position.
        if (pgData.tileStorage[pgData.tileStorage.Count - 1].transform.position.x < pgData.spawnEndDistance || pgData.tileStorage[pgData.tileStorage.Count - 1].transform.position.z < pgData.spawnEndDistance)
        {
            // Correcting position while turning.
            if (pgData.isLeft)
            {
                pgData.lastTilePosition = pgData.tileStorage[pgData.tileStorage.Count - 1].transform.position + new Vector3(-pgData.zShift, 0, pgData.zShift);
            }
            else
            {
                pgData.lastTilePosition = pgData.tileStorage[pgData.tileStorage.Count - 1].transform.position + new Vector3(pgData.zShift, 0, -pgData.zShift);
            }
            pgController.GenerateTrack(pgData);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorMain: MonoBehaviour
{
    [SerializeField]
    private PlatformGeneratorData pgData;
    [SerializeField]
    private PlatformGenerationChannel pgChennel;
    [HideInInspector]
    public PlatformGeneratorController pgController; 

    private void Start()
    {
        pgController = GetComponent<PlatformGeneratorController>();
        pgController.pgData = pgData;

        pgData.InitializeData();

        pgController.GenerateTrack();
        pgChennel.RaiseEvent();
    }

    private void Update()
    {
        if (GameManagerData.isGameRunning && pgData.tileStorage.Count > 0)
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

                // Clearing storage.
                pgData.tileStorage.Clear();

                pgController.GenerateTrack();
                pgChennel.RaiseEvent();
            }
        }
    }
}

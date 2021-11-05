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

    private void Awake()
    {
        pgController = GetComponent<PlatformGeneratorController>();
        pgController.pgData = pgData;
    }

    private void Start()
    {
        pgData.InitializeData();

        pgController.GenerateStartPlatform();
        BuildNewTrack();
    }

    private void Update()
    {
        if (GameManagerData.isGameRunning && pgData.generatedTrackPart.Count > 0)
        {
            // Checking for new last position.
            if (pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position.x < pgData.spawnEndDistance || pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position.z < pgData.spawnEndDistance)
            {
                /*
                // Correcting position while turning.
                if (pgData.isLeft)
                {
                    pgData.lastTilePosition = pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position + new Vector3(-pgData.xShift, 0, pgData.xShift);
                }
                else
                {
                    pgData.lastTilePosition = pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position + new Vector3(pgData.xShift, 0, -pgData.xShift);
                }
                */

                pgData.lastTilePosition = pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position;

                // Clearing storage.
                pgData.generatedTrackPart.Clear();

                BuildNewTrack();
            }
        }
    }

    // Generates new track and raises event.
    public void BuildNewTrack()
    {
        pgController.GenerateTrack();
        pgChennel.RaiseEvent();
    }
}

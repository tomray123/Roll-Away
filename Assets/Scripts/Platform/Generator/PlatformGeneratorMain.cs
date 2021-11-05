using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorMain: MonoBehaviour
{
    [Header("Platform Generator Scriptable Object")]
    [SerializeField]
    private PlatformGeneratorData pgData;

    [Header("Platform Generation Event Channel")]
    [SerializeField]
    private PlatformGenerationChannel pgChannel;

    [HideInInspector]
    public PlatformGeneratorController pgController;

    private void Awake()
    {
        // Initializing some variables.
        pgController = GetComponent<PlatformGeneratorController>();
        pgController.pgData = pgData;
    }

    private void Start()
    {
        // Initializing data.
        pgData.InitializeData();
        // Generating start platform.
        pgController.GenerateStartPlatform();
        BuildNewTrack();
    }

    private void Update()
    {
        // Building a new part of the track if the old one is almost gone.
        if (GameManagerData.isGameRunning && pgData.generatedTrackPart.Count > 0)
        {
            // Checking for new last position.
            if (pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position.x < pgData.spawnEndDistance || pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position.z < pgData.spawnEndDistance)
            {
                pgData.lastTilePosition = pgData.generatedTrackPart[pgData.generatedTrackPart.Count - 1].transform.position;

                // Clearing storage.
                pgData.generatedTrackPart.Clear();

                // Building new track
                BuildNewTrack();
            }
        }
    }

    // Generates new track and raises event.
    public void BuildNewTrack()
    {
        pgController.GenerateTrack();
        pgChannel.RaiseEvent();
    }
}

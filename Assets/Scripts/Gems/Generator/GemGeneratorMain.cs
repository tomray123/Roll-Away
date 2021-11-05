using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGeneratorMain : MonoBehaviour
{
    [Header("Platform Generator Scriptable Object")]
    [SerializeField]
    private PlatformGeneratorData pgData;

    [Header("Gem Generator Scriptable Object")]
    [SerializeField]
    private GemGeneratorData gemsData;

    [Header("Platform Generation Event Channel")]
    [SerializeField]
    private PlatformGenerationChannel pgChennel;

    private GemGeneratorController ggController;

    private void Awake()
    {
        // Initializing some variables.
        ggController = GetComponent<GemGeneratorController>();
        ggController.pgData = pgData;
        ggController.gemsData = gemsData;
    }

    private void OnEnable()
    {
        // Initializing data.
        gemsData.InitializeData();
        // Subscribing to corresponding event.
        pgChennel.platformGenerationEvent.AddListener(StartGemGeneration);
    }

    private void OnDisable()
    {
        // Unsubscribing from corresponding event.
        pgChennel.platformGenerationEvent.RemoveListener(StartGemGeneration);
    }

    // Starts gem generation depending on the selected generation mode.
    void StartGemGeneration()
    {
        // Generating randomly.
        if (gemsData.generationType == GemGenerationType.Randomly)
        {
            ggController.GenerateGemsRandomly();
        }
        // Generating consistently.
        if (gemsData.generationType == GemGenerationType.Consistently)
        {
            ggController.GenerateGemsConsistently();
        }
    }
}

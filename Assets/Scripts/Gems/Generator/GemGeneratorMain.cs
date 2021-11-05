using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGeneratorMain : MonoBehaviour
{
    [SerializeField]
    private PlatformGeneratorData pgData;
    [SerializeField]
    private GemGeneratorData gemsData;
    [SerializeField]
    private PlatformGenerationChannel pgChennel;

    private GemGeneratorController ggController;

    private void Awake()
    {
        ggController = GetComponent<GemGeneratorController>();
        ggController.pgData = pgData;
        ggController.gemsData = gemsData;
    }

    private void OnEnable()
    {
        gemsData.InitializeData();
        pgChennel.platformGenerationEvent.AddListener(StartGemGeneration);
    }

    private void OnDisable()
    {
        pgChennel.platformGenerationEvent.RemoveListener(StartGemGeneration);
    }

    void StartGemGeneration()
    {
        if (gemsData.generationType == GemGenerationType.Randomly)
        {
            ggController.GenerateGemsRandomly();
        }
        if (gemsData.generationType == GemGenerationType.Consistently)
        {
            ggController.GenerateGemsConsistently();
        }
    }
}

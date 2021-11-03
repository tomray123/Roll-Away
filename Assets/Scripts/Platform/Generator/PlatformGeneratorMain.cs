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
}

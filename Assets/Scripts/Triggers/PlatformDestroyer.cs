﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Destroying game objects.
        Destroy(other.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Eevnet channel for game states.
    [SerializeField]
    private GameStateChannel gameStateChannel;

    private void OnEnable()
    {
        gameStateChannel.gameStateChangeEvent += OnGameStateChanged;
    }

    private void OnDisable()
    {
        gameStateChannel.gameStateChangeEvent -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newState)
    {
        if (newState == GameState.start)
        {
            transform.LookAt(player.transform);
        }
    }
}

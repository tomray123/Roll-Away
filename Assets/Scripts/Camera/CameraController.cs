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
        // Subscribing to corresponding event.
        gameStateChannel.gameStateChangeEvent += OnGameStateChanged;
    }

    private void OnDisable()
    {
        // Unsubscribing from corresponding event.
        gameStateChannel.gameStateChangeEvent -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newState)
    {
        // When game starts (or start screen is displayed).
        if (newState == GameState.start)
        {
            // Setting camera look on player.
            transform.LookAt(player.transform);
        }
    }
}

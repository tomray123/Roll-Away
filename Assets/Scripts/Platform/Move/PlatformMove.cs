using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    [Header("Input manager")]
    [SerializeField]
    private InputController input;

    [Header("Platform Move Scriptable Object")]
    [SerializeField]
    private PlatformMoveData pmData;

    [Header("Game State Event Channel")]
    [SerializeField]
    private GameStateChannel gameState;

    private void FixedUpdate()
    {
        // If playing then move track.
        if (GameManagerData.isGameRunning)
        {
            Move();
        }
    }

    private void OnEnable()
    {
        // Initializing data.
        pmData.InitializeData();
        // Subscribing to corresponding event.
        gameState.gameStateChangeEvent += OnGameStateChanged;
    }

    private void OnDisable()
    {
        // Unsubscribing from corresponding event.
        gameState.gameStateChangeEvent -= OnGameStateChanged;
    }

    // Moves track.
    private void Move()
    {
        // Movement direction.
        Vector3 direction;
        if (pmData.moveDirectionLeft)
        {
            // Move left.
            direction = Vector3.back;
            transform.Translate(direction * pmData.speed * Time.fixedDeltaTime);
        }
        else
        {
            // Move right.
            direction = Vector3.left;
            transform.Translate(direction * pmData.speed * Time.fixedDeltaTime);
        }
    }

    // Changing direction when button is clicked.
    private void ChangeDirection()
    {
        if (GameManagerData.isGameRunning)
        {
            pmData.moveDirectionLeft = !pmData.moveDirectionLeft;
        }
    }

    // Enables and disables onClick listener.
    private void OnGameStateChanged(GameState newState)
    {
        if (newState == GameState.play)
        {
            input.onClick.AddListener(ChangeDirection);
        }
        if (newState == GameState.gameOver)
        {
            input.onClick.RemoveListener(ChangeDirection);
        }
    }
}

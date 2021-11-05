using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField]
    private InputController input;
    [SerializeField]
    private PlatformMoveData pmData;
    [SerializeField]
    private GameStateChannel gameState;

    private void FixedUpdate()
    {
        if (GameManagerData.isGameRunning)
        {
            Move();
        }
    }

    private void OnEnable()
    {
        pmData.InitializeData();
        gameState.gameStateChangeEvent += OnGameStateChanged;
    }

    private void OnDisable()
    {
        gameState.gameStateChangeEvent -= OnGameStateChanged;
    }

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

    private void ChangeDirection()
    {
        if (GameManagerData.isGameRunning)
        {
            pmData.moveDirectionLeft = !pmData.moveDirectionLeft;
        }
    }

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

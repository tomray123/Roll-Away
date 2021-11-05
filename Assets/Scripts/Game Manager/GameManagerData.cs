using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    start,
    play,
    gameOver
}

[CreateAssetMenu(menuName = "Game Manager Data")]
public class GameManagerData : ScriptableObject
{
    // Defines whether game is running or not.
    public static bool isGameRunning;

    [HideInInspector]
    public GameState gameState;

    [Header("Data Scriptable Objects")]
    [SerializeField]
    private UIData uIData;
    [SerializeField]
    private PlatformGeneratorData pgData;
    [SerializeField]
    private PlatformMoveData moveData;
    [SerializeField]
    private GemGeneratorData gemData;

    public void InitializeData()
    {
        // Game is not running initially.
        isGameRunning = false;

        // Initializing all data.
        uIData.InitializeData();
        pgData.InitializeData();
        moveData.InitializeData();
        gemData.InitializeData();

        // Initial state.
        gameState = GameState.start;
    }
}

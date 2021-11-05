using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameManagerData data;
    [SerializeField]
    private InputController input;
    [SerializeField]
    private UIView uIView;
    [SerializeField]
    private PlatformGeneratorMain plGenerator;
    [SerializeField]
    private FallTriggerChannel fallChannel;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        // Setting defaults.
        data.InitializeData();

        // Drawing UI.
        uIView.ClearScreen();
        uIView.DisplayStartScreen();

        data.gameState = GameState.start;
    }

    private void ShowStartMenu()
    {
        // Cleaning and building new track.
        plGenerator.pgController.DeleteTrack();
        plGenerator.pgController.GenerateTrack();

        // Setting defaults.
        data.InitializeData();

        // Drawing UI.
        uIView.ClearScreen();
        uIView.DisplayStartScreen();

        data.gameState = GameState.start;
    }

    private void StartGame()
    {
        // Drawing UI.
        uIView.ClearScreen();
        uIView.DisplayScoreScreen();

        data.gameState = GameState.play;
        GameManagerData.isGameRunning = true;

        // Don't listen to UI clicks while playing.
        input.onClick.RemoveListener(ManageClick);
    }

    private void OnLose()
    {
        // Drawing UI.
        uIView.DisplayGameOverScreen();

        input.onClick.AddListener(ManageClick);
        GameManagerData.isGameRunning = false;

        data.gameState = GameState.gameOver;
    }

    public void ManageClick()
    {
        switch (data.gameState)
        {
            // Starting game.
            case GameState.start:

                StartGame();

                break;

            // When player clicked after losing.
            case GameState.gameOver:

                ShowStartMenu();

                break;
        }
    }

    private void OnEnable()
    {
        input.onClick.AddListener(ManageClick);
        fallChannel.fallTriggerEvent.AddListener(OnLose);
    }

    private void OnDisable()
    {
        input.onClick.RemoveListener(ManageClick);
        fallChannel.fallTriggerEvent.RemoveListener(OnLose);
    }
}


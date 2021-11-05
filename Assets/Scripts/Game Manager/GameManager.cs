using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Data holder")]
    [SerializeField]
    private GameManagerData data;

    [Header("Input manager")]
    [SerializeField]
    private InputController input;

    [Header("Event channels")]
    [SerializeField]
    private FallTriggerChannel fallChannel;
    [SerializeField]
    private GameStateChannel gameState;

    [Header("Other")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private UIView uIView;
    [SerializeField]
    private PlatformGeneratorMain plGenerator;

    void Start()
    {
        // Setting defaults.
        data.InitializeData();

        // Drawing UI.
        uIView.ClearScreen();
        uIView.DisplayStartScreen();

        // Changing game state.
        data.gameState = GameState.start;
        gameState.RaiseEvent(GameState.start);
    }

    private void ShowStartMenu()
    {
        // Cleaning old track.
        plGenerator.pgController.DeleteTrack();

        // Setting defaults.
        data.InitializeData();

        // Building new track.
        plGenerator.pgController.GenerateStartPlatform();
        plGenerator.BuildNewTrack();

        // Drawing UI.
        uIView.ClearScreen();
        uIView.DisplayStartScreen();

        // Setting player.
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0.25f, 0);

        // Changing game state.
        data.gameState = GameState.start;
        gameState.RaiseEvent(GameState.start);
    }

    private void StartGame()
    {
        // Drawing UI.
        uIView.ClearScreen();
        uIView.ChangeScoreView(0);
        uIView.DisplayScoreScreen();

        // Changing game state.
        data.gameState = GameState.play;
        gameState.RaiseEvent(GameState.play);
        GameManagerData.isGameRunning = true;

        // Don't listen to UI clicks while playing.
        input.onClick.RemoveListener(ManageClick);
    }

    private void OnLose()
    {
        // Disabling player.
        player.SetActive(false);

        // Drawing UI.
        uIView.DisplayGameOverScreen();

        // Changing game state.
        input.onClick.AddListener(ManageClick);
        GameManagerData.isGameRunning = false;
        data.gameState = GameState.gameOver;
        gameState.RaiseEvent(GameState.gameOver);
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
        // Subscribing to corresponding events.
        input.onClick.AddListener(ManageClick);
        fallChannel.fallTriggerEvent.AddListener(OnLose);
    }

    private void OnDisable()
    {
        // Unsubscribing from corresponding events.
        input.onClick.RemoveListener(ManageClick);
        fallChannel.fallTriggerEvent.RemoveListener(OnLose);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Game State Channel")]
public class GameStateChannel : ScriptableObject
{
    [HideInInspector]
    public UnityAction<GameState> gameStateChangeEvent;

    public void RaiseEvent(GameState newState)
    {
        if (gameStateChangeEvent != null)
        {
            gameStateChangeEvent.Invoke(newState);
        }
    }
}

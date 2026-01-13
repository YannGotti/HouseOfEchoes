using Assets.Scripts.Core;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameState _currentState = GameState.Explore;

    public void SetState(GameState newState)
    {
        if (_currentState == newState) return;
        _currentState = newState;

        Time.timeScale = (_currentState == GameState.Pause) ? 0f : 1f;
    }

    public GameState GetCurrentState() => _currentState;

}
using Assets.Scripts.Core;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance { get; private set; }

    private GameState _currentState = GameState.Explore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    public void SetState(GameState newState)
    {
        if (_currentState == newState) return;

        var previousState = _currentState;
        _currentState = newState;

        Time.timeScale = (_currentState == GameState.Pause) ? 0f : 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        GlobalEventBus.OnGameStateChanged?.Invoke(_currentState, previousState);
    }

    public GameState GetCurrentState() => _currentState;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : System.Enum
{
    public Dictionary<T, StateBase> dictionaryState;

    private StateBase _currentState;
    public float timeToStartGame;

    public StateBase CurrentState
    {
        get { return _currentState; }
    }

    // Initialize the state dictionary.
    public void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }

    // Register a state using its enum value.
    public void RegisterStates(T typeEnum, StateBase state)
    {
        dictionaryState.Add(typeEnum, state);
    }

    // Switch from the current state to another state.
    public void SwitchState(T state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();
    }

    // Update the currently active state.
    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStateStay();
        }
    }
}
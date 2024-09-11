using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine<T> where T : System.Enum
{
    //chave
    public Dictionary<T, StateBase> dictionaryState;

    private StateBase _currentState;
    public float timeToStartGame = 1f;

    protected void RegisterStates(T typeEnum, StateBase state)
    {
        //dictionaryState = new Dictionary<T, StateBase>();
        dictionaryState.Add(typeEnum, state);

        //SwitchState(States.NONE);

        //Invoke(nameof(StartGame), timeToStartGame);
    }

    [Button]
    private void StartGame()
    {
        //SwitchState(States.NONE);
    }

    [Button]
    private void SwitchState(T state)
    {
        if (_currentState != null) _currentState.OnStateExit();
        
        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.O))
        {
            //SwitchState(States.DEAD);
        }
    }


}

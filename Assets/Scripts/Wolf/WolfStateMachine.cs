using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateMachine
{
    //create the current state that the player is in
    public WolfState currentState { get; private set; }

    //At the beginning (player spawn), enter a certain state
    public void Initialize(WolfState _startState) //the state when the scene starts
    {
        currentState = _startState;
        currentState.Enter(); //enter the very first state
    }

    //change state
    public void ChangeState(WolfState _newState) //manually change state
    {
        currentState.Exit(); //exit the old state
        currentState = _newState;
        currentState.Enter(); //enter a new state
    }
}

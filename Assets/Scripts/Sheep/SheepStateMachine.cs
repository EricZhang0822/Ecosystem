using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepStateMachine
{
    //create the current state that the player is in
    public SheepState currentState { get; private set; }

    //At the beginning (player spawn), enter a certain state
    public void Initialize(SheepState _startState) //the state when the scene starts
    {
        currentState = _startState;
        currentState.Enter(); //enter the very first state
    }

    //change state
    public void ChangeState(SheepState _newState) //manually change state
    {
        currentState.Exit(); //exit the old state
        currentState = _newState;
        currentState.Enter(); //enter a new state
    }
}

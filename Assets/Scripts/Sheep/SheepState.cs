using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepState
{
    protected SheepStateMachine stateMachine;
    protected Sheep sheep;
    protected Rigidbody2D rb;

    protected SpriteRenderer sr;

    protected float stateTimer; //this can be set to any number in one particular state. So if you need a timer, just set the timer and the condition in that state.

    public SheepState(Sheep _sheep, SheepStateMachine _stateMachine) //the constructor
    {
        this.sheep = _sheep;
        this.stateMachine = _stateMachine;
    }

    //These 3 functions are used to be overwritten by the current state.
    public virtual void Enter()
    {
        rb = sheep.rb; //for quicker code
        sr = sheep.sr;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

    }

    public virtual void Exit()
    {

    }


}


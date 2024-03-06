using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfState
{
    protected WolfStateMachine stateMachine;
    protected Wolf wolf;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected float stateTimer; //this can be set to any number in one particular state. So if you need a timer, just set the timer and the condition in that state.

    public WolfState(Wolf _wolf, WolfStateMachine _stateMachine) //the constructor
    {
        this.wolf = _wolf;
        this.stateMachine = _stateMachine;
    }

    //These 3 functions are used to be overwritten by the current state.
    public virtual void Enter()
    {
        rb = wolf.rb; //for quicker code
        sr = wolf.sr;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

    }

    public virtual void Exit()
    {

    }



}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureState
{
    protected VultureStateMachine stateMachine;
    protected Vulture vulture;
    protected Rigidbody2D rb;

    protected float stateTimer; //this can be set to any number in one particular state. So if you need a timer, just set the timer and the condition in that state.

    public VultureState(Vulture _vulture, VultureStateMachine _stateMachine) //the constructor
    {
        this.vulture = _vulture;
        this.stateMachine = _stateMachine;
    }

    //These 3 functions are used to be overwritten by the current state.
    public virtual void Enter()
    {
        rb = vulture.rb; //for quicker code
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

    }

    public virtual void Exit()
    {

    }


}


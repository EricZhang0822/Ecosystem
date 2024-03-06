using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureLeaveState : VultureState
{
    private bool leaved = false;
    public VultureLeaveState(Vulture _vulture, VultureStateMachine _stateMachine) : base(_vulture, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .1f;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer > 0)
        {
            vulture.SetZeroVelocity();
        }
        else
        {
            leaved = true;
        }

        if(leaved)
        {
            leaved = false;
            vulture.SetVelocity(Random.Range(-1, 1), Random.Range(3,4));
        }

    }


}

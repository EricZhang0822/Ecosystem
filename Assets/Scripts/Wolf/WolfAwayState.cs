using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAwayState : WolfState
{
    public WolfAwayState(Wolf _wolf, WolfStateMachine _stateMachine) : base(_wolf, _stateMachine)
    {
    }

    public override void Enter()
    {
        
        base.Enter();

        stateTimer = 2;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateTimer = Mathf.Infinity;
            wolf.SetVelocity(Random.Range(-1.5f, 1.5f), Random.Range(2.5f, 3.5f));
        }
    }


}

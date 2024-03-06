using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEatingState : WolfState
{
    private float pause_timer = .3f;
    private bool pause = false;
    public WolfEatingState(Wolf _wolf, WolfStateMachine _stateMachine) : base(_wolf, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        pause = true;

        stateTimer = 1.5f;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        pause_timer -= Time.deltaTime;

        if (pause_timer < 0 && pause == true) // cancel the -velocity effect, which i dont know why exists
        {
            pause = false;
            wolf.SetZeroVelocity();
        }
        
        if(stateTimer < 0)
        {
            stateMachine.ChangeState(wolf.idleState);
        }
            
    }

}

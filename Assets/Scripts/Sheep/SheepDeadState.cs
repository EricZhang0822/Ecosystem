using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SheepDeadState : SheepState
{
    
    public SheepDeadState(Sheep _sheep, SheepStateMachine _stateMachine) : base(_sheep, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        stateTimer = 3f;
        SheepManager.SheepCount--;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        sheep.SetZeroVelocity();
        if (stateTimer < 0) //wait for test
        {
            Manager.reference.dead_targets.Remove(this.sheep.gameObject);
            GameObject.Destroy(sheep.gameObject);
        }
    }
}

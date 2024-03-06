using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SheepIdleState : SheepState
{
    private float GrassTime_Min = 3f;
    private float GrassTime_Max = 7f;
    private bool resetVel = false;
    private float birth_timer = Random.Range(10,20);
    public SheepIdleState(Sheep _sheep, SheepStateMachine _stateMachine) : base(_sheep, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = Random.Range(GrassTime_Min, GrassTime_Max);

        sheep.SetVelocity(Random.Range(-1, 1.2f), Random.Range(-.3f, .3f));
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        birth_timer -= Time.deltaTime;

        if(Mathf.Abs(rb.velocity.x) < .3f)
        {
            sheep.SetVelocity(Random.Range(-1, 1.2f), Random.Range(-.3f, .3f));
        }

        if(stateTimer <= GrassTime_Min && stateTimer > 0)
        {
            sheep.SetZeroVelocity();
        }else if(stateTimer <= 0)
        {
            stateTimer = Random.Range(GrassTime_Min+2,GrassTime_Max+2);
            resetVel = true;
        }
        
        if(resetVel)
        {
            sheep.SetVelocity(Random.Range(-1, 1.2f), Random.Range(-.3f, .3f));
            resetVel = false;
        }

        if (SheepManager.SheepCount <= 6 && birth_timer < 0)
        {
            stateMachine.ChangeState(sheep.birthState);
            birth_timer = Random.Range(10, 20);
        }

        if(sheep.IsWolfDetected(1.5f, 10))
        {
            stateMachine.ChangeState(sheep.escState);
        }

    }


}

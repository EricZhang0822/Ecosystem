using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfIdleState : WolfState
{
    private float stealthDistance = 7f;
    private GameObject preySheep;
    
    public WolfIdleState(Wolf _wolf, WolfStateMachine _stateMachine) : base(_wolf, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(Random.Range(1,1.5f), Random.Range(-1f,-1.2f));

        stateTimer = 0;

        sr.sprite = wolf.walk;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Manager.reference.targets.Count != 0)
        {
            if (stateTimer <= 0)
            {
                stateTimer = .5f;
                preySheep = wolf.FindClosestTarget(Manager.reference.targets);
            }

            if (preySheep != null)
            {

                Vector3 DirectionToSheep = wolf.transform.position - preySheep.transform.position;
                float DistanceToSheep = DirectionToSheep.magnitude;

                if (DistanceToSheep < stealthDistance)
                {
                    stateMachine.ChangeState(wolf.stealthState);
                }
            }
        }
        else
        {
            return;
        }

       


    }


}

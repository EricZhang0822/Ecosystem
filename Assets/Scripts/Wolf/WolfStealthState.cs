using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStealthState : WolfState
{
    private GameObject preySheep;
    public WolfStealthState(Wolf _wolf, WolfStateMachine _stateMachine) : base(_wolf, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

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
        if (Manager.reference.targets.Count != 0)
        {
            if (stateTimer <= 0)
            {
                stateTimer = .5f;
                preySheep = wolf.FindClosestTarget(Manager.reference.targets);
            }

            if (preySheep != null)
            {
                Vector3 DirectionToSheep = preySheep.transform.position - wolf.transform.position;
                float DistanceToSheep = DirectionToSheep.magnitude;

                wolf.SetVelocity(DirectionToSheep.normalized.x * .5f, DirectionToSheep.normalized.y * .5f);

                if (DistanceToSheep < 4)
                {
                    stateMachine.ChangeState(wolf.attackState);
                }

            }
        }
        else
        {
            return;
        }

        
    }


    
}

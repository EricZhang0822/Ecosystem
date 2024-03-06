using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : WolfState
{
    private GameObject preySheep;

    public WolfAttackState(Wolf _wolf, WolfStateMachine _stateMachine) : base(_wolf, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 0f;

        sr.sprite = wolf.run;
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
            if (stateTimer < 0)
            {
                stateTimer = .5f;
                preySheep = wolf.FindClosestTarget(Manager.reference.targets);
            }
            if (preySheep != null)
            {
                Vector3 DirectionToSheep = preySheep.transform.position - wolf.transform.position;
                float DistanceToSheep = DirectionToSheep.magnitude;

                rb.velocity = DirectionToSheep.normalized * 1.5f;
            }
            

            
        }
        else
        {
            return;
        }

        
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEatState : VultureState
{
    private GameObject target_sheep;
    public VultureEatState(Vulture _vulture, VultureStateMachine _stateMachine) : base(_vulture, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        target_sheep = Manager.reference.dead_targets[0];
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Vector3 directionToTarget = target_sheep.transform.position - vulture.transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        vulture.SetVelocity(directionToTarget.normalized.x * 2f, directionToTarget.normalized.y * 2f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEscapeState : SheepState
{
    public float safeDistance = 5f; // The distance sheep tries to maintain from the wolf
    public float moveSpeed = Random.Range(.7f,.9f);
    private GameObject wolf;

    public SheepEscapeState(Sheep _sheep, SheepStateMachine _stateMachine) : base(_sheep, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0;
        wolf = GameObject.FindGameObjectWithTag("Wolf");

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (stateTimer < 0)
        {
            stateTimer = .5f;
            wolf = GameObject.FindGameObjectWithTag("Wolf");
        }

        Vector3 directionToWolf = wolf.transform.position - sheep.transform.position;
        float distanceToWolf = directionToWolf.magnitude;

        if (distanceToWolf < safeDistance)
        {
            // If too close to the wolf, move away
            FleeFromWolf(directionToWolf);
        }else if (distanceToWolf > safeDistance + 5)
        {
            stateMachine.ChangeState(sheep.idleState);
        }



        if(wolf == null)
            stateMachine.ChangeState(sheep.idleState);
    }

    void FleeFromWolf(Vector3 directionToWolf)
    {
        Vector3 fleeDirection = -directionToWolf.normalized; // Move in the opposite direction
        sheep.SetVelocity(fleeDirection.x * moveSpeed, fleeDirection.y * moveSpeed);
    }

    


}

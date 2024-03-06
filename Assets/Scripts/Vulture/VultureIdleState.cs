using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureIdleState : VultureState
{
    public float majorAxis = Random.Range(6f,8f);
    public float minorAxis = Random.Range(3f, 4f);
    public float speed = 3f;
    private float angle = 0f; // Tracks the current angle

    public VultureIdleState(Vulture _vulture, VultureStateMachine _stateMachine) : base(_vulture, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        angle += speed * Time.deltaTime;

        float xVelocity = -Mathf.Sin(angle) * majorAxis;
        float yVelocity = Mathf.Cos(angle) * minorAxis;

        // Apply the calculated velocity
        vulture.SetVelocity(xVelocity, yVelocity);

        if(Manager.reference.dead_targets.Count != 0)
        {
            if(stateTimer < 0)
            {
                stateMachine.ChangeState(vulture.eatState);
            }
        }
    }

    



    
}

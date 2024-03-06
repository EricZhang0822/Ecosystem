using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCorpseState : SheepState
{
    public float rotationSpeed = 150f;
    private bool isRotating = true;
    public SheepCorpseState(Sheep _sheep, SheepStateMachine _stateMachine) : base(_sheep, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        sheep.SetZeroVelocity();
        stateTimer = 2f;

        Manager.reference.dead_targets.Add(this.sheep.gameObject);
        Manager.reference.targets.Remove(this.sheep.gameObject);
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        sheep.SetZeroVelocity();

        if (isRotating)
        {
            sheep.transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
            //sheep.transform.rotation = Quaternion.RotateTowards(sheep.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (sheep.transform.rotation == Quaternion.Euler(180,0,0))
            {
                isRotating = false; // Stop the rotation
            }

        }

        
        //write for vulture come to eat state (dead state)
    }

}

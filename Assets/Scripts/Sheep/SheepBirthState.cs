using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBirthState : SheepState
{
    public GameObject _newSheep;
    public SheepBirthState(Sheep _sheep, SheepStateMachine _stateMachine) : base(_sheep, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        sheep.SetZeroVelocity();

        

        //play some miemie sound

        SpawnSheep();

        stateMachine.ChangeState(sheep.idleState);


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        
    }

    public void SpawnSheep()
    {
        GameObject _newSheep = GameObject.Instantiate(sheep.new_sheep, new Vector3(Random.Range(0, 8), Random.Range(-1, -3.8f), 0), Quaternion.identity, sheep.par);

    }


}

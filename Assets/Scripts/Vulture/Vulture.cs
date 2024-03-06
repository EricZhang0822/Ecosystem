using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Vulture: MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }



    #region facing variables
    protected bool facingLeft = false; //player first faces to the left
    #endregion


    #region States 
    //declare all the states here.
    public VultureStateMachine stateMachine { get; private set; }
    public VultureIdleState idleState { get; private set; }
    public VultureEatState eatState { get; private set; }
    public VultureLeaveState leaveState { get; private set; }
    #endregion


    void Awake()
    {
        stateMachine = new VultureStateMachine();

        idleState = new VultureIdleState(this, stateMachine);

        eatState = new VultureEatState(this, stateMachine);

        leaveState = new VultureLeaveState(this, stateMachine);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);
        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();

        FlipController(rb.velocity.x);


    }

    #region Flip
    public void Flip()
    {
        facingLeft = !facingLeft; //facing left now
        transform.Rotate(0, 180, 0); //turn the gameObject 180 deg, including the child Animator
    }

    public void FlipController(float _x) //used by SetVelocity(), and decides when to call Flip()
    {
        if (_x <= 0 && !facingLeft)
        {
            Flip();
            facingLeft = true;
        } else if (_x > 0 && facingLeft)
        {
            Flip();
            facingLeft= false;
        } //if facing right but input smaller than 0 (to the left), flip
    }

    #endregion


    #region Velocity
    public void SetZeroVelocity() => rb.velocity = new Vector2(0, 0); //Set player's velocity to 0. Just for conveniency

    public void SetVelocity(float _xVelocity, float _yVelocity) //Set the player's velocity freely in each state
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    public void ChangeToLeaveState()
    {
        stateMachine.ChangeState(leaveState);
    }

}

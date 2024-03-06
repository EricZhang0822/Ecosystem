using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class Sheep: MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public SpriteRenderer sr { get; private set; }


    #region check wolf
    [SerializeField] protected Transform wolfCheck;
    [SerializeField] protected float CheckWolfDistance;
    [SerializeField] protected LayerMask whatIsWolf;
    #endregion

    #region facing variables
    protected bool facingLeft = true; //player first faces to the left
    public int facingDir { get; private set; } = -1;
    #endregion
    public Transform par;
    public Transform wolf_pos { get; private set; }

    public GameObject new_sheep;

    public static Sheep sheep_reference;

    public bool dead_sheep = false;


    #region States 
    //declare all the states here.
    public SheepStateMachine stateMachine { get; private set; }
    public SheepIdleState idleState { get; private set; }
    public SheepBirthState birthState { get; private set; }
    public SheepDeadState deadState { get; private set; }
    public SheepEscapeState escState { get; private set; }
    public SheepCorpseState cspState { get; private set; }
    #endregion


    void Awake()
    {

        sheep_reference = this;
        stateMachine = new SheepStateMachine();

        birthState = new SheepBirthState(this, stateMachine);

        escState = new SheepEscapeState(this, stateMachine);

        idleState = new SheepIdleState(this, stateMachine);

        deadState = new SheepDeadState(this, stateMachine);

        cspState = new SheepCorpseState(this, stateMachine);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);

        Manager.reference.targets.Add(gameObject);

        SheepManager.SheepCount++;
        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();

        Debug.Log(stateMachine.currentState);
        
        FlipController(rb.velocity.x);
    }

    #region Flip
    public void Flip()
    {
        facingDir *= -1;
        facingLeft = !facingLeft; //facing left now
        transform.Rotate(0, 180, 0); //turn the gameObject 180 deg, including the child Animator
    }

    public void FlipController(float _x) //used by SetVelocity(), and decides when to call Flip()
    {
        if (_x < 0 && !facingLeft)
        {
            Flip();
            facingLeft = true;
        } else if (_x >= 0 && facingLeft)
        {
            Flip();
            facingLeft= false;
        } //if facing right but input smaller than 0 (to the left), flip
    }

    #endregion

    public void ChangeToCorpseState()
    {
        stateMachine.ChangeState(cspState);
    }

    public void ChangeToDeadState()
    {
        stateMachine.ChangeState(deadState);
    }

    #region Velocity
    public void SetZeroVelocity() => rb.velocity = new Vector2(0, 0); //Set player's velocity to 0. Just for conveniency

    public void SetVelocity(float _xVelocity, float _yVelocity) //Set the player's velocity freely in each state
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region Detect Wolf
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wolfCheck.position, new Vector3(wolfCheck.position.x - CheckWolfDistance, wolfCheck.position.y));
    }
    public virtual bool IsWolfDetected(float detectionWidth, int numberOfRays)
    {
        bool isWolfDetected = false;

        // Calculate the spacing between rays based on the specified detection width and number of rays
        float spacing = detectionWidth / (numberOfRays - 1);

        // Cast rays across the width of the detection area
        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate the starting position for this ray
            Vector2 start = wolfCheck.position + Vector3.up * (spacing * i - (detectionWidth / 2));

            // Perform the raycast
            RaycastHit2D hit = Physics2D.Raycast(start, Vector2.right * facingDir, CheckWolfDistance, whatIsWolf);

            // Debugging: Visualize the raycast in the Scene view
            Debug.DrawRay(start, Vector2.right * facingDir * CheckWolfDistance, Color.red);

            // Check if the ray hit something on the "whatIsWolf" layer
            if (hit.collider != null)
            {
                isWolfDetected = true;
                break; // Exit the loop early if a wolf is detected
            }
        }
        return isWolfDetected;
    }
    #endregion


}

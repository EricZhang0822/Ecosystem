using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using UnityEngine;

public class Wolf: MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public SpriteRenderer sr { get; private set; }

    public Sprite run;
    public Sprite walk;

    #region facing variables
    protected bool facingLeft = true; //wolf first faces to the left
    public int facingDir { get; private set; } = -1;

    public static Wolf wolf_reference { get; private set; }
    public int EatSheepNum = 0;
    public bool satisfied = false;
    #endregion

    private float findSheep = 0f;

    private GameObject sheep;


    public Transform sheep_pos;

    #region States 
    //declare all the states here.
    public WolfStateMachine stateMachine { get; private set; }
    public WolfIdleState idleState { get; private set; }
    public WolfStealthState stealthState { get; private set; }
    public WolfAttackState attackState { get; private set; }
    public WolfEatingState eatingState { get; private set; }
    public WolfAwayState awayState { get; private set; }
    #endregion


    void Awake()
    {
        wolf_reference = this;
        stateMachine = new WolfStateMachine();

        stealthState = new WolfStealthState(this, stateMachine);

        attackState = new WolfAttackState(this, stateMachine);

        awayState = new WolfAwayState(this, stateMachine);

        eatingState = new WolfEatingState(this, stateMachine);

        idleState = new WolfIdleState(this, stateMachine);//the two things that need to be changed are: the name of the state: PlayerIdleState to idleState, animBoolName to "Idle".
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EatSheepNum);
        
        findSheep -= Time.deltaTime;
        stateMachine.currentState.Update();


        FlipController(rb.velocity.x);


        if (Manager.reference.targets.Count != 0)
        {
            if (findSheep <= 0)
            {
                sheep = FindClosestTarget(Manager.reference.targets);
                findSheep = .5f;
            }

        }
        else
        {
            return;
        }

        if (EatSheepNum >= 3)
        {
            satisfied = true;
            Component.Destroy(GetComponent<WolfAttackDetect>());
            EatSheepNum = 0;
            ChangeToAwayState();
        }


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
        if (_x <= 0 && !facingLeft)
        {
            Flip();
            facingLeft = true;
        } else if (_x > 0 && facingLeft)
        {
            Flip();
            facingLeft= false;
        }
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

    public GameObject FindClosestTarget(List<GameObject> objects)
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(obj.transform.position, currentPosition);
            if (distance < minDistance)
            {
                closest = obj;
                minDistance = distance;
            }
        }

        return closest;
    }

    public void ChangeToEatState()
    {
        stateMachine.ChangeState(eatingState);
        Debug.Log("changed");
    }

    private void ChangeToAwayState()
    {
        stateMachine.ChangeState(awayState);
    }
}

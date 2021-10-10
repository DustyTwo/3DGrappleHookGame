using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Constants
    public const string GRAPPLEABLE_OBJECT_TAG = "Grappleable Object";

    #endregion

    #region State machine variables
    public StateMachine<PlayerController> stateMachine;

    public PlayerIdleState playerIdleState;
    public PlayerRunningState playerRunningState;
    public PlayerSkiddingState playerSkiddingState;
    public PlayerJumpingState playerJumpingState;
    public PlayerFallingState playerFallingState;
    public PlayerGrappledState playerGrappledState;
    #endregion

    #region Ground check variables
    [Header("Ground check variables")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundLayerMask;
    #endregion

    #region Movement variables
    [Header("Movement variables")]
    public float maxRunningSpeed = 10f;
    public float groundedAccelerationSmoothing = 0.05f;
    //public float airborneAccelerationSmoothing = 0.5f;
    public float groundedDeaccelerationSmoothing = 0.9f;

    public float airborneMovementInfluence = 0.5f;
    
    public float maxJumpTime = 1f;
    public float jumpSpeed = 10f;
    public float gravityScale = 10f;
    #endregion

    #region Grapple variables
    [Header("Grapple variables")]
    public float grappleRange;
    public float maxGrappleTime;

    public LayerMask grappleLayerMask;

    [Range(0.01f,1)] public float grappleJointMaxDistance;
    [Range(0.01f, 1)] public float grappleJointMinDistance;
    [Range(0.01f, 10)] public float grappleJointSpring;
    [Range(0.01f, 10)] public float grappleJointDamper;
    [Range(0.01f, 10)] public float grappleJointMassScale;

    #endregion

    #region Dålda variabler
    [HideInInspector] public Vector3 targetVelocity;
    [HideInInspector] public Vector3 zeroVector = Vector3.zero;
    [HideInInspector] public Vector2 zeroVector2 = Vector2.zero;

    [HideInInspector] public PlayerInputController playerInput;

    [HideInInspector] public Rigidbody rigidbody;

    [HideInInspector] public GameObject currentGrappleObject;
    [HideInInspector] public Vector3 currentGrappleObjectHitPosition;
    [HideInInspector] public Transform cameraTransform;
    [HideInInspector] public GrappleGun grappleGun;
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Awake()
    {
        #region State machine instantiation
        stateMachine = new StateMachine<PlayerController>(this);

        playerIdleState = new PlayerIdleState();
        playerRunningState = new PlayerRunningState();
        playerSkiddingState = new PlayerSkiddingState();
        playerJumpingState = new PlayerJumpingState();
        playerFallingState = new PlayerFallingState();
        playerGrappledState = new PlayerGrappledState();

        stateMachine.ChangeState(playerIdleState);
        #endregion

        playerInput = new PlayerInputController();
        rigidbody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        grappleGun = GetComponentInChildren<GrappleGun>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        stateMachine.Update();

        Debug.DrawRay(transform.position, rigidbody.velocity, Color.blue, Time.deltaTime);
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    //OLD
    //public void AirborneMovement()
    //{
    //    //tar in spelar input som en vector 3 för att kunna konvärtera den till local space rätt
    //    Vector3 playerMovementInput = new Vector3(playerInput.Grounded.Strafe.ReadValue<float>(), 0f, playerInput.Grounded.Run.ReadValue<float>());
    //    playerMovementInput = transform.rotation * playerMovementInput.normalized * maxRunningSpeed;

    //    //gör om input till vector 2 flr att kunna smoothDampa med spelarens X/Z hastighet utan att påvärka Y 
    //    Vector2 playerMovementInput2D = new Vector2(playerMovementInput.x, playerMovementInput.z);
    //    Vector2 targetVelocityXZ = Vector2.SmoothDamp(new Vector2(rigidbody.velocity.x, rigidbody.velocity.z), playerMovementInput2D, ref zeroVector2, airborneAccelerationSmoothing);

    //    //ändrar bara X och Z hastigheten
    //    rigidbody.velocity = new Vector3(targetVelocityXZ.x, rigidbody.velocity.y, targetVelocityXZ.y);
    //}
    
    public void AirborneMovement()
    {
        //tar in spelar input som en vector 3 för att kunna konvärtera den till local space rätt
        Vector3 playerMovementInput = new Vector3(playerInput.Grounded.Strafe.ReadValue<float>(), 0f, playerInput.Grounded.Run.ReadValue<float>());
        playerMovementInput = transform.rotation * playerMovementInput.normalized;


        rigidbody.velocity += playerMovementInput * airborneMovementInfluence;

        ////gör om input till vector 2 för att kunna smoothDampa med spelarens X/Z hastighet utan att påvärka Y 
        //Vector2 playerMovementInput2D = new Vector2(playerMovementInput.x, playerMovementInput.z);
        //Vector2 targetVelocityXZ = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z) + playerMovementInput2D * airborneMovementInfluence;

        ////ändrar bara X och Z hastigheten
        //rigidbody.velocity = new Vector3(targetVelocityXZ.x, rigidbody.velocity.y, targetVelocityXZ.y);
    }

    public bool ShootGrappleHook()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, grappleRange, grappleLayerMask) && hit.transform.gameObject.CompareTag(GRAPPLEABLE_OBJECT_TAG))
        {
            currentGrappleObject = hit.transform.gameObject;
            currentGrappleObjectHitPosition = hit.point;
            return true;
        }
        return false;
    }
}

public class PlayerIdleState : State<PlayerController>
{
    public override void EnterState(PlayerController owner)
    {
        Debug.Log("idle");
    }

    public override void ExitState(PlayerController owner)
    { }

    public override void FixedUpdateState(PlayerController owner)
    {

    }

    public override void UpdateState(PlayerController owner)
    {
        #region State transition checks

        Vector2 playerMovementInput = new Vector2(owner.playerInput.Grounded.Strafe.ReadValue<float>(), owner.playerInput.Grounded.Run.ReadValue<float>());

        if(playerMovementInput.magnitude > 0.001f)
        {
            owner.stateMachine.ChangeState(owner.playerRunningState);
        }
        else if(owner.playerInput.Grounded.Jump.ReadValue<float>() > 0.5f)
        {
            owner.stateMachine.ChangeState(owner.playerJumpingState);
        }
        else if (!Physics.CheckSphere(owner.groundCheck.position, owner.groundCheckRadius, owner.groundLayerMask))
        {
            owner.stateMachine.ChangeState(owner.playerFallingState);
        }
        else if(owner.playerInput.Grounded.Grapple.triggered && owner.ShootGrappleHook())
        {
            owner.stateMachine.ChangeState(owner.playerGrappledState);
        }
        #endregion
    }
}

public class PlayerRunningState : State<PlayerController>
{
    Vector3 playerMovementInput = Vector3.zero;

    public override void EnterState(PlayerController owner)
    {
        Debug.Log("running");
    }

    public override void ExitState(PlayerController owner)
    {

    }

    public override void FixedUpdateState(PlayerController owner)
    {
        #region Movement
        owner.targetVelocity = owner.transform.rotation * playerMovementInput * owner.maxRunningSpeed;

        //Debug.DrawRay(owner.transform.position, owner.targetVelocity, Color.green, Time.fixedDeltaTime);

        owner.rigidbody.velocity = Vector3.SmoothDamp(owner.rigidbody.velocity, owner.targetVelocity, ref owner.zeroVector, owner.groundedAccelerationSmoothing);

        //vet inte varför jag har denna movement här också? antagligen för debug, om jag tar bort den så uppstår ett bugg TODO fixa bugget
        Vector3 playerMovementInputDirection = owner.transform.rotation * playerMovementInput;
        owner.rigidbody.velocity = playerMovementInputDirection.normalized * owner.maxRunningSpeed;
        #endregion
    }

    public override void UpdateState(PlayerController owner)
    {
        playerMovementInput = new Vector3(owner.playerInput.Grounded.Strafe.ReadValue<float>(), 0f, owner.playerInput.Grounded.Run.ReadValue<float>());


        #region State transition checks
        //om spelaren slutar ge input att springa, byt till skidding state
        if (playerMovementInput.magnitude < 0.001f)
        {
            owner.stateMachine.ChangeState(owner.playerSkiddingState);
        }
        //TODO fixa så att hopp inputen sköts på ett snyggare sätt
        //om spelaren ger input för att hoppa, byt till jumping state
        else if (owner.playerInput.Grounded.Jump.ReadValue<float>() > 0.5f)
        {
            owner.stateMachine.ChangeState(owner.playerJumpingState);
        }
        //om spelaren inte står på mark, byt till falling state
        else if(!Physics.CheckSphere(owner.groundCheck.position, owner.groundCheckRadius, owner.groundLayerMask))
        {
            owner.stateMachine.ChangeState(owner.playerFallingState);
        }
        #endregion
    }
}

public class PlayerSkiddingState : State<PlayerController>
{
    const float MINIMUM_SPEED = 1f;
    public override void EnterState(PlayerController owner)
    {
        Debug.Log("skidding");
    }

    public override void ExitState(PlayerController owner)
    {

    }
    public override void FixedUpdateState(PlayerController owner)
    {
        owner.rigidbody.velocity = Vector3.SmoothDamp(owner.rigidbody.velocity, Vector3.zero, ref owner.zeroVector, owner.groundedDeaccelerationSmoothing);
    }

    public override void UpdateState(PlayerController owner)
    {


        #region State transition checks
        Vector2 playerMovementInput = new Vector2(owner.playerInput.Grounded.Strafe.ReadValue<float>(), owner.playerInput.Grounded.Run.ReadValue<float>());
        //om spelaren ger input för att springa, byt till running state
        if (playerMovementInput.magnitude > 0.001f)
        {
            owner.stateMachine.ChangeState(owner.playerRunningState);
        }
        //om spelaren ger input för att hoppa, byt till jumping state
        else if (owner.playerInput.Grounded.Jump.ReadValue<float>() > 0.5f)
        {
            owner.stateMachine.ChangeState(owner.playerJumpingState);
        }
        //om spelaren inte står på mark, byt till falling state
        else if (!Physics.CheckSphere(owner.groundCheck.position, owner.groundCheckRadius, owner.groundLayerMask))
        {
            owner.stateMachine.ChangeState(owner.playerFallingState);
        }
        else if(owner.rigidbody.velocity.magnitude < MINIMUM_SPEED)
        {
            owner.rigidbody.velocity = Vector3.zero;
            owner.stateMachine.ChangeState(owner.playerIdleState);
        }
        #endregion
    }
}

public class PlayerJumpingState : State<PlayerController>
{
    Timer jumpTimer;

    public override void EnterState(PlayerController owner)
    {
        Debug.Log("jumping");
        //Debug.LogWarning("jump");
        jumpTimer = new Timer(owner.maxJumpTime);
    }

    public override void ExitState(PlayerController owner)
    { }

    public override void FixedUpdateState(PlayerController owner)
    {
        owner.AirborneMovement();

        //jump
        owner.rigidbody.velocity = new Vector3(owner.rigidbody.velocity.x, owner.jumpSpeed, owner.rigidbody.velocity.z);
    }

    public override void UpdateState(PlayerController owner)
    {
        #region State transition checks
        jumpTimer += Time.deltaTime;

        if(jumpTimer.Done || owner.playerInput.Grounded.Jump.ReadValue<float>() < 0.5f)
        {
            owner.stateMachine.ChangeState(owner.playerFallingState);
        }
        #endregion
    }
}
public class PlayerFallingState : State<PlayerController>
{

    public override void EnterState(PlayerController owner)
    {
        Debug.Log("falling");
        //Debug.Break();
    }

    public override void ExitState(PlayerController owner)
    { }

    public override void FixedUpdateState(PlayerController owner)
    {
        owner.AirborneMovement();

        #region Gravity
        owner.rigidbody.velocity += new Vector3(0, -owner.gravityScale, 0);
        //owner.rb.velocity = new Vector3(owner.rb.velocity.x, Mathf.Clamp(owner.rb.velocity.y, -owner.terminalVelocity, Mathf.Infinity), 0);
        #endregion
    }

    public override void UpdateState(PlayerController owner)
    {
        #region State transition checks

        if (Physics.CheckSphere(owner.groundCheck.position, owner.groundCheckRadius, owner.groundLayerMask))
        {
            owner.stateMachine.ChangeState(owner.playerSkiddingState);
        }
        else if (owner.playerInput.Grounded.Grapple.triggered && owner.ShootGrappleHook())
        {
            owner.stateMachine.ChangeState(owner.playerGrappledState);
        }
        #endregion
    }
}
public class PlayerGrappledState : State<PlayerController>
{
    Timer grappleTimer;
    SpringJoint grappleJoint;
    float distanceToHitPosition;
    public override void EnterState(PlayerController owner)
    {
        Debug.Log("grappled");

        //lägga till en liten reel in precis när man grapplear?

        grappleTimer = new Timer(owner.maxGrappleTime);
        owner.grappleGun.EnableGrapple(owner.currentGrappleObjectHitPosition);

        grappleJoint = owner.gameObject.AddComponent<SpringJoint>();
        grappleJoint.autoConfigureConnectedAnchor = false;
        grappleJoint.connectedAnchor = owner.currentGrappleObjectHitPosition;

        distanceToHitPosition = Vector3.Distance(owner.gameObject.transform.position, owner.currentGrappleObjectHitPosition);

        grappleJoint.maxDistance = distanceToHitPosition * owner.grappleJointMaxDistance;
        grappleJoint.minDistance = distanceToHitPosition * owner.grappleJointMinDistance;

        grappleJoint.spring = owner.grappleJointSpring;
        grappleJoint.damper = owner.grappleJointDamper;
        grappleJoint.massScale = owner.grappleJointMassScale;

    }

    public override void ExitState(PlayerController owner)
    {
        owner.grappleGun.DisableGrapple();
        Object.Destroy(grappleJoint);
        //ge en liten speedboost när man släpper grapplen? (baserat på grapple time?) (baserat på distansskillnaden mellan där man är när man släpper och där man grappleade kanske i rellation till hur långt repet är)
        //TODO fixa
        owner.rigidbody.velocity *= 1.25f;
    }

    public override void FixedUpdateState(PlayerController owner)
    {
        //player influence


        //reel in?


        //gravity
        owner.rigidbody.velocity += new Vector3(0, -owner.gravityScale, 0);
    }

    public override void UpdateState(PlayerController owner)
    {
        //grappleTimer += Time.deltaTime;

        //Debug.Log(owner.rigidbody.velocity.magnitude);
        Debug.Log(distanceToHitPosition - Vector3.Distance(owner.gameObject.transform.position, owner.currentGrappleObjectHitPosition));

        #region State transition checks
        if (owner.playerInput.Grounded.Grapple.ReadValue<float>() < 0.5f || grappleTimer.Done)
        {
            owner.stateMachine.ChangeState(owner.playerFallingState);
        }
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Collider Components")]
    [Tooltip("The feet of the player")]
    public GameObject feet;

    [Header("Movement")]
    [Tooltip("How fast the player moves")]
    public float moveSpeed = 5f;

    //Jumping Variables
    [Header("Jumping")]

    [Tooltip("How strong the jump is")]
    public float jumpForce = 5f;

    /*[Tooltip("How long of a buffer to give the player to queue another jump (Seconds)")]
    public float jumpBufferLength = 0.1f;*/
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    [Tooltip("How long to give the player after walking of an edge to jump (Seconds)")]
    public float hangTime = 0.2f;
    private float hangCounter;


    [Header("Audio clips")]
    public AudioClip footstepsSound;
    [Range(0f,1f)]
    public float footstepsSoundVolume = 0.5f;

    public AudioClip jumpSound;
    [Range(0f, 1f)]
    public float jumpSoundVolume = 0.5f;

    public AudioClip fallSound;
    [Range(0f, 1f)]
    public float fallSoundVolume = 0.5f;

    private AudioSource audioSource;


    private Rigidbody2D playerRB;
    private PlayerGrounded playerGrounded;

    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    //private bool isRunning = false;
    private bool isFalling = false;
    private bool isGoingUp = false;
    private int successfullyJumped = 0;
    private float velocity;
    private float lastVelocity;
    private Vector2 acceleration;
    private Vector2 lastAcceleration;


    //GamePad Controls
    PlayerInput gamepadControls;
    Vector2 move;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerGrounded = feet.GetComponent<PlayerGrounded>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        gamepadControls = GetComponent<PlayerInput>();

        gamepadControls.actions["Jump"].performed += ctx => Jump();
        gamepadControls.actions["Jump"].canceled += ctx => isJumping = false;

        gamepadControls.actions["Movement"].performed += ctx => move = ctx.ReadValue<Vector2>();
        gamepadControls.actions["Movement"].canceled += ctx => move = Vector2.zero;

        
    }


    void Start()        
    {
       
        velocity = 0f;
        lastVelocity = 0f;
        acceleration = Vector2.zero;
        //isRunning = false;
    }

    void Update()
    {


        if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        //Jump();
        

        CreateHangTime();

        ControlsEnableGroundCheck();

        //Debug.Log(jumpTimeCounter);

        //if (isRunning & playerGrounded.isGrounded() & (audioSource.clip != footstepsSound))
        //{
        //    audioSource.loop = true;
        //    audioSource.clip = footstepsSound;
        //    audioSource.volume = footstepsSoundVolume;
        //    audioSource.Play(); 
        //}
        //else
        //{
        //    if (audioSource.clip = footstepsSound)
        //    {
        //        audioSource.Stop();
        //    }
        //}
    }

    
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(move.x * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerRB.velocity.x));
        if (playerRB.velocity.x > 0.01)
        {
            //isRunning = true;
        }
        else
        {
            //isRunning = false;
        }


        velocity = playerRB.velocity.y;        
        if (Mathf.Abs(velocity - lastVelocity) < 0.01f)
        {
            isGoingUp = false;
            isFalling = false;
        }
        else if (velocity > lastVelocity)
        {
            //accel
            isGoingUp = true;
            isFalling = false;
        }
        else
        {
            //decel
            isGoingUp = false;
            isFalling = true;
        }

        if (playerGrounded.isGrounded())
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", false);
            playerAnimator.SetTrigger("Grounded");
        }
        else
        {
            if (isGoingUp && !isFalling)
            {
                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isFalling", false);

            }
            else if(!isGoingUp && isFalling)
            {
                playerAnimator.SetBool("isJumping", false);
                playerAnimator.SetBool("isFalling", true);
            }
        }

        lastAcceleration = acceleration;
        lastVelocity = velocity;

    }

    void Jump()
    {
        if (playerGrounded.isGrounded())
        {
            if (playerRB != null) {
                playerRB.velocity = Vector2.up * jumpForce;
            }
            jumpTimeCounter = jumpTime;
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Jump");
            }
            successfullyJumped++;

            if (audioSource!=null)
            {
                audioSource.loop = false;
                audioSource.clip = jumpSound;
                audioSource.volume = jumpSoundVolume;
                audioSource.time = 0.3f;
                audioSource.Play();
            }
        }

        if(isJumping == true)
        {
            //Debug.Log("Entered IF");
            if (jumpTimeCounter > 0)
            {
                playerRB.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }            
        }
        
    }

    public int SuccessfullyJumped()
    {
        return successfullyJumped;
    }

    void CreateHangTime()
    {
        //Hangtime
        if (playerGrounded.isGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

    }

    void ControlsEnableGroundCheck()
    {
        //For jumping
        if (isJumping == false && !playerGrounded.isGrounded()) //If player is jumping and not grounded
        {
            gamepadControls.actions["Jump"].Disable(); //Disable jumping while in mid air
            isJumping = true;
        }
        else if (playerGrounded.isGrounded())
        {
            gamepadControls.actions["Jump"].Enable(); //Re-Enable jumping while in mid air
            isJumping = false;
        }
    }

    private void OnEnable()
    {
        gamepadControls.actions.Enable();
    }

    private void OnDisable()
    {
        if (gamepadControls != null)
        {
            gamepadControls.actions.Disable();
        }
    }

}

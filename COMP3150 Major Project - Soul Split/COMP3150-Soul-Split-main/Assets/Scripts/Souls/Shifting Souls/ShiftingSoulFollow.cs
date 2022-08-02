using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingSoulFollow : MonoBehaviour
{

    //Shifting Soul Variables
    [Header("Shifting Soul Settings")]
    public float ghostDelay = 5f;
    [HideInInspector]
    public bool shiftingSoul = true;

    private bool follow = false;
    private float followTime = 0f;
    private List<Vector3> playerTrail = new List<Vector3>();
    private List<int> playerJumps = new List<int>();

    [Header("Collider Components")]
    [Tooltip("The feet of the soul")]
    public GameObject feet;

    private GameObject player;
    private Rigidbody2D playerRB;
    private SoulGrounded soulGrounded;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    private bool isRunning = false;
    private bool isFalling = false;
    private bool isGoingUp = false;
    private float YVelocity;
    private float lastYVelocity;
    private Vector2 position;
    private Vector2 lastPosition;
    private Vector2 acceleration;
    private Vector2 lastAcceleration;
    private int currentJumps;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = GetComponent<Rigidbody2D>();
        soulGrounded = feet.GetComponent<SoulGrounded>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        YVelocity = 0f;
        lastYVelocity = 0f;
        acceleration = Vector2.zero;
        lastAcceleration = Vector2.zero;
        position = transform.position;
        lastPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        SoulFollow();
    }

    void FixedUpdate()
    {
        playerJumps.Add(playerMovement.SuccessfullyJumped());
        if (follow)
        {
            position = transform.position;
            YVelocity = (Mathf.Abs(position.y - lastPosition.y)) / Time.deltaTime;

            if (Mathf.Abs(position.x - lastPosition.x) > 0.01f)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
            playerAnimator.SetBool("isRunning", isRunning);

            if (follow)
            {
                if (position.x >= lastPosition.x)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
            
            if (currentJumps < playerJumps[0])
            {
                playerAnimator.SetTrigger("Jump");
                currentJumps++;
            }
            playerJumps.RemoveAt(0);

            if (Mathf.Abs(YVelocity - lastYVelocity) < 0.01f)
            {
                isGoingUp = false;
                isFalling = false;
            }
            else if (YVelocity > lastYVelocity)
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

            if (soulGrounded.isGrounded())
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
                else if (!isGoingUp && isFalling)
                {
                    playerAnimator.SetBool("isJumping", false);
                    playerAnimator.SetBool("isFalling", true);
                }

            }

            lastPosition = position;
            lastYVelocity = YVelocity;
            lastAcceleration = acceleration;
        }
    }

    void SoulFollow()
    {
        //Soul Follow
        if (shiftingSoul) //if it's a Shifting Soul, track movement and follow
        {
            playerTrail.Add(player.transform.position);
            if (!follow)
            {
                followTime += Time.deltaTime;

                if (followTime >= ghostDelay) //delay
                {
                    follow = true;
                    position = transform.position;
                    lastPosition = position;
                    lastYVelocity = YVelocity;
                    lastAcceleration = acceleration;
                }
            }
            else
            {
                transform.position = playerTrail[0];
                playerTrail.RemoveAt(0);
            }

        }
    }
}

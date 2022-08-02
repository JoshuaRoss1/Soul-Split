using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SoulSpawning : MonoBehaviour
{
    [Header("Soul Types")]
    public GameObject shiftingSoul;
    public GameObject stillSoul;
    public GameObject projectedSoul;
    private int soulLimit;

    //Soul Pool and Toggling
    [HideInInspector]
    public List<GameObject> souls = new List<GameObject>();
    [HideInInspector]
    public int toggleCount = 1;

    //Still Soul Variables
    private bool isStillSoul = false;
    private Rigidbody2D stillRB;
    private bool stillSoulSpawned;

    //Shifting Soul Variables
    [HideInInspector]
    public bool isShiftingSoul;

    //Projected Soul Variables
    [Header("Projected Soul Settings")]
    public float projectionSpeed = 5f;
    public float projectedSoulSpawnThreshold = 1f;
    
    public GameObject aimPointer;
    private SpriteRenderer aimPointerSprite;
    private AudioSource aimPointerAudioSource;

    //private bool isProjectedSoul;
    private bool projectedSpawned = false;
    private Rigidbody2D projectedRB;
    private GameObject projectedSoulFeet;
    private GameObject stillSoulFeet;
    private float projectedSoulSpawnBuffer = 0f;

    [Header("Soul Cap Sound Effect")]
    public AudioClip soulCapSound;

    //Keybinds
    [Header("Soul Spawning Keybinds")]
    public KeyCode spawnShiftingSoul;
    public KeyCode spawnStillSoul;
    public KeyCode projectSoulHold;
    PlayerInput gamepadControls;

    //Soul Grounding
    private SoulGrounded projectedSoulGrounded;
    private SoulGrounded stillSoulGrounded;

    //Color Variables
    [HideInInspector]
    public float alpha = 0.5f;

    private void Awake()
    {
        Setup();
        gamepadControls = GetComponent<PlayerInput>();

        gamepadControls.actions["ShiftingSoul"].started += ctx => ShiftingSoul();

        gamepadControls.actions["StillSoul"].started += ctx => StillSoul();

        gamepadControls.actions["ProjectSoul"].started += ctx => ProjectedSoulAimOn();
        gamepadControls.actions["ProjectSoul"].canceled += ctx => ProjectedSoulAimOff();
        gamepadControls.actions["ProjectSoul"].canceled += ctx => ProjectedSoulThrow();

        gamepadControls.actions["ToggleSoul"].started += ctx => ToggleActiveSoul();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the projected soul is grounded. 
        //IF statements are needed to deal with NullPointer Errors when tryning to access a rigidbody of a soul type that hasn't been spawned yet.
        if (projectedSpawned)
        {
            ProjectedSoulGroundCheck(projectedRB);
        }

        //Check if still soul is grounded
        if (stillSoulSpawned)
        {
            StillSoulGroundCheck(stillRB);
        }
        
      
    }

    bool SoulsRemaining()
    {
        if(souls.Count < soulLimit)
        {
            return true;
        }
        else
        {
            GameObject quack = new GameObject("QUACK");
            if (this != null)
            {
                quack.transform.parent = this.transform;
                AudioSource quackSource = quack.AddComponent<AudioSource>();
                quackSource.clip = soulCapSound;
                quackSource.Play();
                if (quack != null)
                {
                    Destroy(quack.gameObject, 0.5f);
                }
            }
            return false;
        }
    }


    //Soul Types
    void ShiftingSoul()
    {
        //Debug.Log("This is working");
        if (SoulsRemaining() && this!=null)
        {
            GameObject newShiftingSoul = (Instantiate(shiftingSoul, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity)); //Spawn at the point of the player
            newShiftingSoul.GetComponent<ShiftingSoulFollow>().shiftingSoul = true;

            souls.Add(newShiftingSoul); //Add soul to the soul pool
            ActiveSoul(souls.Count); //Set the active soul to the newest soul
        }
    }

    void StillSoul()
    {
        if (SoulsRemaining() && this != null)
        {
            isStillSoul = true; //Set soul type to still soul
            projectedSoulSpawnBuffer += Time.deltaTime; //Increase timer until swap to projected soul

            //Timer to swap to projected soul
            if (projectedSoulSpawnBuffer >= projectedSoulSpawnThreshold / 2)
            {
                isStillSoul = false; //Disable still soul type
                                     //isProjectedSoul = true; //Swap soul type to projected soul


            }

            if (isStillSoul)
            {
                GameObject newStillSoul = (Instantiate(stillSoul, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity)); //Spawn at the point of the player

                stillRB = newStillSoul.GetComponent<Rigidbody2D>();
                stillSoulFeet = newStillSoul.GetComponent<Soul>().soulFeet;

                stillSoulGrounded = stillSoulFeet.GetComponent<SoulGrounded>();
                stillSoulSpawned = true;

                souls.Add(newStillSoul);
                isStillSoul = false;
                projectedSoulSpawnBuffer = 0f;
                ActiveSoul(souls.Count);

            }
        }
    }

    void ProjectedSoulAimOn()
    {
        if (aimPointerSprite != null)
        {
            aimPointerSprite.enabled = true; //Enable the pointer sprite
        }
    }

    void ProjectedSoulAimOff()
    {
        if (aimPointerSprite != null)
        {
            aimPointerSprite.enabled = false; //Disable the pointer sprite
        }
    }
    
    void ProjectedSoulThrow()
    {
        if (SoulsRemaining() && this != null)
        {
            if (this != null)
            {
                GameObject newProjectedSoul;

                DirectionalPointer pointer = GameObject.Find("Pointer").GetComponent<DirectionalPointer>();
                Vector2 arrowDir = pointer.direction;

                //Vector3 projDirection = Camera.main.ScreenToWorldPoint(arrowDir) - transform.position; //Get projection direction (Towards Mouse)

                //Spawn the soul
                newProjectedSoul = (Instantiate(projectedSoul, transform.position, Quaternion.identity));

                //Rigidbody of Projected Soul
                projectedRB = newProjectedSoul.GetComponent<Rigidbody2D>();

                //Get feet component of soul
                projectedSoulFeet = newProjectedSoul.GetComponent<Soul>().soulFeet;

                //Throw soul in the direction of the arrow
                projectedRB.AddForce(arrowDir.normalized * projectionSpeed, ForceMode2D.Impulse); //Throw the soul forward 

                //Check if the soul is Grounded and change rigidbody to Kinematic to make it static
                projectedSoulGrounded = projectedSoulFeet.GetComponent<SoulGrounded>();

                //Set bool for spawning
                projectedSpawned = true;

                projectedSoulSpawnBuffer = 0f; //Reset Buffer Timer
                aimPointerSprite.enabled = false; //Disable aiming pointer
                                                  //isProjectedSoul = false; //Reset soul type back to default
                souls.Add(newProjectedSoul);
                ActiveSoul(souls.Count);
                aimPointerAudioSource.Play();
            }
        }
    }

    //Miscellaneous soul properties
    void ProjectedSoulGroundCheck(Rigidbody2D projectedRB)
    {
        //if (projectedSoulGrounded.isGrounded())
        //{
        //    projectedRB.bodyType = RigidbodyType2D.Kinematic;
        //    projectedRB.constraints = RigidbodyConstraints2D.FreezePositionX & RigidbodyConstraints2D.FreezeRotation;
        //    projectedRB.velocity = Vector3.zero;
        //    projectedRB.angularVelocity = 0;
        //    projectedRB.Sleep();
        //}
    }

    void StillSoulGroundCheck(Rigidbody2D projectedRB)
    {
        //if (stillSoulGrounded.isGrounded())
        //{
        //    stillRB.bodyType = RigidbodyType2D.Kinematic;
        //    stillRB.constraints = RigidbodyConstraints2D.FreezePositionX;
        //    stillRB.velocity = Vector3.zero;
        //    stillRB.angularVelocity = 0;
        //    stillRB.Sleep();
        //}
    }

    //Soul Activating 
    public void ActiveSoul(int n)
    {
        if (souls.Count > 0 && n <= souls.Count) //check range
        {
            for (int i = 0; i < souls.Count; i++)
            {
                if (i == n - 1) //activates the specified soul, deactivates the rest
                {
                    souls[i].GetComponent<Soul>().ActivateSoulParticles();
                    GetComponent<PlayerAbiltities>().currentActiveSoulIndex = i;
                }
                else
                {
                    souls[i].GetComponent<Soul>().DeactivateSoulParticles();
                }
            }
        }

        PlayerAbiltities materialise = GetComponent<PlayerAbiltities>();
        if(materialise.materialising == true)
        {
            materialise.SoulMaterialiseOff();
        }
        
    }

    void ToggleActiveSoul()
    {
        int soulCount = souls.Count;
        if(toggleCount > soulCount)
        {
            toggleCount = 1;
        }

        ActiveSoul(toggleCount);
        toggleCount++;
    }

    //Setup
    void Setup()
    {
        aimPointerSprite = aimPointer.GetComponent<SpriteRenderer>();
        aimPointerSprite.enabled = false; //Hide aiming pointer
        aimPointerAudioSource = aimPointer.GetComponent<AudioSource>();
    }

    public void SetSoulLimit(int n)
    {
        soulLimit = n;
        //Debug.Log(soulLimit);
    }

    private void OnEnable()
    {
        gamepadControls.actions.Enable();
    }

    private void OnDisable()
    {
        if(gamepadControls != null)
        {
            gamepadControls.actions.Disable();
        }
    }
}

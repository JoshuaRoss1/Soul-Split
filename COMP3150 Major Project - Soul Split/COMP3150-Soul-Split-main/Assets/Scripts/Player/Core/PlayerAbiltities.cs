using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAbiltities : MonoBehaviour
{


    [Header("Ability Toggles")]
    public bool enableSoulSwap;
    public bool enableSoulMaterialise;
    public bool enableSoulAbsorb;


    [Header("Properties for Soul Swap")]
    [Tooltip("How long of a cooldown there is between the uses of the Soul Swap ability")]
    public float swapCooldown = 10;

    private bool rewindAvailable = true;

    [Header("Properties for Soul Materialise")]
    [HideInInspector]
    public bool materialising = false;

    [Header("Ability Keybinds")]    //Defaults
    public KeyCode soulSwap = KeyCode.R;
    public KeyCode soulMaterialise = KeyCode.V;
    public KeyCode soulAbsorb = KeyCode.F;

    //GameObject Variables
    private GameObject player;
    private GameObject activeSoul;

    //Soul component variables
    private SoulSpawning soulList;
    private SpriteRenderer sprite;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    private ParticleSystem particles;
    private Color soulColor;

    //Controller Variables
    PlayerInput gamepadControls;

    //Other Variables
    [HideInInspector]
    public int currentActiveSoulIndex;
    private int soulCollideEnable = 13; //Reference to Soul Collider layer (Layer 13 --> Materialised)
    private int soulCollideDisable = 11; //Reference to Soul layer (Layer 11)

    private void Awake()
    {
        gamepadControls = GetComponent<PlayerInput>();
        Setup();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get current active soul GameObject if list contains souls
        if(soulList.souls.Count > 0)
        {
            activeSoul = GetActiveSoul(currentActiveSoulIndex);
        }
      
        if(activeSoul != null)
        {
            if (enableSoulAbsorb)
            {
                gamepadControls.actions["SoulAbsorb"].performed += cxt => SoulAbsorb();

            }
            if (enableSoulMaterialise)
            {
                gamepadControls.actions["SoulMaterialise"].performed += cxt => materialising = true;
                gamepadControls.actions["SoulMaterialise"].performed += cxt => SoulMaterialiseOn();
                gamepadControls.actions["SoulMaterialise"].canceled += cxt => SoulMaterialiseOff();
            }
            if (enableSoulSwap)
            {
                gamepadControls.actions["SoulSwap"].performed += cxt => SoulSwap();
            }
        }


    }



    //Initial setup of script -> Get object components and set variables etc. (Will go in start function)
    void Setup()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        particles = GetComponent<ParticleSystem>();
        
        player = GameObject.Find("Player");
        soulList = player.GetComponent<SoulSpawning>();

    }

   

    void SoulSwap()
    {
        if (soulList.souls.Count > 0)
        {
            //Soul Swap
            if (rewindAvailable) //rewind or swap based on Soul type
            {
                if (activeSoul.GetComponent<Soul>().soulType == Soul.selectedSoulType.Shifting && this!=null &&activeSoul!=null)
                {
                    player.transform.position = activeSoul.transform.position; //rewind
                }
                else
                {
                    Vector3 savedPosition = new Vector3(activeSoul.transform.position.x, activeSoul.transform.position.y, activeSoul.transform.position.z); //swap
                    activeSoul.transform.position = player.transform.position;
                    player.transform.position = savedPosition;
                }
            }
        }
    }

    void SoulMaterialiseOn()
    {
        if (soulList.souls.Count > 0)
        {
            materialising = true;
            for (int i = 0; i < soulList.souls.Count; i++)
            {
                if (soulList.souls[i].GetComponent<Soul>().CheckActive() && soulList!=null && this!=null) //find the active soul
                {
                    if (activeSoul != null)
                    {
                        activeSoul.GetComponent<BoxCollider2D>().isTrigger = false;
                        activeSoul.layer = soulCollideEnable;
                        soulList.souls[i].GetComponent<Soul>().alpha = 1f;
                        currentActiveSoulIndex = i; //Store current active soul index
                    }
                }
            }
        }
    }

    public void SoulMaterialiseOff()
    {
        if (soulList.souls.Count > 0)
        {
            materialising = false;
            if (activeSoul != null)
            {
                activeSoul.GetComponent<BoxCollider2D>().isTrigger = true;
                activeSoul.layer = soulCollideDisable;
                activeSoul.GetComponent<Soul>().alpha = 0.5f;
            }
        }
    }

    void SoulAbsorb()
    {
        if (soulList.souls.Count > 0)
        {
            if (activeSoul != null)
            {
                soulList.souls.Remove(activeSoul); //remove from list
                Destroy(activeSoul); //destroy gameobject
            }
            if (soulList.souls.Count > 0) //if the list still has items
            {
                soulList.ActiveSoul(soulList.souls.Count);
            }
        }
    }

    //Get Functions
    GameObject GetActiveSoul(int index)
    {
        return soulList.souls[index].gameObject;
    }

    private void OnEnable()
    {
        gamepadControls.actions.Enable();
    }

    private void OnDisable()
    {
        gamepadControls.actions.Disable();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
/*
 * Refactored By Joshua Ross - 11:30pm September 9, 2021
 * 
 * This script defines a 'Soul'
 */


    //All types of available Souls
    public enum selectedSoulType
    {
        Shifting,
        Still,
        Projected
    }

    [Header("Soul Properties")]
    public selectedSoulType soulType;
    [Tooltip("The feet component of the Soul the script is being placed on")]
    public GameObject soulFeet;
    [Tooltip("The colour of this Soul")]
    public Color ghostColour;

    //GameObject Variables
    private GameObject player;

    //Soul component variables
    private SoulSpawning soulList;
    private SpriteRenderer sprite;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    private ParticleSystem particles;
    private SoulGrounded soulGrounded;

    //Other Variables    
    [HideInInspector]
    public float alpha = 0.9f; //Default alpha
    private bool activeSoul = false;

    public PhysicsMaterial2D bouncyForProjected;



    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }


    //Initial setup of script -> Get object components and set variables etc. (Will go in start function)
    void Setup()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(ghostColour.r, ghostColour.g, ghostColour.b, alpha);
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        particles = GetComponent<ParticleSystem>();
        player = GameObject.Find("Player");
        soulList = player.GetComponent<SoulSpawning>();
        soulGrounded = soulFeet.GetComponent<SoulGrounded>();
    }

    void Update()
    {
        
        if (soulType == selectedSoulType.Shifting)
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        sprite.color = new Color(ghostColour.r, ghostColour.g, ghostColour.b, alpha);
        if (soulType == selectedSoulType.Projected || soulType == selectedSoulType.Still)
        {
            if (soulGrounded.isGrounded())
            {
                rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
                rigidbody2d.velocity = Vector3.zero;
                rigidbody2d.angularVelocity = 0;
                rigidbody2d.Sleep();
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }


    //Soul Particle Activation on Soul Selection
    public void ActivateSoulParticles()
    {
        activeSoul = true;
        if (particles == null) //for some god knows what reason 'particles' is null when you spawn it in so this is to prevent nullpointer
        {
            particles = GetComponent<ParticleSystem>();
        }
        particles.Play();
    }

    //Soul Particle De-Activation
    public void DeactivateSoulParticles()
    {
        activeSoul = false;
        particles.Stop(); //and somehow this one works perfectly fine
    }

    //Get Active Soul
    public bool CheckActive()
    {
        return activeSoul;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" && soulType == selectedSoulType.Projected)
        {
            this.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = bouncyForProjected;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (soulType == selectedSoulType.Projected)
        {
            this.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = null;
        }
    }
}

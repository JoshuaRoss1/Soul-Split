using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour, InterfaceSubject
{
    
    [Header("Constant uses pressure plate prefab")]
    [Space]
    [Header("Enable respective child object for Toggle/Single")]
    [Tooltip("How the button activates")]
    public TriggerTypes triggerType = TriggerTypes.Constant;


    public enum TriggerTypes
    {
        [Tooltip("Permanent activation on first trigger")]
        Single,
        [Tooltip("Toggles activation every trigger")]
        Toggle,
        [Tooltip("Active only while constantly in trigger")]
        Constant
    }

    [Header("What can trigger me?")]
    public bool souls = true;
    public bool players = true;

    public List<GameObject> targetObstacles = new List<GameObject>();
    private List<InterfaceObserver> observers = new List<InterfaceObserver>();

    public List<GameObject> targetPlatforms = new List<GameObject>();

    [Header("Particle Link Properties")]
    [Tooltip("Child object with ParticleLink script")]
    public GameObject particleLink;
    [Tooltip("Particle speed")]
    public float moveSpeed = 5f;
    [Tooltip("Interval between each pulse")]
    public float interval = 3f;

    [HideInInspector]
    public bool activated = false;
    private SpriteRenderer spriteRenderer;
    private Color baseColour;
    private List<string> tags = new List<string>();


    public void NotifyObservers()
    {
        foreach (InterfaceObserver o in observers)
        {
            o.ReceivedUpdate(this.gameObject);
        }
    }

    public void RegisterObserver(InterfaceObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(InterfaceObserver o)
    {
        observers.RemoveAll(x => x == o);
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        baseColour = spriteRenderer.color;

        foreach (GameObject g in targetObstacles)
        {
            if (g.GetComponent<Obstacles>() != null)
            {
               observers.Add(g.GetComponent<Obstacles>());
                //Debug.Log(g.name + " added as obstacle observer for " + this.gameObject.name);
                GameObject link = Instantiate(particleLink, transform);
                ParticleLink linkData = link.GetComponent<ParticleLink>();
                linkData.source = this.gameObject;
                linkData.target = g;
                linkData.interval = interval;
                linkData.moveSpeed = moveSpeed;
                link.SetActive(true);
            }
            else
            {
                Debug.Log(g.name + " does not have the obstacles script. From " + this.gameObject.name);
            }
        }

        foreach (GameObject g in targetPlatforms)
        {
            if (g.GetComponent<MovementPath>() != null)
            {
                observers.Add(g.GetComponent<MovementPath>());
                //Debug.Log(g.name + " added as movement observer for " + this.gameObject.name);
                GameObject link = Instantiate(particleLink, transform);
                ParticleLink linkData = link.GetComponent<ParticleLink>();
                linkData.source = this.gameObject;
                linkData.target = g;
                linkData.interval = interval;
                linkData.moveSpeed = moveSpeed;
                link.SetActive(true);
            }
            else
            {
                Debug.Log(g.name + " does not have the movement path script. From " + this.gameObject.name);
            }
        }

        if (souls)
        {
            tags.Add("Soul");
        }
        if (players)
        {
            tags.Add("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D c)
    {

        if (triggerType == TriggerTypes.Single)
        {
            if (CheckColliderTag(c.tag))
            {
                Activate();
            }
        }
        else if (triggerType == TriggerTypes.Toggle)
        {
            if (CheckColliderTag(c.tag))
            {
                Invert();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D c) //OnTriggerStay2D doesnt deactivate so I have this in place
    {
        if (triggerType == TriggerTypes.Constant)
        {
            if (CheckColliderTag(c.tag))
            {
                Deactivate();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (CheckColliderTag(c.tag) && triggerType == TriggerTypes.Constant)
        {
            Activate();
        }
    }

    private void Invert()
    {
        if (activated)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    private void Activate()
    {
        this.activated = true;
       // spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 0.5f);
        NotifyObservers();
    }

    public bool CheckActive()
    {
        return activated;
    }


    private void Deactivate()
    {
        this.activated = false;
      //  spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 1f);
        NotifyObservers();
    }

    public string getTriggerType()
    {
        return triggerType.ToString();
    }

    private bool CheckColliderTag(string c)
    {
        foreach (string s in tags)
        {
            if (c == s)
            {
                return true;
            }
        }
        return false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour, InterfaceSubject
{

    public List<GameObject> targetObstacles = new List<GameObject>();
    private List<InterfaceObserver> observers = new List<InterfaceObserver>();

    public List<GameObject> targetPlatforms = new List<GameObject>();

    [Header("Activate this platform when the listed platforms are deactivated")]
    public List<GameObject> platforms = new List<GameObject>();

    [HideInInspector]
    public bool activated = false;
    private SpriteRenderer spriteRenderer;
    private Color baseColour;

    public float interval = 0f; //Timer


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

            }
        }

        foreach (GameObject g in targetPlatforms)
        {
            if (g.GetComponent<MovementPath>() != null)
            {
                observers.Add(g.GetComponent<MovementPath>());
            }
        }
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {

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

    IEnumerator Flash()
    {
        while (true)
        {
            if (observers.Count != 0)
            {
                if (platforms.Count != 0)
                {
                    if (platforms[0].GetComponent<Blink>().activated)
                    {
                        
                        Deactivate();
                        yield return new WaitForSeconds(interval / 2f);

                    } else
                    {
                        
                        Activate();
                        yield return new WaitForSeconds(interval / 2f);

                    }
                }
                else
                {
                    yield return new WaitForSeconds(interval / 2f);
                    Activate();
                    //Debug.Log("reach 1");
                    yield return new WaitForSeconds(interval / 2f);
                    Deactivate();
                    //Debug.Log("reach 2");
                }
            }

            
        }
    }

}
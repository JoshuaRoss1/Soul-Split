using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, InterfaceObserver
{

    [Header("List of buttons that affect this door")]
    public List<GameObject> buttons = new List<GameObject>();

    [Header("Unassigned states will be defaulted to ON to activate")]
    [Tooltip("States of buttons to activate door")]
    public List<bool> buttonStates = new List<bool>();

    [Header("This obstacle blocks")]
    public bool souls = false;
    public bool players = true;

    [Header("Only for single use wall!")]
    [Tooltip("Once opened, stays open")]
    public bool singleUse = false;
    private bool used = false;

    //private SpriteRenderer spriteRenderer;
    private Color baseColour;
    private BoxCollider2D boxCollider2D;
    private bool open;

    public void ReceivedUpdate(GameObject button)
    {
        Blink blink = GetComponent<Blink>();
        if (blink != null)
        {
            if (blink.activated)
            {
                Unactivated();
            }
            else
            {
                Activated();
            }
        }
        else
        {                    
            foreach (GameObject g in buttons)
            {
                if (g == button)
                {
                    if (CheckAllButtonStatesMatch())
                    {
                        Activated();
                        if (singleUse)
                        {
                            used = true;
                        }
                    }
                    else
                    {
                        if (!used)  
                        {
                            Unactivated();
                        }                    
                    }
                }
            }
        }
    }

    void Awake()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    { //remove extras on runtime
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //baseColour = spriteRenderer.color;
        

        //Change Z position to 0 to avoid layering issues
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (buttons.Count > buttonStates.Count)
        {
            for (int i = 0; i< buttons.Count - buttonStates.Count; i++)
            {
                buttonStates.Add(true);
            }
        }
        if (buttons.Count < buttonStates.Count)
        {
            for (int i = 0; i < buttonStates.Count - buttons.Count; i++)
            {
                buttonStates.RemoveAt(buttonStates.Count-1);
            }
        }
        if (!players && !souls) //if not blocking players, change layer to ignoreplayers
        {
            gameObject.layer = 17;
        }
        else if (!players)
        {
            gameObject.layer = 12;
        }
        else if (!souls)
        {
            gameObject.layer = 16;
        }
        if (buttons.Count == 0)
        {
            Unactivated();
        }
        else
        {
            if (CheckAllButtonStatesMatch())
            {
                Activated();
            }
            else
            {
                Unactivated();
            }
        }
    }

    bool CheckAllButtonStatesMatch()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<Buttons>().CheckActive() != buttonStates[i])
            {
                return false;//if any don't match at any point, false
            }
        }
        return true; //if all checks pass, true
    }

    public void Activated() //door is open
    {
        open = true;
        boxCollider2D.enabled = false;
    }

    public void Unactivated() //door is closed
    {
        open = false;
        boxCollider2D.enabled = true;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Soul" && souls)
        {
            //Destroy me
        }
    }

    public int GetLayer()
    {
        return gameObject.layer;
    }
    public bool IsOpen()
    {
        return open;
    }
    public bool IsSingleUse()
    {
        return singleUse;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

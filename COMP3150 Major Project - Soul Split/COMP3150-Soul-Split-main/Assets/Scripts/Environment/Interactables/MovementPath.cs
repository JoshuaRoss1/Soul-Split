using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour, InterfaceObserver
{
    public bool movingByDefault = false;
    private bool moving = true;
    [Tooltip("Cyclic: A > B > C > A > B > C" + "\n" + "Oscillation: A > B > C > B > A > B > C")]
    public MovementType movementType = MovementType.Oscillation;
    public enum MovementType
    {
        Cyclic,
        Oscillation
    }
    [Tooltip("Time between each point, more points = longer total travel time")]
    public float movementTimeBetweenNodes = 2f;
    private float myTimer;

    [Header("List of buttons that toggle the movement of this")]
    public List<GameObject> buttons = new List<GameObject>();

    [Header("Unassigned states will be defaulted to ON to activate")]
    [Tooltip("States of buttons to activate door")]
    public List<bool> buttonStates = new List<bool>();

    private Component[] nodes;
    private List<Vector2> coordinates = new List<Vector2>();
    private int currentTarget = 0;
    private float elapsed = 0f;
    private Vector2 origin;
    //private bool checking = false;
    //private float checkTimer = 0f;

    public void ReceivedUpdate(GameObject button)
    {
        foreach (GameObject g in buttons)
        {
            if (g == button)
            {
                if (movingByDefault)
                {
                    if (CheckAllButtonStatesMatch())
                    {
                        StopMoving();
                    }
                    else
                    {
                        StartMoving();
                    }
                }
                else
                {
                    if (CheckAllButtonStatesMatch())
                    {
                        StartMoving();
                    }
                    else
                    {
                        StopMoving();
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    { //remove extras on runtime
        if (buttons.Count > buttonStates.Count)
        {
            for (int i = 0; i < buttons.Count - buttonStates.Count; i++)
            {
                buttonStates.Add(true);
            }
        }
        if (buttons.Count < buttonStates.Count)
        {
            for (int i = 0; i < buttonStates.Count - buttons.Count; i++)
            {
                buttonStates.RemoveAt(buttonStates.Count - 1);
            }
        }
        if (movingByDefault) //set default state
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }
        nodes = GetComponentsInChildren<MovementNode>();
        coordinates.Add(transform.position);
        if (nodes.Length < 1)
        {
            Debug.Log("No nodes found in children");
        }
        else
        {
            foreach (MovementNode n in nodes)
            {
                coordinates.Add(n.gameObject.transform.position);
            }
            if (movementType == MovementType.Oscillation)
            {
                for (int i = nodes.Length-2; i >= 0; i--)
                {
                    coordinates.Add(nodes[i].gameObject.transform.position);
                }
            }
            currentTarget = 1;
        }
        origin = transform.position;
    }
    
    bool CheckAllButtonStatesMatch()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<Buttons>().CheckActive() != buttonStates[i])
            {
                return false;//if any don't match at any point, false
            }
        }
        return true; //if all checks pass, true
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && !(nodes.Length < 1))
        {
            if (elapsed < movementTimeBetweenNodes)
            {
                elapsed += Time.deltaTime;
                transform.position = Vector2.Lerp(origin, coordinates[currentTarget], elapsed / movementTimeBetweenNodes);
            }
            else
            {
                transform.position = coordinates[currentTarget];
                origin = transform.position;
                elapsed = 0;
                if (currentTarget < coordinates.Count - 1)
                {
                    currentTarget++;
                }
                else
                {
                    currentTarget = 0;
                }
            }
        }
    }

    void StartMoving()
    {
        moving = true;
    }
    void StopMoving()
    {
        moving = false;
    }
    void ToggleMoving()
    {
        moving = !moving;
    }
}

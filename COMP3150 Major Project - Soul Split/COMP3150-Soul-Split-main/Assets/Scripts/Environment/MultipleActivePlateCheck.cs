using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleActivePlateCheck : MonoBehaviour
{
    public Buttons plate1;
    public Buttons plate2;
    public Obstacles target;


    public bool opposite = false;
    public bool targetRespawn = false;

    public float timeBeforeRespawn;
    private float timer;

    private void Start()
    {
        target.Activated();
    }

    void Update()
    {

        if (!opposite)
        {
            Normal();
        }

        if (opposite)
        {
            Opposite();
        }

        
    }

    void Normal()
    {
        if (plate1.CheckActive() && plate2.CheckActive())
        {
            target.Activated();
            if (targetRespawn)
            {
                timer += Time.deltaTime;
                if (timer >= timeBeforeRespawn)
                {
                    target.Unactivated();
                }
            }

        }
        if (!plate1.CheckActive() || !plate2.CheckActive())
        {
            target.Unactivated();
        }
    }

    void Opposite()
    {
        if (plate1.CheckActive() && plate2.CheckActive())
        {
            target.Unactivated();
            if (targetRespawn)
            {
                timer += Time.deltaTime;
                if (timer >= timeBeforeRespawn)
                {
                    target.Activated();
                }
            }

        }
        if (!plate1.CheckActive() || !plate2.CheckActive())
        {
            target.Activated();
        }
    }
}

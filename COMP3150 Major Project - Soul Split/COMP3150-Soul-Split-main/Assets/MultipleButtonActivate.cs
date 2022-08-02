using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleButtonActivate : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();

    private SpriteRenderer spriteRenderer;
    private Color baseColour;
    private BoxCollider2D boxCollider2D;

    //private bool isActivated = false;
    private int activatedButtons = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        baseColour = spriteRenderer.color;
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();

        Deactivated();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < buttons.Count;)
        {
            if(buttons[i].GetComponent<Buttons>().activated == true)
            {
                activatedButtons += 1;
            }
        }

        Debug.Log(activatedButtons);

        if(activatedButtons == buttons.Count)
        {
            Activated();
        }
    }

    void Activated()
    {
        spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 0.1f);
        boxCollider2D.enabled = false;
        //isActivated = true;

        this.GetComponent<Buttons>().enabled = true;
    }

    void Deactivated()
    {
        spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 1f);
        boxCollider2D.enabled = true;
        //isActivated = false;
        this.GetComponent<Buttons>().enabled = false;
    }
}

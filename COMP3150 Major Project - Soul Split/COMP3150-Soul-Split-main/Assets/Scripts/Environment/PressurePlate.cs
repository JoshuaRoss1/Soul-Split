using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Pressure Plate Properties")]

    [Tooltip("Colour of the Pressure Plate when it is deactivated")]
    public Color plateOffColor;
    [Tooltip("Colour of the Pressure Plate when it is activated")]
    public Color plateOnColor;
    [Tooltip("Toggle whether or not the plate stays active after being stepped on")]
    public bool singleActivationPlate = false;
    
    [Header("Plate Target Properties")]

    [Tooltip("The object which the pressure plate interacts with when activated")]
    public GameObject target;
    [Tooltip("Set whether or not activating the plate makes the target appear")]
    public bool makeTargetAppear;
    [Tooltip("Set whether or not activating the plate turns the target off")]
    public bool makeTargetDisappear;
    [Tooltip("Set whether or not the target disappears permanentaly")]
    public bool makeTargetDisappearPermanently;
    [Tooltip("If the target is a platform that enables when the button is pressed")]
    public bool activatesGhostPlatform;
    [Tooltip("If the target is a platform that disables when the button is pressed")]
    public bool deactivatesGhostPlatform;


    [HideInInspector]
    private bool buttonActive = false;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = plateOffColor;

        if(makeTargetAppear)
        {
            target.SetActive(false);
        } else if(makeTargetDisappear)
        {
            target.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Player" || c.tag == "Soul" || c.tag == "feet")
        {
            sprite.color = plateOnColor;
            if (makeTargetAppear)
            {
                target.SetActive(true);
            }
            else if(makeTargetDisappear)
            {
                target.SetActive(false);
            } else if (makeTargetDisappearPermanently)
            {
                Destroy(target);
            }

            if(activatesGhostPlatform)
            {
                target.GetComponent<GhostPlatform>().alpha = 1f;
            } else if (deactivatesGhostPlatform)
            {
                target.GetComponent<GhostPlatform>().alpha = .5f;
            }

            buttonActive = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = plateOffColor;
        if (!singleActivationPlate)
        {
            if(makeTargetAppear)
            {
                target.SetActive(false);
            }
            else if(makeTargetDisappear)
            {
                target.SetActive(true);
            }

            if (activatesGhostPlatform)
            {
                target.GetComponent<GhostPlatform>().alpha = .5f;
            }
            else if (deactivatesGhostPlatform)
            {
                target.GetComponent<GhostPlatform>().alpha = 1f;
            }

            buttonActive = false;
        }
        
    }

    public bool isActive()
    {
        return buttonActive;
    }
}

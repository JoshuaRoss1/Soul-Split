using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXpulse : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float pulseSpeed = 2f;
    private SpriteRenderer sr;
    private Obstacles obstacleScript;
    private Buttons buttonScript;
    private bool isObstacle = true;
    private string type;
    private Color defaultColor;
    private float currentAlpha = 0;
    private int positive = 1;
    private Animator anim;
    private AudioSource audioSource;
    private bool singleUsed = false;
    private int layer;
    private SpriteRenderer VFX;
    private Color defaultVFXColor;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        obstacleScript = GetComponent<Obstacles>();
        defaultColor = sr.color;
        audioSource = GetComponent<AudioSource>();
        if (obstacleScript == null)
        {
            isObstacle = false;
            buttonScript = GetComponentInParent<Buttons>();
            type = buttonScript.getTriggerType();
            if (type == "Toggle"||type=="Constant")
            {
                sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
            }
        }
        else
        {
            if (obstacleScript.singleUse)
            {
                animator = GetComponent<Animator>();
            }
            if (transform.childCount > 0)
            {
                VFX = gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
            }
            if (VFX != null)
            {
                defaultVFXColor = VFX.color;
            }           
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if (isObstacle)
        {
            if (obstacleScript.IsOpen())
            {
                if (obstacleScript.singleUse)
                {
                    if (!singleUsed)
                    {
                        singleUsed = true;
                        animator.SetTrigger("break");
                        audioSource.Play();
                        audioSource.UnPause();
                    }
                    if (VFX != null)
                    {
                        VFX.color = new Color(defaultVFXColor.r, defaultVFXColor.g, defaultVFXColor.b, 0f);
                    }
                }
                else
                {
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.1f);
                    if (VFX != null)
                    {
                        VFX.color = new Color(defaultVFXColor.r, defaultVFXColor.g, defaultVFXColor.b, 0.1f);
                    }
                }
            }
            else
            {
                { 
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 1f);
                    if (VFX != null)
                    {
                        currentAlpha += Time.deltaTime * pulseSpeed * positive;
                        if (currentAlpha > 1)
                        {
                            currentAlpha = 1;
                            positive *= -1;
                        }
                        else if (currentAlpha < 0.75)
                        {
                            currentAlpha = 0.75f;
                            positive *= -1;
                        }
                        VFX.color = new Color(defaultVFXColor.r, defaultVFXColor.g, defaultVFXColor.b, currentAlpha);
                    }
                }
            }
        }
        else
        {
            if (type == "Single")
            {
                if (buttonScript.CheckActive())
                {
                    anim.SetTrigger("activated");
                    if (!singleUsed)
                    {
                        singleUsed = true;
                        audioSource.Play();
                    }
                }
            }
            else if (type == "Toggle" || type == "Constant")
            {                
                if (buttonScript.CheckActive())
                {
                    if (type == "Constant")
                    {
                        if (!audioSource.isPlaying)
                        {
                            audioSource.Play();
                        }
                    }
                    if (type== "Toggle")
                    {
                        if (!singleUsed)
                        {
                            if (!audioSource.isPlaying)
                            {
                                singleUsed = true;
                                audioSource.Play();
                            }

                        }
                    }
                    currentAlpha += Time.deltaTime * pulseSpeed * positive;
                    if (currentAlpha > 1)
                    {
                        currentAlpha = 1;
                        positive *= -1;
                    }
                    else if (currentAlpha < 0)
                    {
                        currentAlpha = 0;
                        positive *= -1;
                    }
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, currentAlpha);
                }
                else
                {
                    if (type == "Constant")
                    {
                        audioSource.Stop();
                    }
                    if (type == "Toggle")
                    {
                        singleUsed = false;
                    }                    
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
                }
            }
            else
            {
                if (buttonScript.CheckActive())
                {
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
                }
                else
                {
                    sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 1);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasFade : MonoBehaviour
{
    PlayerControls controls;
    [HideInInspector]
    public bool startFade = false;
    [HideInInspector]
    public bool playerDead = false;
    [HideInInspector]
    public bool fadeFinish = false;
    public bool endGameFadeIn = false;
    public bool fadeIn;
    public float fadeTime;
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void Update()
    {

        if (startFade)
        {
            StartCoroutine(FadeOut());
        }

        if (fadeIn && playerDead)
        {
            StartCoroutine(FadeIn());
        }

        if (endGameFadeIn)
        {
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeTime;
            yield return null;
        }

        canvasGroup.alpha = 0;

        if (canvasGroup.alpha <= 0)
        {
            fadeFinish = false;
            if(this.gameObject.name == "WelcomeCanvas")
            {
                this.gameObject.SetActive(false);
            }
        }

        
        
        

    }

    IEnumerator FadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }

        if (canvasGroup.alpha >= 1)
        {
            fadeFinish = true;
            StopAllCoroutines();
        }

        canvasGroup.alpha = 1;

    }

    public void StartFade()
    {
        startFade = true;
    }

    private void OnEnable()
    {
        if (controls != null)
        {
            controls.Enable();
        }
    }

    private void OnDisable()
    {
        if (controls != null)
        {
            controls.Disable();
        }
    }
}

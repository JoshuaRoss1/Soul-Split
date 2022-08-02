using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas pauseMenu; //The pause menu canvas
    public Canvas optionsMenu;
    public bool isPaused = false; //Determines whether the game is paused;

    PlayerInput controls;


    private void Awake()
    {
        if(GameObject.Find("Player") != null)
        {
            controls = GameObject.Find("Player").GetComponent<PlayerInput>();
        }
        
        controls.actions["PauseGame"].performed += ctx => PauseMenuOpen();

        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        //Debug.Log("i have awakened");
    }

    void PauseMenuOpen()
    {
        if (isPaused == false) //IF game is not paused
        {
            if (pauseMenu != null)
            {
                pauseMenu.gameObject.SetActive(true); //Open the menu         
            }
            FreezeGame();
        } else
        {
            HideAllMenus(); //Close all menus
            UnFreezeGame();
        }
        //Debug.Log(Time.timeScale);
    }

    public void FreezeGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OnDisable();
    }

    public void UnFreezeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        OnEnable();
    }

    public void HideAllMenus()
    {
        if (pauseMenu != null)
        {
            pauseMenu.gameObject.SetActive(false);
        }
        if (optionsMenu != null)
        {
            optionsMenu.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if (controls != null)
        {
            controls.actions.Enable();
        }
    }

    private void OnDisable()
    {
        if (controls != null)
        {
            controls.actions.Disable();
        }       
    }
}

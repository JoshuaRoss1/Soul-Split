using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Soul Restrictions")]
    [Tooltip("Drag Player object in here (The Player that is in the scene)")]
    public SoulSpawning player;
    public PlayerInput playerControls;
    public int soulLimit;


    public bool allowShiftingSouls;
    public bool allowStillSouls;
    public bool allowProjectedSouls;
    public bool allowSoulSwap;

    [Header("Menu Settings")]
    public bool isMenu = false;

    private PlayerInput controls;

    public bool freezeGame;



    public void Awake()
    {
        if (freezeGame)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        
    }

    private void Start()
    {
        player.SetSoulLimit(soulLimit);
        if (!isMenu)
        {
            if (!allowShiftingSouls)
            {
                playerControls.actions["ShiftingSoul"].Disable();
            }

            if (!allowStillSouls)
            {
                playerControls.actions["StillSoul"].Disable();
            }

            if (!allowProjectedSouls)
            {
                playerControls.actions["ProjectSoul"].Disable();
                playerControls.actions["ProjectionAimController"].Disable();
            }
        }
        
        
    }

    private void Update()
    {
        if (!isMenu)
        {
            if (player.souls.Count > soulLimit)
            {
                //RestartScene();
            }
        }
        
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

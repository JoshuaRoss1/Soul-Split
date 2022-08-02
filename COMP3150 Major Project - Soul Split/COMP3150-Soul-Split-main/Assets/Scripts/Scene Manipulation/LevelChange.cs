using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    //private string testLevel = "PrototypeLevel1";
    PlayerInput controls;

    private void Awake()
    {
        controls = GameObject.Find("Player").GetComponent<PlayerInput>();

        controls.actions["LevelChange"].performed += cxt => SceneManager.LoadScene("PrototypeLevel1");

    }

    void Update()
    {
        
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        controls.actions.Enable();
    }

    private void OnDisable()
    {
        controls.actions.Disable();
    }


}

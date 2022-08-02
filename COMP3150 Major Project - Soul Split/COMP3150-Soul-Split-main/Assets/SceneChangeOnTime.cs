using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeOnTime : MonoBehaviour
{
    public LevelManager sceneManager;
    private float timer = 0f;
    public float timeBeforeSceneChange;

    public bool isEndScene;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBeforeSceneChange)
        {
            if (isEndScene)
            {
                SceneManager.LoadScene("MainMenu");
            } else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }

    
}

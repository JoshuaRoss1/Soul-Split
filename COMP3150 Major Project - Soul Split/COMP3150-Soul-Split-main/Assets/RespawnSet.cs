using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnSet : MonoBehaviour
{
    public GameObject player;
    PlayerDeath playerState;
    public CanvasFade deathCanvas;

    private void Start()
    {
        playerState = player.GetComponentInChildren<PlayerDeath>();

    }

    void Update()
    {
        if (deathCanvas.fadeFinish == true && deathCanvas.playerDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        deathCanvas.playerDead = true;
        
    }
}

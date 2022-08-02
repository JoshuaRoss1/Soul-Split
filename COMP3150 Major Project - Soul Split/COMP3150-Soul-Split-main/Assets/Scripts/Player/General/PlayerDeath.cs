using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    public Camera playerCamera;
    private Animator playerAnimator;
    private MonoBehaviour[] comps;
    private BoxCollider2D playercollider;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRB;
    private int defaultSortingOrder;
    private string defaultSortingLayerName;
    private RigidbodyType2D defaultRB;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        comps = player.GetComponents<MonoBehaviour>();
        playerAnimator = player.GetComponent<Animator>();
        playercollider = player.GetComponent<BoxCollider2D>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerRB = player.GetComponent<Rigidbody2D>();
        defaultSortingLayerName = playerSprite.sortingLayerName;
        defaultSortingOrder = playerSprite.sortingOrder;
        defaultRB = playerRB.bodyType;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Death" && c.gameObject.layer == 15)
        {
            Die();
        }
        
    }
    public void Die()
    {
        audioSource.Play();
        //playerCamera.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().color = Color.black;
        //playerCamera.gameObject.transform.parent = null;
        foreach (MonoBehaviour m in comps)
        {
            m.enabled = false;
        }
        playercollider.enabled = false;
        playerAnimator.SetTrigger("Death");
        playerSprite.sortingLayerName = "Front";
        playerSprite.sortingOrder = 10;
        Vector2 location = player.transform.position;
        BoxCollider2D[] colliders = player.GetComponentsInChildren<BoxCollider2D>();
        EdgeCollider2D[] colliders2 = player.GetComponentsInChildren<EdgeCollider2D>();
        foreach (BoxCollider2D b in colliders)
        {
            b.enabled = false;
        }

        foreach (EdgeCollider2D b in colliders2)
        {
            b.enabled = false;
        }
        playerRB.bodyType = RigidbodyType2D.Static;
        player.transform.position = location;
        transform.parent = null;
    }
    public void Respawn()
    {
        foreach (MonoBehaviour m in comps)
        {
            m.enabled = true;
        }
        playercollider.enabled = true;
        playerAnimator.SetTrigger("Respawn");
        playerSprite.sortingLayerName = defaultSortingLayerName;
        playerSprite.sortingOrder = defaultSortingOrder;
        BoxCollider2D[] colliders = player.GetComponentsInChildren<BoxCollider2D>();
        EdgeCollider2D[] colliders2 = player.GetComponentsInChildren<EdgeCollider2D>();
        foreach (BoxCollider2D b in colliders)
        {
            b.enabled = true;
        }

        foreach (EdgeCollider2D b in colliders2)
        {
            b.enabled = true;
        }
        playerRB.bodyType = defaultRB;
    }
}

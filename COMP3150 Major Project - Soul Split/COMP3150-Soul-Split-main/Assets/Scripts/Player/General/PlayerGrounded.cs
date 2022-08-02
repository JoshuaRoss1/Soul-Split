using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    public Camera cam;

    private bool grounded;
    private AudioSource audioSource;
    private float currentX;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement playerMovement = GetComponentInParent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playerMovement.footstepsSound;
        audioSource.volume = playerMovement.footstepsSoundVolume;
        audioSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.x != currentX) && isGrounded()) //isMoving
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
        currentX = transform.position.x;
    }
    private void OnCollisionStay2D(Collision2D c)
    {
        if (!c.gameObject != transform.parent.gameObject)
        {
            grounded = true;
            //Debug.Log("grounded");
            transform.parent.SetParent(c.gameObject.transform);
            //transform.parent.GetComponentInChildren<Camera>().gameObject.transform.localPosition = (new Vector3(0, 1, -10));
            //transform.localPosition = (new Vector3(0, 1, -10));
        }
    }

    private void OnCollisionExit2D(Collision2D c)
    {
        grounded = false;
        transform.parent.SetParent(null);
        //Debug.Log("not grounded");
    }

    public bool isGrounded()
    {
        return grounded;
    }
}

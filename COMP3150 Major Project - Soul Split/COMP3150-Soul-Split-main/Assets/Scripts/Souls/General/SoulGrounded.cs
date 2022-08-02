using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulGrounded : MonoBehaviour
{
    private bool grounded = false;

    private void Update()
    {
        //Debug.Log(isGrounded());
    }

    private void OnCollisionStay2D(Collision2D c)
    {
        if(!c.gameObject != transform.parent.gameObject)
        {
            grounded = true;
           // transform.parent.SetParent(c.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D c)
    {
        grounded = false;
        //transform.parent.SetParent(null);
    }

    public bool isGrounded()
    {
        return grounded;
    }
}

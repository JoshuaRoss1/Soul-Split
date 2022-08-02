using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = null;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceActivation : MonoBehaviour
{

    public BoxCollider2D distance;
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Soul" || collision.tag == "feet")
        {
            target.SetActive(true);
        }
    }
}

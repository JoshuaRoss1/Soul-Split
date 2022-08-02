using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Vector3 minScreenBounds;
    private Vector3 maxScreenBounds;

    // Start is called before the first frame update
    void Start()
    {
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),
                                         Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1),
                                         transform.position.z);
    }
}

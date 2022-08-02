using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOnOff : MonoBehaviour
{
    private bool isActivated = false;

    [Header("Activate this platform when the listed platforms are deactivated")]
    public List<GameObject> platforms = new List<GameObject>();

    private SpriteRenderer spriteRenderer;
    private Color baseColour;
    private BoxCollider2D boxCollider2D;

    public float interval = 0f; //Timer

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        baseColour = spriteRenderer.color;
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();

        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if(platforms.Count != 0)
            {
                if (!platforms[0].GetComponent<PlatformOnOff>().isActivated)
                    {
                        Activated();
                        yield return new WaitForSeconds(interval / 2f);
                    }
            }
            Activated();
            yield return new WaitForSeconds(interval / 2f);
            Unactivated();
            yield return new WaitForSeconds(interval / 2f);
        }
    }

    void Activated()
    {
        spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 0.1f);
        boxCollider2D.enabled = false;
        isActivated = true;
    }

    void Unactivated()
    {
        spriteRenderer.color = new Color(baseColour.r, baseColour.g, baseColour.b, 1f);
        boxCollider2D.enabled = true;
        isActivated = false;
    }

}

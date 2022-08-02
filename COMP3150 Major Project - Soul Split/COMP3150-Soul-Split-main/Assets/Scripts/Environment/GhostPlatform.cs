using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D platformCollider;
    public EdgeCollider2D stickCollider;

    [HideInInspector]
    public Color platformAlpha;
    [HideInInspector]
    public float alpha;

    private void Start()
    {
        alpha = 0.5f;
        SetColor(alpha);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(spriteRenderer.color.a < 1)
        {
            platformCollider.enabled = false;
            stickCollider.enabled = false;
        }
        else
        {
            platformCollider.enabled = true;
            stickCollider.enabled = true;
        }

        SetColor(alpha);
    }

    void SetColor(float alpha)
    {
        platformAlpha = spriteRenderer.color;
        platformAlpha.a = alpha;
        spriteRenderer.color = platformAlpha;
    }

}

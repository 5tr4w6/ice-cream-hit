using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopSpriteScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite hitSprite;
    Sprite regularSprite;

    void Start()
    {
        regularSprite = spriteRenderer.sprite;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        Invoke("ChangeSprite",0.0f);
        Invoke("RewertSprite",0.13f);
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = hitSprite;
    }
    void RewertSprite()
    {
        spriteRenderer.sprite = regularSprite;
    }
}

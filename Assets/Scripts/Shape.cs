using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public string Name;
    protected GameSceneController gameSceneController;
    protected float halfWidth;
    protected float halfHeight;
    private SpriteRenderer spriteRenderer;

    protected void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        halfWidth = spriteRenderer.bounds.extents.x; // half the width of the shape
        halfHeight = spriteRenderer.bounds.extents.y;
    }

    public void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}

using System;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public static event Action<Color> OnChangeColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnChangeColor?.Invoke(spriteRenderer.color);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite checkPointLighted;
    public GameObject lights;

    private bool isActive;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(CircleCollider2D other)
    {
        if (isActive)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = checkPointLighted;
            lights.SetActive(true);
            isActive = true;

        }
    }
}

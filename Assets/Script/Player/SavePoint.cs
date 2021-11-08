using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite checkPointLighted;
    public GameObject lights;

    private CheckPointController checkPointController;
    private bool isActive;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        checkPointController = FindObjectOfType<CheckPointController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            checkPointController.SetPos(transform.position);
            spriteRenderer.sprite = checkPointLighted;
            lights.SetActive(true);
            isActive = true;

        }
    }
}

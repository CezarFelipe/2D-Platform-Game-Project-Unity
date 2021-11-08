﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;
    public AudioClip impactDfx;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.PlayAudioAtPoint(transform.position, impactDfx);
        GameObject newImpact = Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(newImpact, 1);
        Destroy(gameObject);
    }
}

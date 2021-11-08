using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public Skills skill;
    public Sprite pickedSprite;
    public string text;


    private SpriteRenderer SpriteRenderer;
    private bool picked;

   private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (picked)
        {
            return;
        }
        PlayerAnimation player = other.GetComponent<PlayerAnimation>();
        if (player != null)
        {
            UIManager.instance.SetText(text);
            picked = true;
            SpriteRenderer.sprite = pickedSprite;
            PlayerSkills.instance.skills.Add(skill);
            if(skill == Skills.Gun)
            {
                player.SetGun();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.SetTextOut();
        }
    }
}

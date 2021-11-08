using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damegeable : MonoBehaviour
{
    public int maxHealth;
    public float invincibleTime;
    
    public UnityEvent OnDeath;
    public UnityEvent OnDamage;
    public UnityEvent ReleaseDamage;

    private int currentHealth;
    private bool invincible;
    private bool isDead;

    private SpriteRenderer spriteRenderer;
    private Color startColor;
    public Color damageColor;

    public float noControlTime = 0.1f;
    public Vector2 impactForce;
    private float x;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startColor = spriteRenderer.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamege(int damageAmount, float xPos = 0)
    {

        if (invincible || isDead) 
        {
            return;
        }
        x = xPos;
        OnDamage.Invoke();
        invincible = true;
        Invoke("SetInvincible", invincibleTime);
        Invoke("GainControl", noControlTime);
        currentHealth -= damageAmount;

        if (gameObject.CompareTag("Player"))
        {
            UIManager.instance.SetLives(currentHealth);
        }
        if(currentHealth <= 0)
        {
            OnDeath.Invoke();
            isDead = true;
        }

    }
    void SetInvincible()
    {
        invincible = false;
    }
    public void StartDamageSprite()
    {
        StartCoroutine(DamageSpriter());
    }
    IEnumerator DamageSpriter()
    {
        float timer = 0;
        while (timer < invincibleTime)
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
            spriteRenderer.color = startColor;
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }
        spriteRenderer.color = startColor;
    }
    public void DamageImpact()
    {
        Rigidbody2D rb = GetComponent <Rigidbody2D>();
        if(rb != null)
        {
            float dir = 0;
            if (x < transform.position.x)
            {
                dir = 1;
            }
            else dir = -1;

            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(impactForce.x * dir, impactForce.y), ForceMode2D.Impulse);
        }
    }
    void GainControl()
    {
        if (isDead)
        {
            return;
        }

        ReleaseDamage.Invoke();
    }
    public void Respawn()
    {
        isDead = false;
        currentHealth = 5;
        UIManager.instance.SetLives(currentHealth);
    }
    public void SetHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIManager.instance.SetLives(currentHealth);
    }
    public void DestroyObject(float time)
    {
        Destroy(gameObject, time);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float inviniciblityTime;
    public bool takeDamage;
    public Color normalColor;
    public Color flashColor;
    private float invincibilityTimer;
    private bool isInvincibile;
    private float flashTime = 0.2f;
    public AudioSource ausToPlay;
    public bool flashed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
        invincibilityTimer = inviniciblityTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (takeDamage)
        {
            TakeDamage(0);
        }

        if(isInvincibile)
        {
            invincibilityTimer -= Time.deltaTime;
            flashTime -= Time.deltaTime;
            if(flashTime <= 0)
            {
                if(flashed)
                {
                    gameObject.transform.Find("PlayerBody").GetComponent<SpriteRenderer>().color = flashColor;
                    flashTime = 0.2f;
                    flashed = false;
                }

                else if(!flashed)
                {
                    gameObject.transform.Find("PlayerBody").GetComponent<SpriteRenderer>().color = normalColor;
                    flashTime = 0.2f;
                    flashed = true;
                }
            }

            if(invincibilityTimer <= 0)
            {
                isInvincibile = false;
                invincibilityTimer = inviniciblityTime;
                gameObject.transform.Find("PlayerBody").GetComponent<SpriteRenderer>().color = normalColor;
            }
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageReceived)
    {
        if (isInvincibile == false && !GetComponent<PlayerAbilities>().guarding)
        {
            ausToPlay.Play();
            isInvincibile = true;
            currentHealth -= damageReceived;
            takeDamage = false;
        }

        if(GetComponent<PlayerAbilities>().guarding)
        {
            GetComponent<PlayerAbilities>().gotHit = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;

        if(currentHealth <= 0){
            //Player is dead
            //Play Death Animation
            //Show GameOver screen
        }
    }

    public void Heal(int amount){
        currentHealth += amount;

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public static int currentHealth = 5;
    
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount){
        if(!PlayerBehavior.invulnerable){
            currentHealth -= amount;

            if(currentHealth <= 0){
                //Player is dead
                //Play Death Animation
                //Show GameOver screen
                Die();
            }
        }
    }

    public void Heal(int amount){
        currentHealth += amount;

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap")){
            Die();
        }
    }
    */
    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        PlayerBehavior.alive = false;
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Lever has restarted.");
        PlayerBehavior.alive = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

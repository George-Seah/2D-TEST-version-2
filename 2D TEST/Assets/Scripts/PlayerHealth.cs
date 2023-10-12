using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    public int maxHealth = 5;
    public static int currentHealth = 5;
    
    private Rigidbody2D rb;
    private Animator anim;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;
        if(currentHealth > 0){
            StartCoroutine(Invulnerability());
        }
        if(currentHealth <= 0){
            //Player is dead
            //Play Death Animation
            //Show GameOver screen
            Die();
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

    private IEnumerator Invulnerability(){
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for(int i = 0; i < numberOfFlashes; i++){
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

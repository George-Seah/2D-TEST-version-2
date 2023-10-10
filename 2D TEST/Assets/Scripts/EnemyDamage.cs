using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public bool damageGiving = true;
    private PlayerHealth playerHealth;
    private PlayerBehavior playerBehavior;
    //public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" && damageGiving){
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.KBCounter = playerBehavior.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
                playerBehavior.KnockFromRight = true;
            if(collision.transform.position.x > transform.position.x)
                playerBehavior.KnockFromRight = false;

            playerHealth.TakeDamage(damage);
            //collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

        }
    }
}

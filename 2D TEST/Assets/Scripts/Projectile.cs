using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    private float horizontalInput;//May not need this
    private SpriteRenderer spriteRend;
    private CharacterAnimator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        spriteRend = GetComponent<SpriteRenderer>();
        projectileRb = GetComponent<Rigidbody2D>();
        horizontalInput = Input.GetAxis("Horizontal");
        characterAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimator>();
        if(characterAnimator.spriteRend.flipX){
            speed *= -1;
            spriteRend.flipX = true;
        }
            
    }

    // Update is called once per frame
    void Update()
    {

        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate(){
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Trap"){
            if(collision.gameObject.GetComponent<EnemyWeakpoint>()){
                Debug.Log("Collided object has EnemyWeakpoint.");
                collision.gameObject.GetComponent<EnemyWeakpoint>().playDefeat();
            }
            else{
                Destroy(collision.gameObject);
            }
            
        }

        Destroy(gameObject);
    }
}

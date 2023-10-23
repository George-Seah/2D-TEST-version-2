using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        projectileRb = GetComponent<Rigidbody2D>();
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

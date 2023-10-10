using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakpoint : MonoBehaviour
{
    public Vector3 position;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask playerLayer;
    private EnemyDamage enemyDamage;
    // Start is called before the first frame update
    public bool isStomped(){
        if(Physics2D.BoxCast(transform.position + position, boxSize, 0, transform.up, castDistance, playerLayer)){
            return true;
        }
        else{
            return false;
        }
    }
    void Start()
    {
        enemyDamage = GetComponent<EnemyDamage>();
    }

    // Update is called once per frame
    void Update()
    {

    /*
    private void OnCollisionEnter2D(Collision2D collision){
        if(isStomped()){
            enemyDamage.enabled = false;
            Debug.Log("enemyDamage.enabled = false");
            Destroy(gameObject);
            Debug.Log("Mask Dude should be killed.");
        }
    */
    }
    

    void OnCollisionEnter2D(Collision2D collision){
        //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.rigidbody.velocity.x, 5);

        if(isStomped()){
            enemyDamage.damageGiving = false;
            Debug.Log("enemyDamage.damageGiving = false");
            Destroy(gameObject);
            Debug.Log("Mask Dude should be killed.");
            /*
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, 15);
            Debug.Log("Player should bounce off enemy.");
            */
            
            //playerLayer.rigidbody.velocity = new Vector2(0f, 15f);
            

            
        }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube((transform.position+position)+transform.up * castDistance, boxSize);
    }
}

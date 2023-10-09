using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakpoint : MonoBehaviour
{
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask playerLayer;
    private EnemyDamage enemyDamage;
    // Start is called before the first frame update
    public bool isStomped(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, transform.up, castDistance, playerLayer)){
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
        if(isStomped()){
            enemyDamage.enabled = false;
            Debug.Log("enemyDamage.enabled = false");
            Destroy(gameObject);
            Debug.Log("Mask Dude should be killed.");
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision){
        if(isStomped()){
            enemyDamage.enabled = false;
            Debug.Log("enemyDamage.enabled = false");
            Destroy(gameObject);
            Debug.Log("Mask Dude should be killed.");
        }
    }
    */
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position+transform.up * castDistance, boxSize);
    }
}

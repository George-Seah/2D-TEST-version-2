using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector2 destination1;
    public Vector2 destination2;
    public float speed;
    public int patrolDestination = 1;

    private SpriteRenderer spriteRend;

    void Start(){
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 1){
            transform.position = Vector2.MoveTowards(transform.position, destination1, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, destination1) < .2f){
                patrolDestination = 2;
                spriteRend.flipX = false;
            }
        }

        else if(patrolDestination == 2){
            transform.position = Vector2.MoveTowards(transform.position, destination2, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, destination2) < .2f){
                patrolDestination = 1;
                spriteRend.flipX = true;
            }
        }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(destination1, new Vector3(1, 1, 1));
        Gizmos.DrawWireCube(destination2, new Vector3(1, 1, 1));
    }
}

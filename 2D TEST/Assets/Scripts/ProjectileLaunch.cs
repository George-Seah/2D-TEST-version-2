using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public GameObject player;
    public float shootTime;
    public float shootCounter;
    public float playerDistance;
    public SpriteRenderer spriteRend;

    Quaternion projectileRotation;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        //spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteRend.flipX){
            Debug.Log("Sprite should be facing left.");
            //projectileRotation = Quaternion.Euler(0, -180, 0);
            //gameObject.transform.rotation = projectileRotation;
            //transform.position.x *= -1;
            //if(transform.position.x > 0){
                //transform.position.x = -1.25f;
                launchPoint.position = new Vector3(-playerDistance + player.transform.position.x, transform.position.y, transform.position.z);
            //}
                
                
        }
        else if(!spriteRend.flipX){
            Debug.Log("Sprite should be facing right.");
            //projectileRotation = Quaternion.Euler(0, 0, 0);
            //gameObject.transform.rotation = projectileRotation;
            //transform.position.x *= -1;
            //if(transform.position.x < 0){
                launchPoint.position = new Vector3(playerDistance + player.transform.position.x, transform.position.y, transform.position.z);
            //}
                //transform.position = new Vector3(1.25f, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.S) && shootCounter <= 0){
            Instantiate(projectilePrefab, launchPoint.position, projectileRotation);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(1, 1));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static float horizontalAxis;
    [SerializeField] float verticalPosition;
    [SerializeField] float speed = 5;
    Rigidbody2D rb;
    public float jumpAmount = 10;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalAxis * Time.deltaTime * speed, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if(rb.velocity.y >= 0){
            rb.gravityScale = gravityScale;
        }
        else if(rb.velocity.y < 0){
            rb.gravityScale = fallingGravityScale;
        }
    }
}

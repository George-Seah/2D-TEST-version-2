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

    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float buttonTime = 0.3f;
    float jumpTime;
    bool jumping;
    
    public float jumpAmount = 1.25f;

    float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(jumpAmount * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalAxis * Time.deltaTime * speed, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jumping = true;
            jumpTime = 0;
            
        }
        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime){
            jumping = false;
        }
        if(jumping){
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if(rb.velocity.y >= 0){
            rb.gravityScale = gravityScale;
        }
        else if(rb.velocity.y < 0){
            rb.gravityScale = fallingGravityScale;
        }
        
    }
}

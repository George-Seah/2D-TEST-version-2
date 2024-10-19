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
    float jumpTime = 0;
    bool jumping;
    
    public float jumpAmount = 1.25f;

    float jumpForce;

    bool jumpCancelled;


    public float distanceToCheck = 0.5f;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    public static bool alive = true;

    Animator anim;
    SpriteRenderer spriteRend;

    //public bool isGrounded;//Used in original groundCheck pre-LayerMask
    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            return true;
        }
        else{
            return false;
        }
    }
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    //GroundCheck2D gCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //groundCheck = GetComponent<GroundCheck2D>();
        jumpForce = Mathf.Sqrt(jumpAmount * -2 * (Physics2D.gravity.y * rb.gravityScale));
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if(alive && KBCounter <= 0){
            transform.position += new Vector3(horizontalAxis * Time.deltaTime * speed, 0, 0);
        }
        else{
            if(KnockFromRight){
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(!KnockFromRight){
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            //rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jumping = true;
            jumpTime = 0;
            
        }
        if(!isGrounded()){
            anim.SetBool("isJumping", true);
        }
        else{
            anim.SetBool("isJumping", false);
        }
        if(jumping){
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
            if(Input.GetKeyUp(KeyCode.Space)){
                jumpCancelled = true;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime){
            jumping = false;
        }
        if(rb.velocity.y >= 0){
            rb.gravityScale = gravityScale;
        }
        else if(rb.velocity.y < 0){
            rb.gravityScale = fallingGravityScale;
            //anim.SetBool("isJumping", false);//Testing to see. If not working remove this
        }
        if(jumpCancelled && jumping && rb.velocity.y > 0){
            //rb.AddForce(Vector2.down * 100);
        }
        //Unfinished Raycast isGrounded option
        /*
        if(Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck)){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
        */
    }
    /*
    void FixedUpdate(){
        if(jumpCancelled && jumping && rb.velocity.y > 0){
            //rb.AddForce(Vector2.down * 100);
        }
    }
    */


    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    //Defunct collision detection code
    /*
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.CompareTag("Ground")){
            Vector3 normal = other.GetContact(0).normal;
            if(normal == Vector3.up){
                isGrounded = true;
            }
            
        }
    }
    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
    */
}

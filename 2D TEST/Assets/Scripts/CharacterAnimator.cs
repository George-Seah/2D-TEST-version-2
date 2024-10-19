using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    Animator anim;
    public SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            anim.SetBool("isRunning", true);
            anim.SetFloat("horizontalDirection", PlayerBehavior.horizontalAxis);
            /*
            if(Input.GetKey(KeyCode.LeftArrow)){
                spriteRend.flipX = true;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                spriteRend.flipX = false;
            }
            */
            if(PlayerBehavior.horizontalAxis < 0){
                spriteRend.flipX = true;
            }
            else if(PlayerBehavior.horizontalAxis > 0){
                spriteRend.flipX = false;
            }
            
        } else{
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            //anim.SetTrigger("jump");
        }
    }
}

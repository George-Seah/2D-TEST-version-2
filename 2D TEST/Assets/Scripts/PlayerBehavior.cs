using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    float horizontalAxis;
    float verticalPosition;
    Rigidbody2D rb;
    public float jumpAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalAxis * Time.deltaTime * 5, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}

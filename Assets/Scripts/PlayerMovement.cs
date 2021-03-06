﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D playerRb;
    public float speed = .5f;
    public float jumpSpeed = 200;

    public bool isGrounded = true;
    public bool isRunning = false;
    public bool isJumping = false;

    public Animator playerAnim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
        
        if(Input.GetAxis("Horizontal") == 0)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else  if(Input.GetAxis("Horizontal") < 0)
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(0.07f, -0.067f);
            isRunnings();
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.07f, -0.067f);
            isRunnings();
        }
                

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isRunning && isGrounded)
                {
                    // GetComponent<AudioSource>().Play();
                    playerRb.AddForce(Vector2.up * jumpSpeed * speed * 0.5f);
                    isGrounded = false;
                    playerAnim.SetTrigger("Jump");
                    
                }
                else{
                    playerRb.AddForce(Vector2.up * jumpSpeed * speed);
                    isGrounded = false;
                    playerAnim.SetTrigger("Jump");
                }
            }
        }

        if (speed > 1f)
        {
            speed = 1f;
        }else if(speed < 0.5f)
        {
            speed = 0.5f;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.ResetTrigger("Jump");
        }
    }

    private void isRunnings()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnim.SetBool("isRunning", true);
            speed = speed + 0.5f;
            isRunning = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnim.SetBool("isRunning", false);
            speed = speed - 0.5f;
            isRunning = false;
        }
    }
}

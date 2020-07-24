using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRend;
    Animator enemyAnim;
    ParticleSystem enemyPart;
    AudioSource enemyAudio;

    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;

    public int maxHealth = 100;
    int currentHealth;

    

	void Start ()
    {

        currentHealth = maxHealth;
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        //enemyPart = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        enemyAudio = GetComponent<AudioSource>();

        
    }
    

    // Update is called once per frame
    void Update ()
    {
        enemyRb.velocity = Vector2.right * speed;

        if (speed > 0)
            enemySpriteRend.flipX = true;
        else if (speed < 0)
            enemySpriteRend.flipX = false;
        
        if (timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }

        if (enemySpriteRend.flipX)
        {
            gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.05f, -0.1f);
        }
        else
        {
            gameObject.GetComponent<Collider2D>().offset = new Vector2(0.05f, -0.1f);
        }
    }
    
    public void TakeDamage(int damage)
    {
        enemyAnim.SetTrigger("Damage");
        currentHealth -= damage;
        gameObject.GetComponent<Transform>().position = new Vector2(enemyRb.position.x + 0.05f, enemyRb.position.y);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!!");

        enemyAnim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        enemyRb.velocity = new Vector2(0f, 0f);
        this.enabled = false;
    }

    
}

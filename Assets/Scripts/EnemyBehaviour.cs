using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    CapsuleCollider2D collider2D;
    Rigidbody2D enemyRb;
    SpriteRenderer enemySpriteRend;
    Animator enemyAnim;
    ParticleSystem enemyPart;
    AudioSource enemyAudio;

    float timeBeforeChange;
    public float delay = .5f;
    public float speed = .3f;

	void Start ()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        enemyPart = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        enemyAudio = GetComponent<AudioSource>();
        collider2D = GetComponent<CapsuleCollider2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y + .03f < collision.transform.position.y)
            {
                enemyPart.transform.position = transform.position;
                enemyPart.Play();
                enemyAudio.Play();
                enemyAnim.SetBool("isDead", true);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}

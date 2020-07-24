using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    
    public Animator bossAnim;
    private float distanceBtw;
    public Transform player;
    Transform boss;

    public float maxHealth = 150;
    float currentHealth;
    
    Rigidbody2D bossRb;

    void Start()
    {
        currentHealth = maxHealth;
        bossRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceBtw = boss.position.x - player.position.x;
        
        while (distanceBtw <= 1.5f)
            bossAnim.SetBool("Attack", true);
    }

    public void TakeDamage(int damage)
    {
        bossAnim.SetTrigger("Damage");
        currentHealth -= damage;
        gameObject.GetComponent<Transform>().position = new Vector2(bossRb.position.x + 0.05f, bossRb.position.y);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!!");

        bossAnim.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}

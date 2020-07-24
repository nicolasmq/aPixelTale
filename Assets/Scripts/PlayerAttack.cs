using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoints;
    public Animator attackAnim;

    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    AudioSource attackAudio;

    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    

    void attack()
    {
        attackAnim.SetTrigger("Attack");
        attackAudio.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoints.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehaviour>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoints == null)
            return;

        Gizmos.DrawWireSphere(attackPoints.position, attackRange);        
    }

}

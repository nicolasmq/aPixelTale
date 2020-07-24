using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float dectectedDistance;
    public Animator bossAnim;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public Transform player;

    public GameObject proyectil;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        bossAnim.SetTrigger("Attack");
        if (timeBtwShots <= 0)
        {
            Instantiate(proyectil, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        

    }
}

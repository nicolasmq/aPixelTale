using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    int health = 3;
    public Image[] hearts;
    bool hasCooldown = false;
    public SceneChanger changeScene;

    public Animator deathAnim;
    public Animator damageAnim;
    public GameObject playerAlive;
    public GameObject playerDeath;

    //public SceneChanger changeScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMovement>().isGrounded)
            {
                SubstractHealth();
            }
        }
        if (collision.gameObject.CompareTag("Falling"))
        {
            /*playerAnim.SetBool("isAlive", false);
            playerAlive.SetActive(false);
            playerDeath.SetActive(true);
            playerAnim.SetTrigger("Death");*/
            LoseScene();

        }

    }
    void SubstractHealth()
    {
        if (!hasCooldown)
        {
            if(health > 0)
            {
                health--;
                damageAnim.SetTrigger("Damage");
                hasCooldown = true;

                StartCoroutine(Cooldown());
            }

            if (health <= 0)
            {
                LoseScene();
            }

            EmptyHearts();


        }
    }

    void EmptyHearts()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (health - 1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;

        StopCoroutine(Cooldown());
    }

    public void LoseScene()
    {
        StartCoroutine(toLoseScene(SceneManager.GetActiveScene().buildIndex + 2 ));
    }

    IEnumerator toLoseScene(int indexScene)
    {
        playerAlive.SetActive(false);
        playerDeath.SetActive(true);
        deathAnim.SetTrigger("Death");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(indexScene);
    }
}

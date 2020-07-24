using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public Animator winAnim;
    public GameObject playerWin;
    public GameObject playerWinner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            winScene();
        }
    }

    public void winScene()
    {
        StartCoroutine(toLoseScene());
    }

    IEnumerator toLoseScene()
    {
        playerWin.SetActive(false);
        playerWinner.SetActive(true);
        winAnim.SetTrigger("Win");

        yield return new WaitForSeconds(1f);

        //SceneManager.LoadScene(indexScene);
    }
}

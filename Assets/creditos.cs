using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{

    public void cambioCredito(string cambiocreditos)
    {
        SceneManager.LoadScene(cambiocreditos);

    }

}

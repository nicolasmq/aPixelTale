using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instruccion : MonoBehaviour
{
    public void cambiarEscena(string nombreescena)
    {
        SceneManager.LoadScene(nombreescena);

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVolverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void VolverMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }

    // Update is called once per frame
}

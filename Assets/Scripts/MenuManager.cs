using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void loadlevelone()

    {
        SceneManager.LoadScene("mario_adaia");
    }

    public void loadMenu()

    {
        SceneManager.LoadScene("INTERFAZ PLAY");
    }
}

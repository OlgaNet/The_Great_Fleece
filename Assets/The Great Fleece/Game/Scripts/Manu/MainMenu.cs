using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start -- game
    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Main");
    }

    // Quit -- quit application
    public void Quit()
    {
        Application.Quit();
    }

}

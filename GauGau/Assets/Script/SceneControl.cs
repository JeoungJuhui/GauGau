using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{


    public void GotoGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void GotoClear()
    {
        SceneManager.LoadScene("ClearScene");
    }
    public void GotoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

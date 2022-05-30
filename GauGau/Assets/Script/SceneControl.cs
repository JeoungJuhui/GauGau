using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{

    public void GotoGame()
    {
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GameScene");
    }
    public void GotoClear()
    {
        DontDestroyOnLoad(gameObject);
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

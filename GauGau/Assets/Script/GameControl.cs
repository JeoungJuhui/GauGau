using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    GameObject pausePanel;
    GameObject gameOverPanel;
    GameObject fillArea;
    Slider progress_slider;

    public Text scoreText;

    bool corutine_is_running;

   [SerializeField]
    public int stage;
    public float progress;
    public float stage_time;
    public float gameSpeed;


    // Start is called before the first frame update
    void Start()
    {
        progress_slider = GameObject.Find("Slider").GetComponent<Slider>();
        fillArea = GameObject.Find("Fill");

        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);

        stage = 1;
        gameSpeed = 8;
        corutine_is_running = false;




    }

    // Update is called once per frame
    void Update()
    {
        progress_slider.value = progress;

        Stagecheck();
        if (Input.GetKeyDown(KeyCode.Escape))
            GamePause();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        scoreText = GameObject.Find("GameOverPanel").transform.GetChild(1).GetComponent<Text>();
        scoreText.text = "Score: " +GameObject.Find("Score").transform.GetChild(0).GetComponent<Text>().text;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Stagecheck()
    {
        switch (stage)
        {
            case 1:
                progress = 0f;
                stage_time = 5f;
                fillArea.GetComponent<Image>().color = Color.green;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;

            case 2:
                progress = 0f;
                stage_time = 10f;
                gameSpeed = 11;
                fillArea.GetComponent<Image>().color = Color.blue;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;
            case 3:
                progress = 0f;
                stage_time = 10f;
                gameSpeed = 13;
                fillArea.GetComponent<Image>().color = Color.red;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;
                
        }
    }

    IEnumerator ProgressStage()
    {
        corutine_is_running = true;
        float temp = 0;
        while (progress<=1)
        {
            temp += Time.deltaTime;
            progress= temp/ stage_time;
            if (progress > 1)
                break;
            yield return null;
        }
        corutine_is_running = false;
        stage += 1;
        yield break;

    }
}

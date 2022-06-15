using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    PlayerControl playerControl=null;
    SceneControl sceneControl;
    MusicControl musicControl;

    GameObject pausePanel;
    GameObject gameOverPanel;
    GameObject musicPanel;
    
    GameObject fillArea;
    Slider progress_slider;

    public Text scoreText;
    public int scoretemp;
    public float gameSpeed;


    bool corutine_is_running;

   [SerializeField]
    public int stage;
    public float progress;
    public float stage_time;


    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        musicControl = GameObject.Find("EventSystem").GetComponent<MusicControl>();

        sceneControl = gameObject.GetComponent<SceneControl>();


        progress_slider = GameObject.Find("Slider").GetComponent<Slider>();
        fillArea = GameObject.Find("Fill Area").transform.GetChild(0).gameObject;

        pausePanel = GameObject.Find("PausePanel");
        pausePanel.SetActive(false);

        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);

        musicPanel = GameObject.Find("MusicPanel");
        musicPanel.SetActive(false);

        stage = 1;
        gameSpeed = 5;
        corutine_is_running = false;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl!=null)
        progress_slider.value = progress;

        Stagecheck();
        if (Input.GetKeyDown(KeyCode.Escape))
            GamePause();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        musicControl.GameOverSound();
        scoreText = GameObject.Find("GameOverPanel").transform.GetChild(1).GetComponent<Text>();
        scoreText.text = "Score: " + (int)playerControl.score;
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

    private void GameClear()
    {
        scoretemp= (int)playerControl.score;
        musicControl.GameClearSound();
        sceneControl.GotoClear();

    }


    public void Stagecheck()
    {
        switch (stage)
        {
            case 1:
                progress = 0f;
                stage_time = 20f;
                fillArea.GetComponent<Image>().color = Color.green;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;

            case 2:
                progress = 0f;
                stage_time = 40f;
                fillArea.GetComponent<Image>().color = Color.blue;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;
            case 3:
                progress = 0f;
                stage_time = 70f;
                fillArea.GetComponent<Image>().color = Color.red;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;
            case 4:
                progress = 0f;
                stage_time = 100f;
                fillArea.GetComponent<Image>().color = Color.yellow;
                if (!corutine_is_running)
                    StartCoroutine(ProgressStage());
                break;
            case 5:
                GameClear();
                stage += 1;
                break;
            default:
                break;
                
        }
    }

    IEnumerator ProgressStage()
    {
        if(stage==1)
        {
            gameSpeed = 5;
        }
        gameSpeed += 2;

        corutine_is_running = true;
        float temp = 0;

        if (playerControl.playerHP != 3)
            playerControl.playerHP += 1;

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

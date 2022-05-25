using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControl player;
    GameObject HP;
    public Text score_text;
    public int score;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        score_text = GameObject.Find("Score").transform.GetChild(0).GetComponent<Text>();
        HP = GameObject.Find("HP");

    }

    // Update is called once per frame
    void Update()
    {
     
        hp_image();
        score_update();
    }

    void hp_image()
    {
        switch (player.playerHP)
        {
            case 0:
                HP.transform.GetChild(0).gameObject.SetActive(false);
                HP.transform.GetChild(1).gameObject.SetActive(false);
                HP.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                HP.transform.GetChild(0).gameObject.SetActive(true);
                HP.transform.GetChild(1).gameObject.SetActive(false);
                HP.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 2:
                HP.transform.GetChild(0).gameObject.SetActive(true);
                HP.transform.GetChild(1).gameObject.SetActive(true);
                HP.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 3:
                HP.transform.GetChild(0).gameObject.SetActive(true);
                HP.transform.GetChild(1).gameObject.SetActive(true);
                HP.transform.GetChild(2).gameObject.SetActive(true);
                break;

        }
    }

    void score_update()
    {
        score = (int)player.score;
        score_text.text = score.ToString();
    }
    
    
}

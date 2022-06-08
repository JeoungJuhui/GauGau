using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{

    GameControl gameControl;
    MusicControl musicControl;

    public float barkTime = 15.0f;
    public float biteTime = 15.0f;
    public float bark_coolTime;
    public float bite_coolTime;

    public bool bite;
    public bool bark;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        musicControl = GameObject.Find("EventSystem").GetComponent<MusicControl>();

        bite = true; 
        bark = true;

        bark_coolTime = 0f;
        bite_coolTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&bark)
        {
            Debug.Log("Bark");
            StartCoroutine(Bark_Time());
        }
        if (Input.GetKeyDown(KeyCode.E) && bite)
        {
            Debug.Log("Bite");
            StartCoroutine(Bite_Time());
        }
    }

    IEnumerator Bark_Time()
    {
        //float temp = gameControl.gameSpeed;
        bark = false;
        musicControl.BarkSound();
        StartCoroutine(BarkCoolTime());

        float tempTime = 0;

        while(tempTime<5.0f)
        {
            gameControl.gameSpeed = 3;

            tempTime += Time.deltaTime;
            yield return null;
        }

        if (gameControl.stage == 1)
            gameControl.gameSpeed = 7;
        else if (gameControl.stage == 2)
            gameControl.gameSpeed = 9;
        else if (gameControl.stage == 3)
            gameControl.gameSpeed = 11;
        else if (gameControl.stage == 4)
            gameControl.gameSpeed = 13;
        yield break;

    }

    IEnumerator Bite_Time()
    {
        bite = false;
        musicControl.BiteSound();
        StartCoroutine(BiteCoolTime());


        while (GameObject.FindGameObjectWithTag("Box"))
        {
            Time.timeScale = 0;
            Destroy(GameObject.FindGameObjectWithTag("Box"));
            yield return null;
        }

        Time.timeScale = 1;
        yield break;

    }

    IEnumerator BarkCoolTime()
    {
        float temp = 0f;
        while (bark_coolTime < 1)
        {
            Debug.Log("cooltime " + bark_coolTime);

            temp += Time.deltaTime;
            bark_coolTime = temp /barkTime;
            yield return null;

        }

        bark = true;
        bark_coolTime = 0f;

        yield break;

    }

    IEnumerator BiteCoolTime()
    {
        float temp = 0f;
        while(bite_coolTime<1)
        {

            temp += Time.deltaTime;
            bite_coolTime = temp / biteTime;
            yield return null;

        }

        bite = true;
        bite_coolTime = 0f;

        yield break;

    }


}

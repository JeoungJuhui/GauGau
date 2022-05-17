using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControl player;
    GameObject HP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        HP = GameObject.Find("HP");
    }

    // Update is called once per frame
    void Update()
    {
        hp_image();
    }

    void hp_image()
    {
        Debug.Log(player.playerHP);

        switch (player.playerHP)
        {
            case 0:
                HP.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 1:
                HP.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 2:
                HP.transform.GetChild(2).gameObject.SetActive(false);
                break;
        }

            
    }
}

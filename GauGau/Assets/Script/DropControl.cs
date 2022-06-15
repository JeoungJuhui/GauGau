using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropControl : MonoBehaviour
{
    GameControl gameControl;
    public GameObject dropPos;
    public GameObject dropBox;
    GameObject player;


    float time=0f;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float progress = gameControl.progress;
        float temp;
        if (gameControl.stage == 4)
            temp = 8.0f;
        else
            temp = 10f;
        if(gameControl.stage>2 && time>temp)
        {
            Debug.Log("Drop");
            Create_Pos(dropPos,0.6f);
            Create_Pos(dropBox, 11f);

            time = 0f;
        }

    }

    void Create_Pos(GameObject obj, float hight)
    {
        int random = Random.Range(0, 3);
        GameObject go = GameObject.Instantiate(obj) as GameObject;

        float z = player.transform.position.z;
        float x = player.transform.position.x;
        go.transform.position = new Vector3(x, hight, z); // 블록의 위치를 이동.
    }

}

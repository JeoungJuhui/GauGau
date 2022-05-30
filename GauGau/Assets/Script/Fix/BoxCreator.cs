using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    GameControl gameControl;

    public GameObject box;
    public GameObject score;
    public GameObject pool;
    public float block;

    

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        block = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);
        

        if(block>=12)
        {
            create_box(box, gameControl.stage);
            block = 0f;
        }

        if (block == 6)
        {
            create_box(score, 1);
            block += 1;
        }
    }

    void create_box(GameObject obj, int stage)
    {
        int random = Random.Range(0, 3);
        GameObject go = GameObject.Instantiate(obj) as GameObject;
        go.transform.position = gameObject.transform.GetChild(random).position; // 블록의 위치를 이동.

        if (stage == 2)
        {
            int random2 = Random.Range(0, 3);
            if (random != random2)
            {
                GameObject go2 = GameObject.Instantiate(obj) as GameObject;
                go2.transform.position = gameObject.transform.GetChild(random2).position; // 블록의 위치를 이동.
            }
        }

        else if (stage >= 3)
        {
            int random2 = Random.Range(0, 3);
            if (random == random2)
            {
                if (random2 == 2)
                    random2 -= 1;
                else
                    random2 += 1;
            }

            GameObject go2 = GameObject.Instantiate(obj) as GameObject;
            go2.transform.position = gameObject.transform.GetChild(random2).position; // 블록의 위치를 이동.
        }

        if (stage == 4)
        {
            int random3 = Random.Range(0, 10);
            Debug.Log(random3);
            if (random3 >= 8)
            {
                GameObject go2 = GameObject.Instantiate(pool) as GameObject;
                go2.transform.position = gameObject.transform.GetChild(1).position; // 블록의 위치를 이동.
            }
        }


    }
}

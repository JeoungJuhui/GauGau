using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironCreate : MonoBehaviour
{
    GameControl gameControl;
    MapCreator mapCreator;
    BoxCreator boxCreator;


    public GameObject[] road;
    public GameObject[] backGround;
    public int temp;
    float count=0;
    
    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        mapCreator = GameObject.Find("GameRoot").GetComponent<MapCreator>();
        boxCreator = GameObject.Find("BoxRoot").GetComponent<BoxCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);

        temp = gameControl.stage - 1;
        if (temp >= 3)
            temp = 3;
        Debug.Log(count);
        if (count != boxCreator.block)
        {
            if (count == 0)
            {
                create_obj(road[temp]);
            }

            if (count == 3)
            {
                create_obj(backGround[temp]);
                count += 1;
            }
            count = boxCreator.block;

        }

    }

    void create_obj(GameObject obj)
    {
        GameObject go = GameObject.Instantiate(obj) as GameObject;
        go.transform.position = gameObject.transform.GetChild(0).position; // 블록의 위치를 이동.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    GameControl gameControl;

    public GameObject box;
    public GameObject score;
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

        if(block>=10)
        {
            create_box(box);
            block = 0f;
        }

        if (block == 5)
        {
            create_box(score);
            block += 1;
        }
    }

    void create_box(GameObject obj)
    {
        int random = Random.Range(0, 3);
        GameObject go = GameObject.Instantiate(obj) as GameObject;
        go.transform.position = gameObject.transform.GetChild(random).position; // 블록의 위치를 이동.

    }
}

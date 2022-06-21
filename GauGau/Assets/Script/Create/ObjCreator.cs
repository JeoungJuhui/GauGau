using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCreator : MonoBehaviour
{
    GameObject obj;
    GameObject createPos;
    GameObject createTime;

    GameControl gameControl;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //오브젝트 생성
    }

    void create_obj(GameObject obj)
    {
        int random = Random.Range(0, 3);
        GameObject go = GameObject.Instantiate(obj) as GameObject;
        go.transform.position = createPos.transform.position; //어디서 생성하는가
    }
}

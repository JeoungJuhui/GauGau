using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjControl : MonoBehaviour
{
    GameControl gameControl;
    public MapCreator map_creator = null; // MapCreator를 보관하는 변수.


    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        map_creator = GameObject.Find("GameRoot").GetComponent<MapCreator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);
        if (this.map_creator.isDelete(this.gameObject))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}

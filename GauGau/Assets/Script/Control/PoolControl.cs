using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    GameObject player;
    PlayerControl playerControl;
    GameControl gameControl;
  



    public MapCreator map_creator = null; // MapCreator�� �����ϴ� ����.


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();

        map_creator = GameObject.Find("GameRoot").GetComponent<MapCreator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (this.map_creator.isDelete(this.gameObject))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

   


}

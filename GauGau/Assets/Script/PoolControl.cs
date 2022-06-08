using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    GameObject player;
    PlayerControl playerControl;
    GameControl gameControl;
    MeshRenderer meshRenderer;
    private float pool_time=3.0f;

    public Material poolmaterial;
    public Material defaultmaterial;

    public MapCreator map_creator = null; // MapCreator를 보관하는 변수.


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        meshRenderer = player.GetComponent<MeshRenderer>();

        map_creator = GameObject.Find("GameRoot").GetComponent<MapCreator>();


        meshRenderer.material = defaultmaterial;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.map_creator.isDelete(this.gameObject))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StartCoroutine(InPool());
        }
    }

    IEnumerator InPool()
    {
        playerControl.ispool = true;
        float temp = 0f;
        gameControl.gameSpeed = 8.0f;

        meshRenderer.material = poolmaterial;

        while (temp < pool_time)
        {
            temp += Time.deltaTime;
            yield return null;

        }

        meshRenderer.material = defaultmaterial;

        gameControl.gameSpeed = 13.0f;
        playerControl.ispool = false;

        yield break;

        

    }


}

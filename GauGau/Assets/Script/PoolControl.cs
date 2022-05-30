using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    PlayerControl playerControl;
    GameControl gameControl;

    public float pool_time=5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

        while (temp < pool_time)
        {
            temp += Time.deltaTime;
            gameControl.gameSpeed = 8.0f;
            yield return null;

        }

        gameControl.gameSpeed = 13.0f;
        playerControl.ispool = false;

        yield break;

        

    }


}

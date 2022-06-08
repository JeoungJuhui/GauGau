using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    GameControl gameControl;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);
        time += Time.deltaTime;

        if (time >= 3.0f)
            transform.Translate(-Vector3.up * gameControl.gameSpeed * Time.deltaTime);
    }

}

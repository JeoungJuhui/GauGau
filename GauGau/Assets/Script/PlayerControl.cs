using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 6.0f;
    public float screenedge = 10f;
    public int playerPos = 2;
    float camera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.Find("Main Camera").transform.position.x;


        //this.transform.Translate(new Vector3(0.0f, 0.0f, 3.0f * Time.deltaTime));

        transform.Translate(Vector3.forward * 3.0f * Time.deltaTime);


        //switch-case나 FSM으로 변경
        if(camera+ screenedge > gameObject.transform.position.x)
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (camera - screenedge < gameObject.transform.position.x)
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.back * speed*1.5f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && playerPos != 1)
        {
            Debug.Log("W");
            transform.position += new Vector3(0, 0, 1.0f);
            playerPos -= 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && playerPos != 3)
        {
            Debug.Log("S");

            transform.position += new Vector3(0, 0, -1.0f);
            playerPos +=1;
        }

    }

}

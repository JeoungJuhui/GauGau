using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CameraControl cameraControl;
    float camera;

    [SerializeField]
    public float speed = 6.0f;
    public float screenedge = 10f;
    public int playerPos = 2;
    public int playerHP = 3;
    


    // Start is called before the first frame update
    void Start()
    {
        cameraControl = GameObject.Find("Main Camera").GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.Find("Main Camera").transform.position.x;

        transform.Translate(Vector3.forward * cameraControl.gameSpeed * Time.deltaTime);

        player_Move();  

    }

    void player_Move()
    {
        //switch-case나 FSM으로 변경
        if (camera + screenedge > gameObject.transform.position.x)
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (camera - screenedge < gameObject.transform.position.x)
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.back * speed * 1.5f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && playerPos != 1)
        {
            transform.position += new Vector3(0, 0, 2.0f);
            playerPos -= 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && playerPos != 3)
        {
            transform.position += new Vector3(0, 0, -2.0f);
            playerPos += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
         if (other.gameObject.tag == "Box")
            {
                GameObject.Destroy(other.gameObject);
                playerHP -= 1;
            }
        
        if (other.gameObject.tag == "bone")
        {
            GameObject.Destroy(other.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    GameControl gameControl;
    float camera;


    [SerializeField]
    public float speed = 13.0f;
    public float screenedge = 10f;
    public int playerPos = 2;
    public int playerHP = 3;
    public float score;
    


    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 이동
        player_Move();

        //카메라 이동에 맞춰 이동
        camera = GameObject.Find("Main Camera").transform.position.x;
        transform.Translate(Vector3.forward * gameControl.gameSpeed * Time.deltaTime);

        //점수 체크
        score += Time.deltaTime;
  

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

            if (playerHP <= 0)
                gameControl.GameOver();
            }
        
        if (other.gameObject.tag == "bone")
        {
            GameObject.Destroy(other.gameObject);
            score += 5.0f;
        }
    }

}

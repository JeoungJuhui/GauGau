using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    GameControl gameControl;
    MusicControl musicControl;
    MeshRenderer meshRenderer;

    float camera;
    public int hp;

    public Material poolmaterial;
    public Material defaultmaterial;
    private float pool_time = 3.0f;


    [SerializeField]
    public float speed = 13.0f;
    public float screenedge = 10f;
    public int playerPos = 2;
    public int playerHP = 3;
    public float score;
    public bool ispool;
    


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        musicControl = GameObject.Find("EventSystem").GetComponent<MusicControl>();
        ispool = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �̵�
        if(!ispool)
            player_Move();

        //ī�޶� �̵��� ���� �̵�
        camera = GameObject.Find("Main Camera").transform.position.x;
        transform.Translate(Vector3.forward * gameControl.gameSpeed * Time.deltaTime);

        //���� üũ
        score += Time.deltaTime;
  

    }

    void player_Move()
    {
        //switch-case�� FSM���� ����
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
                musicControl.HurtSound();
                playerHP -= 1;

            if (playerHP <= 0)
                gameControl.GameOver();
            }
        
        if (other.gameObject.tag == "bone")
        {
            GameObject.Destroy(other.gameObject);
            musicControl.GetCoinSound();
            score += 5.0f;
        }

        if (other.gameObject.tag == "Pool" && !ispool)
        {
            hp = playerHP;
            StartCoroutine(InPool());
        }
    }

    IEnumerator InPool()
    {
        ispool = true;
        float temp = 0f;
        gameControl.gameSpeed = 8.0f;

        meshRenderer.material = poolmaterial;

        while (temp < pool_time)
        {
            //Debug.Log(temp);
            temp += Time.deltaTime;

            if (hp != playerHP)
            {
                hp = playerHP;
                break;
            }

            yield return null;

        }

        meshRenderer.material = defaultmaterial;

        gameControl.gameSpeed = 13.0f;
        ispool = false;

        yield break;



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    GameControl gameControl;


    public float speed = 13.0f;
    public float screenedge = 10f;
    public int playerPos = 2;


    protected Transform player;

    public enum PlayerState
    {
        Run,
        Move,
        Pool,
        Bark,
        Bite,
        hurt
    }

    [SerializeField]
    protected PlayerState state;

    public PlayerState GetState()
    {
        return state;
    }

    public void SetState(PlayerState state)
    {
        this.state = state;
    }

    public void SetState(PlayerState from, PlayerState to)
    {
        if (state != from) return;
        state = to;
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        state = PlayerState.Run;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();

    }

    protected virtual void Update()
    {

        switch (state)
        {
            case PlayerState.Run:
                transform.Translate(Vector3.forward * gameControl.gameSpeed * Time.deltaTime);
                player_Move();
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                    SetState(PlayerState.Run, PlayerState.Move);
                break;

            case PlayerState.Move:
                StartCoroutine(IsMove());
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
                    SetState(PlayerState.Move, PlayerState.Run);
                break;

            case PlayerState.Pool:
                break;
            case PlayerState.Bark:
                break;
            case PlayerState.Bite:
                break;
            case PlayerState.hurt:
                break;
               
        }
    }


    void player_Move()
    {
        string key = Input.inputString;
        Debug.Log(key);

        switch (key)
        {
            case "w":
                if (playerPos != 1)
                {
                    transform.position += new Vector3(0, 0, 2.0f);
                    playerPos -= 1;
                }
                break;
            case "s":
                if (playerPos != 3)
                {
                    transform.position += new Vector3(0, 0, -2.0f);
                    playerPos += 1;
                }
                break;
        }
    }

    IEnumerator IsMove()
    {
        float camera = GameObject.Find("Main Camera").transform.position.x;


        while (state == PlayerState.Move)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (camera + screenedge > gameObject.transform.position.x)
                    transform.Translate(Vector3.forward * speed * 3f * Time.deltaTime );
                break;
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (camera - screenedge < gameObject.transform.position.x)
                    transform.Translate(Vector3.back * speed * 1.5f * Time.deltaTime);
                break;
            }
            yield return null;
        }

        yield break;
    

    }
}

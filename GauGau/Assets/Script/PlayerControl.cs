using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : PlayerFSM
{
    GameControl gameControl;
    MusicControl musicControl;
    MeshRenderer meshRenderer;

    public int hp;

    public Material poolmaterial;
    public Material defaultmaterial;
    private float pool_time = 3.0f;


    [SerializeField]
    public int playerHP = 3;
    public float score;
    public bool ispool;
    


    // Start is called before the first frame update
    override protected void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        musicControl = GameObject.Find("EventSystem").GetComponent<MusicControl>();
        ispool = false;
        score = 0;

        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        //점수 체크
        score += Time.deltaTime;

        base.Update();
  
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        string name = other.tag;
        switch(name)
        {
            case "Box":
                {
                    GameObject.Destroy(other.gameObject);
                    musicControl.HurtSound();
                    playerHP -= 1;

                    if (playerHP <= 0)
                        gameControl.GameOver();
                }
                break;
            case "bone":
                {
                    GameObject.Destroy(other.gameObject);
                    musicControl.GetCoinSound();
                    score += 5.0f;
                }
                break;
            case "Pool":
                {
                    if (!ispool)
                    {
                        hp = playerHP;
                        StartCoroutine(InPool());
                    }
                }
                break;
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

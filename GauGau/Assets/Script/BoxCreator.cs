using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    public GameObject box;
    public float block;
    CameraControl camera;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        block = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * camera.gameSpeed * Time.deltaTime);
        if(block>=8)
        {
            create_box();
            block = 0f;
        }
    }

    void create_box()
    {
        Debug.Log("Box");
        int random = Random.Range(0, 3);
        GameObject go = GameObject.Instantiate(box) as GameObject;
        go.transform.position = gameObject.transform.GetChild(random).position; // 블록의 위치를 이동.

    }
}

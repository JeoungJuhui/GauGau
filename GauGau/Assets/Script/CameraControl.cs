using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameControl gameControl;


    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();

        this.player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameControl.gameSpeed = GameObject.Find("EventSystem").GetComponent<GameControl>().gameSpeed;

        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);

    }
}

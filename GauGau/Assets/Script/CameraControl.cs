using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float gameSpeed = 3;

    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.right * gameSpeed * Time.deltaTime);

    }
}

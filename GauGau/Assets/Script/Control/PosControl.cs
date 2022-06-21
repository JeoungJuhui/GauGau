using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosControl : MonoBehaviour
{
    GameControl gameControl;
    MeshRenderer meshRenderer;

    public Material first;
    public Material second;
    public Material third;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * gameControl.gameSpeed * Time.deltaTime);
        time += Time.deltaTime;
        if (time < 1f)
            meshRenderer.material = first;
        else if (1f < time && time < 2f)
            meshRenderer.material = second;
        else
            meshRenderer.material = third;

        if (time >= 3.0f)
            Destroy(gameObject);
    }
}

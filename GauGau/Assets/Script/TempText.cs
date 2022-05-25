using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempText : MonoBehaviour
{
    public GameControl gameControl;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = GameObject.Find("EventSystem").GetComponent<GameControl>();
        text = gameObject.GetComponent<Text>();
        text.text = "Score: "+ gameControl.scoretemp;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

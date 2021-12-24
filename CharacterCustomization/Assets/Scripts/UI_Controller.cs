using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UI_Controller : MonoBehaviour
{

    TMP_Text TextName;
    TMP_Text TextSpeed;
    TMP_Text TextJump;
    TMP_Text TextPower;
    TMP_Text TextHorizontal;
    TMP_Text TextVertical;
    Toggle Dash;
    Toggle Fly;
    Toggle Ghost;

    
    // Start is called before the first frame update
    void Start()
    {


        TextName = GetComponent<TMP_Text>();
        TextSpeed = GetComponent<TMP_Text>();
        TextJump = GetComponent<TMP_Text>();
        TextPower = GetComponent<TMP_Text>();
        TextHorizontal = GetComponent<TMP_Text>();
        TextVertical = GetComponent<TMP_Text>();
        Dash = GetComponent<Toggle>(); 
        Fly = GetComponent<Toggle>();
        Ghost = GetComponent<Toggle>();


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Dash.isOn == true)
        {

        }
        */
    }
}

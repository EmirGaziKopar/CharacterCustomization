using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    int footIndis;
    int headIndis;
    ObjectController FootObjectController;
    [SerializeField] GameObject pointerFootObjectController;
    ObjectController HeadObjectController;
    [SerializeField] GameObject pointerHeadFootObjectController;

    [SerializeField] public TMP_InputField TextName;
    [SerializeField] public TMP_InputField TextSpeed;
    [SerializeField] public TMP_InputField TextJump;
    [SerializeField] public TMP_InputField TextPower;
    [SerializeField] public TMP_InputField weight;
    [SerializeField] public TMP_InputField height;
    public float weightt;
    public float heightt;
    [SerializeField] TMP_Text alertText;

    float time;

    [SerializeField] Toggle Dash;
    [SerializeField] Toggle Fly;
    [SerializeField] Toggle Ghost;

    // Start is called before the first frame update
    void Start()
    {
        //gösterecek olduðumuz indislerin deðerlerini alýyoruz bunlarýn hepsini json olarak kaydedeceðiz
        FootObjectController = pointerFootObjectController.GetComponent<ObjectController>();
        footIndis = FootObjectController.indis;

        HeadObjectController = pointerHeadFootObjectController.GetComponent<ObjectController>();
        headIndis = HeadObjectController.indis;

        /*
        TextName.text = "0";
        TextSpeed.text = "0";
        TextJump.text = "0";
        TextPower.text = "0";
        weight.text = "0";
        height.text = "0";
        */
        
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {               
        if(alertText.text != null)
        {
            time += Time.deltaTime;
            if (time > 2)
            {
                Debug.Log("Time : " + time);
                alertText.text = null;
                time = 0;
            }
        }
    }

    public void ChangeMan()
    {
        
        //.text demeyi unuttum ondan dolayi biraz vakit kaybettim. Bundan sonra daha dikkatli olmaya calis.
        try
        {
            
            if (weight.text != "") //Biri olmadan digeri birsey ifade etmez
            {
                weightt = Convert.ToSingle(weight.text);
                if(height.text == "")
                {
                    alertText.text = "Height kutusunu da gir!";
                    heightt = 0;
                }
                
            }
            if(height.text != "")
            {
                heightt = Convert.ToSingle(height.text);
                if(weight.text == "")
                {
                    alertText.text = "Weight kutusunu da gir !";
                    weightt = 0;
                }
                
            }
            if (heightt > 2)
            {
                alertText.text = "2'den buyuk deger giremezsiniz";
                heightt = 2;                
                height.text = "2";
                                                
            }
            if (weightt > 2)
            {
                alertText.text = "2'den buyuk deger giremezsiniz";
                weightt = 2;
                weight.text = "2";
            }

            if(heightt < 0)
            {
                alertText.text = "minimum 0 degeri girebilirsiniz";              
                heightt = 0;
                height.text = "0";
            }

            if(weightt < 0)
            {
                alertText.text = "minimum 0 degeri girebilirsiniz";
                weightt = 0;
                weight.text = "0";
            }
        }
        catch
        {
            alertText.text = "hatali bir sayi girdiniz";
            weightt = 1;
            heightt = 1;
            weight.text = "1";
            height.text = "1";
        }
        
    }
}

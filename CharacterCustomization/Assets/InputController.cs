using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] TMP_InputField weight;
    [SerializeField] TMP_InputField height;
    public float weightt;
    public float heightt;
    [SerializeField] TMP_Text alertText;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        weight.text = "0";
        height.text = "0";
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
            
            if (weight != null && height != null) //Biri olmadan digeri birsey ifade etmez
            {
                weightt = Convert.ToSingle(weight.text);
                heightt = Convert.ToSingle(height.text);
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
        }
        
    }
}

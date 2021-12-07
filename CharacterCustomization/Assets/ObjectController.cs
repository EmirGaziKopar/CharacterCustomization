using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    

    [SerializeField] GameObject[] dizi = new GameObject[5];
    int indis;
    // Start is called before the first frame update
    void Start()
    {
        indis = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dizi.Length; i++)
        {
            if (indis != i) //yani aradýðýmýz indise eþit degilse yok olabilir.
            {
                dizi[i].SetActive(false);
            }
            else
            {
                dizi[i].SetActive(true);
            }
        }
    }


    public void nextButton()
    {
        indis++;
        if (indis >= dizi.Length)
        {
            indis = 0;
        }
        
        
    }

    public void backButton()
    {
        if(indis > 0)
        {
            indis--;
        }    
    }
}

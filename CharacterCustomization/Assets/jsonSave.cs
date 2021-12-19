using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Bilgiler
{
    public List<BilgiHavuzu> BilgiHavuzu = new List<BilgiHavuzu>();  
}

[System.Serializable]
public class BilgiHavuzu
{
    public int footIndis; //d��ar�dan buraya indis de�erini girece�im yani kaydedece�im 
    public int headIndis;
    public float speed;
    public float jump;
    public float power; //g��l� �utu temsil eder
    public bool Dash;
    public bool Fly;
    public bool Ghost;
    public string nameAl;
}




public class jsonSave : MonoBehaviour
{
    int sayac;
    int buttonDegeri;

    private void Start()
    {
        sayac = 0;
        buttonDegeri = 1;
    }
    

    public void btn1()
    {
        buttonDegeri = 1;
    }
    public void btn2()
    {
        buttonDegeri = 2;
    }
    public void btn3()
    {
        buttonDegeri = 3;
    }
    public void btn4()
    {
        buttonDegeri = 4;
    }


    //Her kaydet'e bas�ld���nda yeni bir de�er eklenecek
    public void json_Kaydet(Bilgiler bilgiler)
    {
        sayac++;
        if (sayac <= 4)
        {
            string jsonBilgiler = JsonUtility.ToJson(bilgiler); //json'a �evirdik
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Bilgilerim.json" + sayac.ToString(), jsonBilgiler); //kayit ettik
        }
        else
        {
            //slotlar dolu mesaji d�nd�r
        }
    }
    public  Bilgiler bilgiler_oku()
    {
     
        string jsonVeri = System.IO.File.ReadAllText(Application.persistentDataPath + "/Bilgilerim.json"+buttonDegeri.ToString());
        Bilgiler okunanBilgi = JsonUtility.FromJson<Bilgiler>(jsonVeri);
        return okunanBilgi;
    }
}

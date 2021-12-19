using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bilgiler
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
    

    public void json_Kaydet(Bilgiler bilgiler)
    {
        string jsonBilgiler = JsonUtility.ToJson(bilgiler); //json'a �evirdik
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Bilgilerim.json", jsonBilgiler); //kayit ettik
    }
    public  Bilgiler bilgiler_oku()
    {
        string jsonVeri = System.IO.File.ReadAllText(Application.persistentDataPath + "/Bilgilerim.json");
        Bilgiler okunanBilgi = JsonUtility.FromJson<Bilgiler>(jsonVeri);

        return okunanBilgi;
    }
}

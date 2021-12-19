using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bilgiler
{

    public int footIndis; //dýþarýdan buraya indis deðerini gireceðim yani kaydedeceðim 
    public int headIndis;
    public float speed;
    public float jump;
    public float power; //güçlü þutu temsil eder
    public bool Dash;
    public bool Fly;
    public bool Ghost;
    public string nameAl;
    
}


public class jsonSave : MonoBehaviour
{
    

    public void json_Kaydet(Bilgiler bilgiler)
    {
        string jsonBilgiler = JsonUtility.ToJson(bilgiler); //json'a çevirdik
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Bilgilerim.json", jsonBilgiler); //kayit ettik
    }
    public  Bilgiler bilgiler_oku()
    {
        string jsonVeri = System.IO.File.ReadAllText(Application.persistentDataPath + "/Bilgilerim.json");
        Bilgiler okunanBilgi = JsonUtility.FromJson<Bilgiler>(jsonVeri);

        return okunanBilgi;
    }
}

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
    public float weight;
    public float height;
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
        if (sayac <= 4) //Buradaki de�er art�r�larak kaydedilecek karakter say�s�n� dinamik bir hale getirebiliriz. Ama buttonlar�n nas�l dinamik yap�caz o ayr� mesele listView benzeri yap�larla oda olur.
        {
            string jsonBilgiler = JsonUtility.ToJson(bilgiler); //json'a �evirdik
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Bilgilerim"+ sayac.ToString()+".json", jsonBilgiler); //kayit ettik
            Debug.Log(Application.persistentDataPath);

        }
        else
        {
            //slotlar dolu mesaji d�nd�r
        }
    }
    public  Bilgiler bilgiler_oku()
    {
     
        string jsonVeri = System.IO.File.ReadAllText(Application.persistentDataPath + "/Bilgilerim"+buttonDegeri.ToString() + ".json");
        Bilgiler okunanBilgi = JsonUtility.FromJson<Bilgiler>(jsonVeri);
        return okunanBilgi;
    }
}

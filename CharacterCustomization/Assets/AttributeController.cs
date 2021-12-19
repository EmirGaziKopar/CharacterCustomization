using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AttributeController : MonoBehaviour
{
    //Kay�t etme i�lemini ya bu dizinde ger�ekle�tir ya da t�m �zelliklerin girildi�i InputController'da 
    //�uan i�in o k�sm� pek bilmedi�imden karar veremiyorum yar�n ��rendikten sonra karar ver.

    [SerializeField] GameObject inputControllerGameObject;
    InputController controller; //Buradaki b�t�n de�erlere ula�abiliriz. 


    [SerializeField] GameObject objectControllerPointerHead;
    [SerializeField] GameObject objectControllerPointerFoot;
    ObjectController headObjetController;
    ObjectController footObjectController;

    float height = 0;
    float weight = 0;

    float speed = 0;
    float jump = 0;
    float power = 0; //g��l� �utu temsil eder
    bool Dash;
    bool Fly;
    bool Ghost;
    [SerializeField] TMP_Text nameAl = null;
    string name; //do�rudan obje �zerine bir tmp texta��l�p buraya gelen name de�eri oraya g�nderilmelidir veya direk burada tmp_Inputfield olu�tur onu buraya s�r�kle
    int footIndis; //Bunlar objectController i�erisindeki foot objecsinin i�indeki indis de�eri yerine girilecek(oyun ba�lamadan �nce start'da veya awake'de)
    int headIndis; //Bunlar objectController i�erisindeki head objecsinin i�indeki indis de�eri yerine girilecek(oyun ba�lamadan �nce start'da veya awake'de)

    


    // Start is called before the first frame update
    void Start()
    {
        controller = inputControllerGameObject.GetComponent<InputController>();

        headObjetController = objectControllerPointerHead.GetComponent<ObjectController>();
        
    }

    public void bilgleriKaydet()
    {
        if(jump != 0 && nameAl.text != null && speed != 0 && power != 0 && controller.weightt != 0 && controller.heightt != 0)
        {
            jsonSave jsonSave = GetComponent<jsonSave>(); //ayn� gameObject �zerinde olduklar� i�in bu yeterli

            Bilgiler bilgiler = new Bilgiler();
            bilgiler.Dash = Dash;
            bilgiler.Fly = Fly;
            bilgiler.Ghost = Ghost;
            bilgiler.footIndis = footIndis;
            bilgiler.headIndis = headIndis;
            bilgiler.jump = jump;
            bilgiler.nameAl = nameAl.text;
            bilgiler.power = power;
            bilgiler.speed = speed;
            bilgiler.weight = controller.weightt;
            bilgiler.height = controller.heightt;
            jsonSave.json_Kaydet(bilgiler); //information saved
            controller.alertText.color = Color.green;
            controller.alertText.text = "karakter olu�turuldu";
        }
        else
        {
            controller.alertText.text = "Halen Girilmeyen degerler var !!!";
        }
         

        //daha sonra bu kaydedilen verileri bir diziye aktar�p birden fazla karakterin bilgilerini kaydetmeyi dene
        
    }

    
    public void yerlestir()
    {

        Dash = okunanBilgi.Dash;
        Fly = okunanBilgi.Fly;
        Ghost = okunanBilgi.Ghost;
        headObjetController.indis = okunanBilgi.headIndis;
        footObjectController.indis = okunanBilgi.footIndis;
        height = okunanBilgi.height;
        weight = okunanBilgi.weight;
        nameAl.text = okunanBilgi.nameAl;

    }
    public Bilgiler okunanBilgi; 

    public void BilgileriOku() //hata vermesin diye void yazd�m �imdilik. Ger�i zaten y�kleyece�imiz veriler bu izinde oldu�u i�in return kullanmay�z  
    {
        jsonSave jsonSave = GetComponent<jsonSave>();
        okunanBilgi = jsonSave.bilgiler_oku();

        /*Dash = okunanBilgi.Dash;
        Fly = okunanBilgi.Fly;
        Ghost = okunanBilgi.Ghost;
        headObjetController.indis = okunanBilgi.headIndis;
        height = okunanBilgi.height;
        weight = okunanBilgi.weight;
        nameAl.text = okunanBilgi.nameAl;*/ 
    }

    // Update is called once per frame
    void Update()
    {
        

        try
        {

            if (controller != null)
            {


                transform.localScale = new Vector3(controller.weightt, controller.heightt, transform.localScale.z);
                nameAl.text = controller.TextName.text;
                footIndis = controller.footIndis;
                headIndis = controller.headIndis;
                Dash = controller.Dash;
                Fly = controller.Fly;
                Ghost = controller.Ghost;
                speed = Convert.ToSingle(controller.TextSpeed.text);
                jump = Convert.ToSingle(controller.TextPower.text);
                power = Convert.ToSingle(controller.TextPower.text);



            }
            else
            {
                BilgileriOku();
            }

        }
        catch
        {
            Debug.Log("Hata var");
        }



    }
}

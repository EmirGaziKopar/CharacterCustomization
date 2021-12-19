using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AttributeController : MonoBehaviour
{
    //Kay�t etme i�lemini ya bu dizinde ger�ekle�tir ya da t�m �zelliklerin girildi�i InputController'da 
    //�uan i�in o k�sm� pek bilmedi�imden karar veremiyorum yar�n ��rendikten sonra karar ver.

    [SerializeField] GameObject inputControllerGameObject;

    InputController controller; //Buradaki b�t�n de�erlere ula�abiliriz. 

    float speed;
    float jump;
    float power; //g��l� �utu temsil eder
    bool Dash;
    bool Fly;
    bool Ghost;
    [SerializeField] TMP_Text nameAl;
    string name; //do�rudan obje �zerine bir tmp texta��l�p buraya gelen name de�eri oraya g�nderilmelidir veya direk burada tmp_Inputfield olu�tur onu buraya s�r�kle
    int footIndis; //Bunlar objectController i�erisindeki foot objecsinin i�indeki indis de�eri yerine girilecek(oyun ba�lamadan �nce start'da veya awake'de)
    int headIndis; //Bunlar objectController i�erisindeki head objecsinin i�indeki indis de�eri yerine girilecek(oyun ba�lamadan �nce start'da veya awake'de)




    // Start is called before the first frame update
    void Start()
    {
        controller = inputControllerGameObject.GetComponent<InputController>();

    }

    public void bilgleriKaydet()
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
        
    }


    public void BilgileriOku() //hata vermesin diye void yazd�m �imdilik. Ger�i zaten y�kleyece�imiz veriler bu izinde oldu�u i�in return kullanmay�z  
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(controller.weightt, controller.heightt, transform.localScale.z);
        Debug.Log("degerler: " + controller.weightt + " " + controller.heightt);
        nameAl.text = controller.TextName.text;              
    }
}

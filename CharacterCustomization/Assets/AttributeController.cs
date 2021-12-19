using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AttributeController : MonoBehaviour
{
    //Kayýt etme iþlemini ya bu dizinde gerçekleþtir ya da tüm özelliklerin girildiði InputController'da 
    //Þuan için o kýsmý pek bilmediðimden karar veremiyorum yarýn öðrendikten sonra karar ver.

    [SerializeField] GameObject inputControllerGameObject;
    InputController controller; //Buradaki bütün deðerlere ulaþabiliriz. 


    [SerializeField] GameObject objectControllerPointerHead;
    [SerializeField] GameObject objectControllerPointerFoot;
    ObjectController headObjetController;
    ObjectController footObjectController;

    float height = 0;
    float weight = 0;

    float speed = 0;
    float jump = 0;
    float power = 0; //güçlü þutu temsil eder
    bool Dash;
    bool Fly;
    bool Ghost;
    [SerializeField] TMP_Text nameAl = null;
    string name; //doðrudan obje üzerine bir tmp textaçýlýp buraya gelen name deðeri oraya gönderilmelidir veya direk burada tmp_Inputfield oluþtur onu buraya sürükle
    int footIndis; //Bunlar objectController içerisindeki foot objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)
    int headIndis; //Bunlar objectController içerisindeki head objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)

    


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
            jsonSave jsonSave = GetComponent<jsonSave>(); //ayný gameObject üzerinde olduklarý için bu yeterli

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
            controller.alertText.text = "karakter oluþturuldu";
        }
        else
        {
            controller.alertText.text = "Halen Girilmeyen degerler var !!!";
        }
         

        //daha sonra bu kaydedilen verileri bir diziye aktarýp birden fazla karakterin bilgilerini kaydetmeyi dene
        
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

    public void BilgileriOku() //hata vermesin diye void yazdým þimdilik. Gerçi zaten yükleyeceðimiz veriler bu izinde olduðu için return kullanmayýz  
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

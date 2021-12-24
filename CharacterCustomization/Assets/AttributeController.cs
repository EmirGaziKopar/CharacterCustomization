using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AttributeController : MonoBehaviour
{



    Rigidbody2D rigidbody2D;

    public enum SelectScene
    {
        gameScene, customizationScene
    }

    [SerializeField] SelectScene selectScene;

    //Kayýt etme iþlemini ya bu dizinde gerçekleþtir ya da tüm özelliklerin girildiði InputController'da 
    //Þuan için o kýsmý pek bilmediðimden karar veremiyorum yarýn öðrendikten sonra karar ver.

    [SerializeField] GameObject inputControllerGameObject;
    InputController controller; //Buradaki bütün deðerlere ulaþabiliriz. 



    [SerializeField] GameObject objectControllerPointerHead;
    [SerializeField] GameObject objectControllerPointerFoot;
    ObjectController headObjectController;
    ObjectController footObjectController;

    public float height = 0;
    public float weight = 0;

    public float speed = 0;
    public float jump = 0;
    public float power = 0; //güçlü þutu temsil eder
    public bool Dash;
    public bool Fly;
    public bool Ghost;
    [SerializeField] TMP_Text nameAl = null;
    string name; //doðrudan obje üzerine bir tmp textaçýlýp buraya gelen name deðeri oraya gönderilmelidir veya direk burada tmp_Inputfield oluþtur onu buraya sürükle
    public int footIndis; //Bunlar objectController içerisindeki foot objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)
    public int headIndis; //Bunlar objectController içerisindeki head objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)

    


    // Start is called before the first frame update
    void Start()
    {
        if(selectScene == SelectScene.customizationScene)
        {
            controller = inputControllerGameObject.GetComponent<InputController>();
        }

        if(selectScene == SelectScene.gameScene)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        

        headObjectController = objectControllerPointerHead.GetComponent<ObjectController>();
        footObjectController = objectControllerPointerFoot.GetComponent<ObjectController>();


    }

    public void bilgleriKaydet()
    {
        if(jump != 0 && nameAl.text != null && speed != 0 && power != 0 && controller.weightt != 0 && controller.heightt != 0 && selectScene == SelectScene.customizationScene)
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
            bilgiler.headIndis = headObjectController.indis;            
            bilgiler.footIndis = footObjectController.indis;
            jsonSave.json_Kaydet(bilgiler); //information saved
            if (gameObject.GetComponent<jsonSave>().isFull == true)
            {
                controller.alertText.color = Color.red;
                controller.alertText.text = "Slotlar doldu";
            }
            else
            {
                controller.alertText.color = Color.green;
                controller.alertText.text = "karakter oluþturuldu";
            }
            
            

        }
        else
        {
            
            controller.alertText.text = "Halen Girilmeyen degerler var !!!";
        }
         

        //daha sonra bu kaydedilen verileri bir diziye aktarýp birden fazla karakterin bilgilerini kaydetmeyi dene
        
    }

    
    public void yerlestir()
    {
        if(okunanBilgi != null)
        {
            Dash = okunanBilgi.Dash;
            Fly = okunanBilgi.Fly;
            Ghost = okunanBilgi.Ghost;
            headObjectController.indis = okunanBilgi.headIndis;
            footObjectController.indis = okunanBilgi.footIndis;
            height = okunanBilgi.height;
            weight = okunanBilgi.weight;
            nameAl.text = okunanBilgi.nameAl;
            transform.localScale = new Vector3(weight, height, transform.localScale.z);
        } 
    }
    public Bilgiler okunanBilgi; 

    public void BilgileriOku() //hata vermesin diye void yazdým þimdilik. Gerçi zaten yükleyeceðimiz veriler bu izinde olduðu için return kullanmayýz  
    {
        jsonSave jsonSave = GetComponent<jsonSave>();
        okunanBilgi = jsonSave.bilgiler_oku();  
        if(okunanBilgi == null && selectScene == SelectScene.customizationScene)
        {
            controller.alertText.color = Color.red;
            controller.alertText.text = "Bu kutu boþ";
        }
        
        
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
                if(controller.TextName.text != "")
                {
                    nameAl.text = controller.TextName.text;
                }
                if(controller.TextSpeed.text != "")
                {
                    speed = Convert.ToSingle(controller.TextSpeed.text);
                }
                if(controller.TextPower.text != "")
                {
                    jump = Convert.ToSingle(controller.TextPower.text);
                }
                if (controller.TextPower.text != "")
                {
                    power = Convert.ToSingle(controller.TextPower.text);
                }

                transform.localScale = new Vector3(controller.weightt, controller.heightt, transform.localScale.z);
                
                footIndis = controller.footIndis;
                headIndis = controller.headIndis;
                Dash = controller.Dash.isOn;
                Fly = controller.Fly.isOn;
                Ghost = controller.Ghost.isOn;
                
                
                



            }
            if(selectScene == SelectScene.gameScene)
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

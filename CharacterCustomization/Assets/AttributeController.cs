using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AttributeController : MonoBehaviour
{
    //Kayýt etme iþlemini ya bu dizinde gerçekleþtir ya da tüm özelliklerin girildiði InputController'da 
    //Þuan için o kýsmý pek bilmediðimden karar veremiyorum yarýn öðrendikten sonra karar ver.

    [SerializeField] GameObject inputControllerGameObject;

    InputController controller; //Buradaki bütün deðerlere ulaþabiliriz. 

    float speed;
    float jump;
    float power; //güçlü þutu temsil eder
    bool Dash;
    bool Fly;
    bool Ghost;
    [SerializeField] TMP_Text nameAl;
    string name; //doðrudan obje üzerine bir tmp textaçýlýp buraya gelen name deðeri oraya gönderilmelidir veya direk burada tmp_Inputfield oluþtur onu buraya sürükle
    int footIndis; //Bunlar objectController içerisindeki foot objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)
    int headIndis; //Bunlar objectController içerisindeki head objecsinin içindeki indis deðeri yerine girilecek(oyun baþlamadan önce start'da veya awake'de)




    // Start is called before the first frame update
    void Start()
    {
        controller = inputControllerGameObject.GetComponent<InputController>();

    }

    public void bilgleriKaydet()
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
        
    }


    public void BilgileriOku() //hata vermesin diye void yazdým þimdilik. Gerçi zaten yükleyeceðimiz veriler bu izinde olduðu için return kullanmayýz  
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

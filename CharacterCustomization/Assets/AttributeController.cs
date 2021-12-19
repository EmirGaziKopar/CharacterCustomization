using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AttributeController : MonoBehaviour
{
    public List<Bilgiler> saveCharacters;
    
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

        BilgiHavuzu bilgiHavuzu1 = new BilgiHavuzu();



        bilgiHavuzu1.Dash = Dash;
        bilgiHavuzu1.Fly = Fly;
        bilgiHavuzu1.Ghost = Ghost;
        bilgiHavuzu1.footIndis = footIndis;
        bilgiHavuzu1.headIndis = headIndis;
        bilgiHavuzu1.jump = jump;
        bilgiHavuzu1.nameAl = nameAl.text;
        bilgiHavuzu1.power = power;
        bilgiHavuzu1.speed = speed;

        bilgiler.BilgiHavuzu.Add(bilgiHavuzu1); //Burada bilgiler.BilgiHavuzu... diyerek istenildiði kadar obje eklenebilir fakat bizim bunu otomatikleþtirmemiz lazým. Sanýrým zaten otomatik

        jsonSave.json_Kaydet(bilgiler); //information saved 
        

        //daha sonra bu kaydedilen verileri bir diziye aktarýp birden fazla karakterin bilgilerini kaydetmeyi dene

    }

    public Bilgiler okunanBilgi; 

    public void BilgileriOku() //hata vermesin diye void yazdým þimdilik. Gerçi zaten yükleyeceðimiz veriler bu izinde olduðu için return kullanmayýz  
    {
        jsonSave jsonSave = GetComponent<jsonSave>();
        okunanBilgi = jsonSave.bilgiler_oku();  //Bu okunan bilgiyi bir liste oluþturup içerisinde yerleþtirme iþlemini denemelerden sonra yap 
        //okunanBilgi.BilgiHavuzu[0] boyle bir kullanýmý varsa süper buttonlara bu þekilde atarýz. Dolu olan buttonlarý yeþil boþ olanlarý kýrmýzý felan yaparýz.
        //hata vakit kalýrsa button üzerinde karakterin özellikleri olur.
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(controller.weightt, controller.heightt, transform.localScale.z);
        Debug.Log("degerler: " + controller.weightt + " " + controller.heightt);
        nameAl.text = controller.TextName.text;              
    }
}

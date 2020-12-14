using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sinif1TimerManager : MonoBehaviour
{
   
    [SerializeField]
    private Text SureText;

    int KalanSure;

    bool SureSayilsinmi=true;

    Sinif1GameManager Sinif1GameManager;

    private void Awake()
    {
        Sinif1GameManager=Object.FindObjectOfType<Sinif1GameManager>();
    }
   


    void Start()
    {
        KalanSure=60;
        SureSayilsinmi=true;
        
    }

    public void SureyiBaslat()
    {
        StartCoroutine(SureTımerRoutine());
    }

IEnumerator SureTımerRoutine()
{
    while(SureSayilsinmi)
    {
        yield return new WaitForSeconds(1f);

        if(KalanSure<10)
        {
            SureText.text="0"+KalanSure.ToString();     //Süre 10sn den az kalınca sürenin yanına 0 ekleyerek estetik görüntü sağlandı.
        }
        else
        {
            SureText.text=KalanSure.ToString();
            
        }

        if(KalanSure<=0)
        {
            SureSayilsinmi=false;
            SureText.text="";
            Sinif1GameManager.OyunSonu();
        }
       
        KalanSure--;
    }
}

}

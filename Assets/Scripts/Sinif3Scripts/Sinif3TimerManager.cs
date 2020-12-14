using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sinif3TimerManager : MonoBehaviour
{
   
    [SerializeField]
    private Text SureText;

    int KalanSure;

    bool SureSayilsinmi=true;

    Sinif3GameManager Sinif3GameManager;

    private void Awake()
    {
        Sinif3GameManager=Object.FindObjectOfType<Sinif3GameManager>();
    }
   


    void Start()
    {
        KalanSure=75;
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
            Sinif3GameManager.OyunSonu();
        }       
        KalanSure--;
    }
}

}

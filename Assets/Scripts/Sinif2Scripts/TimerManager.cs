using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
   
    [SerializeField]
    private Text SureText;

    int KalanSure;

    bool SureSayilsinmi=true;

    GameManager GameManager;

    private void Awake()
    {
        GameManager=Object.FindObjectOfType<GameManager>();
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
            GameManager.OyunSonu();
        }
       
        KalanSure--;
    }
}

}

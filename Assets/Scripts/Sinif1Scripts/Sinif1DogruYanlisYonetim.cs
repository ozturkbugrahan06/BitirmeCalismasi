using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Sinif1DogruYanlisYonetim : MonoBehaviour
{
    
    [SerializeField]
    private GameObject DogruIcon,YanlisIcon;



    void Start()
    {
        DogruIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
        YanlisIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
    }

    public void DogruYanlisAc(bool DogruYanlis)
    {
        if(DogruYanlis)
        {
            DogruIcon.GetComponent<RectTransform>().DOScale(1,0.2f);
            YanlisIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
        }
        else
        {
            YanlisIcon.GetComponent<RectTransform>().DOScale(1,0.2f);
            DogruIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
        }

        Invoke("DogruYanlisKapat",0.5f);  //Fonksiyonu belli bi süre sonra çalıştırma
    }

    void DogruYanlisKapat()
    {
        DogruIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
        YanlisIcon.GetComponent<RectTransform>().localScale=Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sinif3DairelerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] DaireDizi;


    void Start()
    {
        DaireScaleKapat();
    }

    public void DaireScaleKapat()
    {
        foreach(GameObject Daire in DaireDizi)
        {
            Daire.GetComponent<RectTransform>().localScale=Vector3.zero;
        }
    }

   
    public void DaireScaleAc(int HangiDaire)
    {
        DaireDizi[HangiDaire].GetComponent<RectTransform>().DOScale(1,0.3f);

        if(HangiDaire%5==0)
        {
            DaireScaleKapat();
        }
    }
}

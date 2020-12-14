using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
   [SerializeField]
   private Transform Arti;

   [SerializeField]
   private Transform Eksi;

   [SerializeField]
   private Transform Carpma;
   
   [SerializeField]
   private Transform Bolme;

   [SerializeField]
   private Transform Esittir;

   [SerializeField]
   private Transform StartBtn;

   [SerializeField]
   private Transform Sinif1Buton;

   [SerializeField]
   private Transform Sinif3Buton;

   AdmobYonetici admobYonetici;

   




    void Start()
    {
       admobYonetici=Object.FindObjectOfType<AdmobYonetici>();
       admobYonetici.ShowBanner();
       Arti.transform.GetComponent<RectTransform>().DOLocalMoveX(-217f,1.5f).SetEase(Ease.OutBack);
       Eksi.transform.GetComponent<RectTransform>().DOLocalMoveY(-308f, 1.5f).SetEase(Ease.OutBack);
       Carpma.transform.GetComponent<RectTransform>().DOLocalMoveY(-308f, 1.5f).SetEase(Ease.OutBack);
       Bolme.transform.GetComponent<RectTransform>().DOLocalMoveY(-308f, 1.5f).SetEase(Ease.OutBack);
       Esittir.transform.GetComponent<RectTransform>().DOLocalMoveX(217f, 1.5f).SetEase(Ease.OutBack);

       StartBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(150f,1.5f).SetEase(Ease.OutBack);
       Sinif1Buton.transform.GetComponent<RectTransform>().DOLocalMoveY(150f,1.5f).SetEase(Ease.OutBack); 
       Sinif3Buton.transform.GetComponent<RectTransform>().DOLocalMoveY(154f,1.5f).SetEase(Ease.OutBack);    

    }
    
    public void OyunaBaslaBirinciSinif()
    {
      SceneManager.LoadScene("Sinif1Sahne");      
    }    

    public void OyunaBasla()   
    {
      SceneManager.LoadScene("Sinif2Sahne");      
    }    
    
     public void OyunaBaslaUcuncuSinif()
    {
      SceneManager.LoadScene("Sinif3Sahne");      
    }
    

    
}

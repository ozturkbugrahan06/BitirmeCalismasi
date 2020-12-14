using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Sinif3GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PuanPaneli;

    [SerializeField]
    private GameObject PausePanel;

    [SerializeField]
    private GameObject DegerlendirmePanel;

    [SerializeField]
    private GameObject BuyukOlanSayiSecYazi;

    [SerializeField]
    private GameObject UstDorgen,AltDortgen;

    [SerializeField]
    private Text UstText,AltText,PuanText;

    [SerializeField]
    private AudioClip IlkSes,DogruSes,YanlisSes,AlkisSes;

    Sinif3TimerManager Sinif3TimerManager;

    Sinif3DairelerManager Sinif3DairelerManager;

    Sinif3DogruYanlisYonetim Sinif3DogruYanlisYonetim;

    Sinif3DegerlendirmeYoneticisi Sinif3DegerlendirmeYoneticisi;

    int OyunSayac,OyunNo;

    int UstDeger,AltDeger;

    int BuyukDeger;

    int ButonDeger;

    int ToplamPuan,PuanArtis;

    int DogruSayisi,YanlisSayisi;

    private AudioSource AudioSource;
    
    private void Awake()
    {
        Sinif3TimerManager=Object.FindObjectOfType<Sinif3TimerManager>();
        Sinif3DairelerManager=Object.FindObjectOfType<Sinif3DairelerManager>();
        Sinif3DogruYanlisYonetim=Object.FindObjectOfType<Sinif3DogruYanlisYonetim>();
        AudioSource=GetComponent<AudioSource>();
    }

    void Start()
    {
        OyunNo=0;
        OyunSayac=0;
        ToplamPuan=0;
        UstText.text="";
        AltText.text="";
        PuanText.text="0";
        SahneEkraniniGuncelle();
    }

    void SahneEkraniniGuncelle()
    {
        PuanPaneli.GetComponent<CanvasGroup>().DOFade(1,1f);
        

        UstDorgen.GetComponent<RectTransform>().DOLocalMoveY(100,1f).SetEase(Ease.OutBack);         //UstDortgenin üstten gelip y=100 konumunda durması sağlandı.
        AltDortgen.GetComponent<RectTransform>().DOLocalMoveY(-100,1f).SetEase(Ease.OutBack);       //AltDortgenin üstten gelip y=-100 konumunda durması sağlandı.

        OyunaBasla();
    }

    public void OyunaBasla()
    {
        AudioSource.PlayOneShot(IlkSes);
        BuyukOlanSayiSecYazi.GetComponent<CanvasGroup>().DOFade(1,1f);
      
        oyunNo();
        Sinif3TimerManager.SureyiBaslat();
    }

    void oyunNo()
    {
        if(OyunSayac<5)
        {
            OyunNo=1;
            PuanArtis=5;
        }
        else if(OyunSayac>=5&&OyunSayac<10)
        {
            OyunNo=2;
            PuanArtis=10;            
        }
        else if(OyunSayac>=10&&OyunSayac<15)
        {
            OyunNo=3;
            PuanArtis=10;
        }
        else if(OyunSayac>=15&&OyunSayac<20)
        {
            OyunNo=4;
            PuanArtis=20;
        }
        else if(OyunSayac>=20&&OyunSayac<25)
        {
            OyunNo=5;
            PuanArtis=20;
        }
        else
        {
            OyunNo=Random.Range(1,6);
        }

        switch (OyunNo)
        {
            case 1:
            SayilarFonksiyon();
            break;
            
            case 2:
            ToplamaFonksiyon();
            break;

            case 3:
            CikarmaFonksiyon();
            break;

            case 4:
            CarpmaFonksiyon();
            break;

            case 5:
            BolmeFonksiyon();
            break;            
        }
    }

   

    void SayilarFonksiyon()
    {
        int RastgeleDeger=Random.Range(1,40);

        if(RastgeleDeger<=5)
        {
            UstDeger=Random.Range(2,20);
            AltDeger=UstDeger+Random.Range(1,20);
        }
        else
        {
            UstDeger=Random.Range(2,20);
            AltDeger=Mathf.Abs(UstDeger-Random.Range(1,30));   //Mathf fonksiyonu mutlak değer almayı sağlar.
        }

        if(UstDeger>AltDeger)
        {
            BuyukDeger=UstDeger;
        }
        else if(UstDeger<AltDeger)
        {
            BuyukDeger=AltDeger;
        }
        if(AltDeger==UstDeger)
        {
            SayilarFonksiyon();
            return;
        }

        UstText.text=UstDeger.ToString();
        AltText.text=AltDeger.ToString(); 
    }

    void ToplamaFonksiyon()
    {
        int BirinciSayi=Random.Range(1,10);
        int IkinciSayi=Random.Range(1,10);
        int UcuncuSayi=Random.Range(1,10);
        int DorduncuSayi=Random.Range(1,10);

        UstDeger=BirinciSayi+IkinciSayi;
        AltDeger=UcuncuSayi+DorduncuSayi;

        if(UstDeger>AltDeger)
        {
            BuyukDeger=UstDeger;
        }
        else if(UstDeger<AltDeger)
        {
            BuyukDeger=AltDeger;
        }
        if(UstDeger==AltDeger)
        {
            ToplamaFonksiyon();
            return;
        }

        UstText.text=BirinciSayi+"+"+IkinciSayi;
        AltText.text=UcuncuSayi+"+"+DorduncuSayi;
               
    }

    void CikarmaFonksiyon()
    {
        int BirinciSayi=Random.Range(6,20);
        int IkinciSayi=Random.Range(1,6);
        int UcuncuSayi=Random.Range(7,20);
        int DorduncuSayi=Random.Range(1,7);

        UstDeger=BirinciSayi-IkinciSayi;
        AltDeger=UcuncuSayi-DorduncuSayi;

        if(UstDeger>AltDeger)
        {
            BuyukDeger=UstDeger;
        }
        else if(UstDeger<AltDeger)
        {
            BuyukDeger=AltDeger;
        }
        if(UstDeger==AltDeger)
        {
            ToplamaFonksiyon();
            return;
        }

        UstText.text=BirinciSayi+"-"+IkinciSayi;
        AltText.text=UcuncuSayi+"-"+DorduncuSayi;
                
    }


    void CarpmaFonksiyon()
    {
        int BirinciSayi=Random.Range(1,10);
        int IkinciSayi=Random.Range(1,5);
        int UcuncuSayi=Random.Range(1,10);
        int DorduncuSayi=Random.Range(1,5);

        UstDeger=BirinciSayi*IkinciSayi;
        AltDeger=UcuncuSayi*DorduncuSayi;

        if(UstDeger>AltDeger)
        {
            BuyukDeger=UstDeger;
        }
        else if(UstDeger<AltDeger)
        {
            BuyukDeger=AltDeger;
        }
        if(UstDeger==AltDeger)
        {
            CarpmaFonksiyon();
            return;
        }

        UstText.text=BirinciSayi+" x "+IkinciSayi;
        AltText.text=UcuncuSayi+" x "+DorduncuSayi;        
    }

    void BolmeFonksiyon()
    {
        int BolenSayi1=Random.Range(1,12);
        UstDeger=Random.Range(1,12);

        int BolunenSayi1=BolenSayi1*UstDeger;
       
       int BolenSayi2=Random.Range(1,12);
       AltDeger=Random.Range(1,12);

       int BolunenSayi2=BolenSayi2*AltDeger;

        if(UstDeger>AltDeger)
        {
            BuyukDeger=UstDeger;
        }
        else if(UstDeger<AltDeger)
        {
            BuyukDeger=AltDeger;
        }
        if(UstDeger==AltDeger)
        {
            BolmeFonksiyon();
            return;
        }

        UstText.text=BolunenSayi1+" / "+BolenSayi1;
        AltText.text=BolunenSayi2+" / "+BolenSayi2;
    }

    public void ButonDegerBelirle(string ButonAdi)
    {
        if(ButonAdi=="UstButon")
        {
            ButonDeger=UstDeger;
        }
        else if(ButonAdi=="AltButon")
        {
            ButonDeger=AltDeger;
        }
        
        if(ButonDeger==BuyukDeger)
        {
            Sinif3DogruYanlisYonetim.DogruYanlisAc(true);
            Sinif3DairelerManager.DaireScaleAc(OyunSayac % 5);
            OyunSayac++;
            ToplamPuan+=PuanArtis;
            PuanText.text=ToplamPuan.ToString();
            AudioSource.PlayOneShot(DogruSes);
            DogruSayisi++;

            oyunNo();
        }
        else
        {
            Sinif3DogruYanlisYonetim.DogruYanlisAc(false);
            HatadaSayacAzalt();
            AudioSource.PlayOneShot(YanlisSes);
            YanlisSayisi++;
            oyunNo();
        }
    }

    void HatadaSayacAzalt()
    {
        OyunSayac-=(OyunSayac%5+5);

        if(OyunSayac<0)
        {
            OyunSayac=0;
        }

         Sinif3DairelerManager.DaireScaleKapat();
    }

    public void PausePaneliAc()
    {
        PausePanel.SetActive(true);
    }

    public void OyunSonu()
    {
        AudioSource.PlayOneShot(AlkisSes);
        
        DegerlendirmePanel.SetActive(true);

        Sinif3DegerlendirmeYoneticisi=Object.FindObjectOfType<Sinif3DegerlendirmeYoneticisi>();

        Sinif3DegerlendirmeYoneticisi.DegerlerdirmeEkrani(DogruSayisi,YanlisSayisi,ToplamPuan);
    }
       

}

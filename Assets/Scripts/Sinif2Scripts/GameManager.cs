using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
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

    TimerManager TimerManager;

    DairelerManager DairelerManager;

    DogruYanlisYonetim DogruYanlisYonetim;

    DegerlendirmeYoneticisi DegerlendirmeYoneticisi;

    int OyunSayac,KacinciOyun;

    int UstDeger,AltDeger;

    int BuyukDeger;

    int ButonDeger;

    int ToplamPuan,ArtisMiktari;

    int DogruSayisi,YanlisSayisi;

    private AudioSource AudioSource;
    
    private void Awake()
    {
        TimerManager=Object.FindObjectOfType<TimerManager>();
        DairelerManager=Object.FindObjectOfType<DairelerManager>();
        DogruYanlisYonetim=Object.FindObjectOfType<DogruYanlisYonetim>();
        AudioSource=GetComponent<AudioSource>();


    }

    void Start()
    {
        KacinciOyun=0;
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
      
        kacinciOyun();
        TimerManager.SureyiBaslat();
    }

    void kacinciOyun()
    {
        if(OyunSayac<3)
        {
            KacinciOyun=1;
            ArtisMiktari=5;
        }
        else if(OyunSayac>=3&&OyunSayac<6)
        {
            KacinciOyun=2;
            ArtisMiktari=10;            
        }
        else if(OyunSayac>=6&&OyunSayac<9)
        {
            KacinciOyun=3;
            ArtisMiktari=15;
        }
        else
        {
            KacinciOyun=Random.Range(1,4);
        }

        switch (KacinciOyun)
        {
            case 1:
            BirinciFonksiyon();
            break;
            
            case 2:
            IkinciFonksiyon();
            break;

            case 3:
            UcuncuFonksiyon();
            break;

            
        }
    }

    void BirinciFonksiyon()
    {
        int RastgeleDeger=Random.Range(1,30);

        if(RastgeleDeger<=5)
        {
            UstDeger=Random.Range(2,30);
            AltDeger=UstDeger+Random.Range(1,10);
        }
        else
        {
            UstDeger=Random.Range(2,10);
            AltDeger=Mathf.Abs(UstDeger-Random.Range(1,5));   //Mathf fonksiyonu mutlak değer almayı sağlar.
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
            BirinciFonksiyon();
            return;
        }

        UstText.text=UstDeger.ToString();
        AltText.text=AltDeger.ToString();

        //Debug.Log("Büyük Deger"+BuyukDeger);

 
    }

    void IkinciFonksiyon()
    {
        int BirinciSayi=Random.Range(1,10);
        int IkinciSayi=Random.Range(1,20);
        int UcuncuSayi=Random.Range(1,10);
        int DorduncuSayi=Random.Range(1,20);

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
            IkinciFonksiyon();
            return;
        }

        UstText.text=BirinciSayi+"+"+IkinciSayi;
        AltText.text=UcuncuSayi+"+"+DorduncuSayi;
        
        
    }

    void UcuncuFonksiyon()
    {
        int BirinciSayi=Random.Range(11,30);
        int IkinciSayi=Random.Range(1,10);
        int UcuncuSayi=Random.Range(17,40);
        int DorduncuSayi=Random.Range(1,20);

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
            IkinciFonksiyon();
            return;
        }

        UstText.text=BirinciSayi+"-"+IkinciSayi;
        AltText.text=UcuncuSayi+"-"+DorduncuSayi;
        
        
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
            DogruYanlisYonetim.DogruYanlisAc(true);
            DairelerManager.DaireScaleAc(OyunSayac % 3);
            OyunSayac++;
            ToplamPuan+=ArtisMiktari;
            PuanText.text=ToplamPuan.ToString();
            AudioSource.PlayOneShot(DogruSes);
            DogruSayisi++;

            kacinciOyun();
        }
        else
        {
            DogruYanlisYonetim.DogruYanlisAc(false);
            HatadaSayacAzalt();
            AudioSource.PlayOneShot(YanlisSes);
            YanlisSayisi++;
            kacinciOyun();
        }
    }

    void HatadaSayacAzalt()
    {
        OyunSayac-=(OyunSayac%3+3);

        if(OyunSayac<0)
        {
            OyunSayac=0;
        }

         DairelerManager.DaireScaleKapat();
    }

    public void PausePaneliAc()
    {
        PausePanel.SetActive(true);
    }

    public void OyunSonu()
    {
        AudioSource.PlayOneShot(AlkisSes);
        
        DegerlendirmePanel.SetActive(true);

        DegerlendirmeYoneticisi=Object.FindObjectOfType<DegerlendirmeYoneticisi>();

        DegerlendirmeYoneticisi.DegerlerdirmeEkrani(DogruSayisi,YanlisSayisi,ToplamPuan);
    }
       

}

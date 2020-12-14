using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DegerlendirmeYoneticisi : MonoBehaviour
{
    [SerializeField]
    private Text DogruSayisiText;

    [SerializeField]
    private Text YanlisSayisiText;

    [SerializeField]
    private Text ToplamPuanText;

  
    
    public void DegerlerdirmeEkrani(int DogruSayisi,int YanlisSayisi,int ToplamPuan)
    {
        DogruSayisiText.text=DogruSayisi.ToString();
        YanlisSayisiText.text=YanlisSayisi.ToString();
        ToplamPuanText.text=ToplamPuan.ToString();
       
    }

  
    public void AnaMenuDonus()
    {
        SceneManager.LoadScene("AnaMenuSahne");
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene("Sinif2Sahne");
    }
}

    

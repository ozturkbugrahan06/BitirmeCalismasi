using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sinif1PauseYonetim : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;
   
   private void OnEnable()
   {
       Time.timeScale=0f;   //Pasue ekranı açıldığında süreyi durdur.
   }
    private void OnDisable()
   {
       Time.timeScale=1f;   //Pasue ekranı kapandığında süreyi başlat.    
   }
      
    public void DevamEt()
  {
      PausePanel.SetActive(false);
  }

  public void AnaMenu()
  {
      SceneManager.LoadScene("AnaMenuSahne"); //Önceki sahne olan giriş sahnesine dön.
  }

  public void Cıkıs()
  {
      Application.Quit();
  }
  
}

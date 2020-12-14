using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobYonetici : MonoBehaviour
{
    private BannerView bannerView;
    
    public void Start()
    {
        
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-2516685275922642/7191430124";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
        #endif

        
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();


        this . bannerView . LoadAd ( request );
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }
}
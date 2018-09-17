﻿using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class StopDinhNui : MonoBehaviour {


    public tk2dTextMesh txtDinhNui;
    public tk2dTextMesh txtCoin;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtHoanThanh;
    public tk2dUIItem btnContinute;


    BannerView bannerView;

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.TopLeft);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    
    public void setData(int pCoin, string pTime)
    {
        if (GameController.instance.checkvip != 10)
        {
            RequestBanner();
            bannerView.Show();
        }
        txtCoin.text = ClsLanguage.doDiem()+": " + pCoin;
        txtTime.text = ClsLanguage.doTime()+": " + pTime;
    }

    void onClick_btnContinute()
    {
		try
		{
        PopUpController.instance.HideStopDinhNui();
        if (GameController.instance.level < 4)
        {
            GameController.instance.ShowLevel3();
        }
        else
        {
            GameController.instance.ShowLevel2();
        }

        if (GameController.instance.checkvip != 10)
        {
            bannerView.Hide();
        }
        SoundManager.Instance.rePlayBGMusic();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	// Use this for initialization
	void Start () {
		try
		{
        btnContinute.OnClick += onClick_btnContinute;

        txtHoanThanh.text = ClsLanguage.doHoanThanhBaiThi();
        txtDinhNui.text = ClsLanguage.doTitleDinhNui();
        btnContinute.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doContinute();
		}
		catch (System.Exception)
		{

			throw;
		}
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

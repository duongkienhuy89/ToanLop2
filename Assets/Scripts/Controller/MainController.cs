﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
    
    public tk2dUIItem btnPlay; 
    public tk2dUIItem btnRank;
    public tk2dUIItem btnBuyVip;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRate;

    void btnShare_OnClick()
    {
		try
		{
        ShareRate.Share();
        SoundManager.Instance.PlayAudioChoiTiep();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void btnRate_OnClick()
    {
		try
		{
        ShareRate.Rate();
        SoundManager.Instance.PlayAudioChoiTiep();
		}
		catch (System.Exception)
		{

			throw;
		}
    }



    void btnBuyVip_OnClick()
    {
		try
		{
        PopUpController.instance.ShowBuyItem();
        PopUpController.instance.HideMainGame();
        SoundManager.Instance.PlayAudioChoiTiep();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    void btnRank_OnClick()
    {
		try
		{
        SoundManager.Instance.PlayAudioChoiTiep();
        if (GameController.instance.vuotqua > 5)
        {
            SceneManager.LoadScene("Rank");
        }
        else
        {
            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowAdTriger();
        }
		}
		catch (System.Exception)
		{

			throw;
		}

    }

    public void setData()
    {
        if (GameController.instance.vuotqua > 5)
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doXepHang();
        }
        else
        {
            btnRank.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doQuangCao();
        }
    }


    void btnPlay_OnClick()
    {
		try
		{
        PopUpController.instance.HideMainGame();
        PopUpController.instance.ShowLevel();
        SoundManager.Instance.PlayAudioChoiTiep();
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
        btnRank.OnClick += btnRank_OnClick;
        btnPlay.OnClick += btnPlay_OnClick;
        btnBuyVip.OnClick += btnBuyVip_OnClick;
        btnShare.OnClick += btnShare_OnClick;
        btnRate.OnClick += btnRate_OnClick;
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();
        setData();
        btnBuyVip.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doMuaVip();
       
        if (GameController.instance.checkvip == 10)
        {
            btnBuyVip.gameObject.SetActive(false);
        }
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

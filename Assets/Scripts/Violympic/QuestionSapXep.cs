﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionSapXep : MonoBehaviour {


    public SpItem spPrefab;
    public float startX;
    public float distanceX;
    public float startY;
    public float distanceY;
    private tk2dUIItem sp;
    private SpItem sp1;


    private SpItem bt1;
    private SpItem bt2;
    private SpItem bt3;
    private SpItem bt4;
    private SpItem bt5;
    private SpItem bt6;
    private SpItem bt7;
    private SpItem bt8;
    private SpItem bt9;
    private SpItem bt10;
    private SpItem bt11;
    private SpItem bt12;
    private SpItem bt13;
    private SpItem bt14;
    private SpItem bt15;
    private SpItem bt16;
    private SpItem bt17;
    private SpItem bt18;
    private SpItem bt19;
    private SpItem bt20;


    private tk2dSprite sprite;

    List<PhepToan> lstSapXep = new List<PhepToan>();
    public int mDiemB1 = 0;
    public tk2dSprite khocCuoi;

    int mTime = 1200;

    int demframe = 0;
    int mDem = 0;



   

    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;
    bool checkCreate = true;


    public enum State
    {
        Start,
        InGame1,
        Click1

    }

    public State currentState;

    public void setPlay()
    {
       
        StartCoroutine(WaitTimeLoadData(1.2f));
        
    }



        IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();
    }


    void CreateLevel(float positionX, float positionY, PhepToan vio, int thutu)
    {

        SpItem levelCreate = spPrefab.Spawn<SpItem>
            (
               new Vector3(positionX, positionY, 71),
             spPrefab.transform.rotation
            );
        levelCreate.Giatri = vio.Ketqua;
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);
        levelCreate.Trangthai = true;
        //levelCreate.Vitri = thutu;
        


        sp = levelCreate.GetComponent<tk2dUIItem>();

        switch (thutu)
        {
            case 1:
                bt1 = levelCreate;
                sp.OnClick += onClick_sp1;
                break;
            case 2:
                bt2 = levelCreate;
                sp.OnClick += onClick_sp2;
                break;
            case 3:
                bt3 = levelCreate;
                sp.OnClick += onClick_sp3;
                break;
            case 4:
                bt4 = levelCreate;
                sp.OnClick += onClick_sp4;
                break;
            case 5:
                bt5 = levelCreate;
                sp.OnClick += onClick_sp5;
                break;
            case 6:
                bt6 = levelCreate;
                sp.OnClick += onClick_sp6;
                break;
            case 7:
                bt7 = levelCreate;
                sp.OnClick += onClick_sp7;
                break;
            case 8:
                bt8 = levelCreate;
                sp.OnClick += onClick_sp8;
                break;
            case 9:
                bt9 = levelCreate;
                sp.OnClick += onClick_sp9;
                break;
            case 10:
                bt10 = levelCreate;
                sp.OnClick += onClick_sp10;
                break;
            case 11:
                bt11 = levelCreate;
                sp.OnClick += onClick_sp11;
                break;
            case 12:
                bt12 = levelCreate;
                sp.OnClick += onClick_sp12;
                break;
            case 13:
                bt13 = levelCreate;
                sp.OnClick += onClick_sp13;
                break;
            case 14:
                bt14 = levelCreate;
                sp.OnClick += onClick_sp14;
                break;
            case 15:
                bt15 = levelCreate;
                sp.OnClick += onClick_sp15;
                break;
            case 16:
                bt16 = levelCreate;
                sp.OnClick += onClick_sp16;
                break;
            case 17:
                bt17 = levelCreate;
                sp.OnClick += onClick_sp17;
                break;
            case 18:
                bt18 = levelCreate;
                sp.OnClick += onClick_sp18;
                break;
            case 19:
                bt19 = levelCreate;
                sp.OnClick += onClick_sp19;
                break;
            case 20:
                bt20 = levelCreate;
                sp.OnClick += onClick_sp20;
                break;
            default:
                Debug.Log("Default case");
                break;
        }

        levelCreate.transform.parent = this.gameObject.transform;


    }
    void doXuLy(SpItem bt)
    {

        if (currentState == State.InGame1)
        {
            if (bt.Trangthai == true)
            {
                //khi đã kích vào nút
                khocCuoi.SetSprite("khixet");
                bt.Trangthai = false;
                sprite = bt.GetComponent<tk2dSprite>();
                sprite.color = new Color(1, 1, 0.5f, 1);
                currentState = State.Click1;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLySX(1f, bt));
            }
        }
    }

    IEnumerator WaitTimeXuLySX(float time, SpItem bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        if (lstSapXep.Count > 0)
        {

            int pSo = bt.Giatri;
            int tmgSo = lstSapXep[0].Ketqua;
            bt.Trangthai = true;
            //nếu đúng thì làm gì , sai thì lam j
            if (tmgSo == pSo)
            {
               

                sprite.color = new Color(1, 1, 1, 1);
                bt.gameObject.SetActive(false);
                lstSapXep.RemoveAt(0);
                mDiemB1 += 5;
                khocCuoi.SetSprite("khicuoi");
                SoundManager.Instance.Stop();
                SoundManager.Instance.PlayAudioChucTrue();
                StartCoroutine(WaitTimeDungRoiSX(0.5f));
            }
            else
            {
               
                mDiemB1 -= 1;
                StartCoroutine(WaitTimeSaiRoiSX(0.5f));
                khocCuoi.SetSprite("khikhoc");
            }
        }
    }
    IEnumerator WaitTimeSaiRoiSX(float time)
    {
        yield return new WaitForSeconds(time);

        // nếu sai

        SoundManager.Instance.Stop();
        mDem++;



        int chon = UnityEngine.Random.Range(0, 6);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucSai1();
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucSai2();
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucSai3();
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucSai4();
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucSai5();
                break;
            default:
                SoundManager.Instance.PlayAudioChucSai2();
                break;

        }


        
        sprite.color = new Color(1, 1, 1, 1);
        if (mDem >= 3)
        {
            // sai quá 3 lần thì game over
            GameOver();


        }
        else
        {
            currentState = State.InGame1;
        }

    }


    IEnumerator WaitTimeDungRoiSX(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        // nếu đúng

        SoundManager.Instance.Stop();

        int chon = UnityEngine.Random.Range(0, 12);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucDung1(chon);
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucDung3(chon);
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucDung4(chon);
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucDung5(chon);
                break;
            default:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;

        }
        if (lstSapXep.Count > 0)
        {

            currentState = State.InGame1;
        }
        else
        {
            //qua màn
            GameOver();
        }




    }

    void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionSapXep();
        if (mDiemB1 < 0)
        {
            mDiemB1 = 0;
        }
        GameController.instance.sumCoin += mDiemB1;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopSapXep(mDiemB1, ClsThaoTac.CoverTimeToString(1200 - mTime));
        resetTL();
    }
    public void resetTL()
    {
        //Đưa các giá trị về giá trị ban đầu
        mTime = 1200;
      
        demframe = 0;
        mDem = 0;

        mDiemB1 = 0;
        setEmptyChild();
        currentState = State.Start;
        lstSapXep.Clear();
        khocCuoi.SetSprite("khixet");
        txtLoading.gameObject.SetActive(true);
    }


    public void setEmptyChild()
    {
        //remove cây item trống không
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            child.gameObject.SetActive(false);
        }



    }



    #region Singleton
    void onClick_sp1()
    {

        doXuLy(bt1);
    }

    void onClick_sp2()
    {

        doXuLy(bt2);
    }

    void onClick_sp3()
    {

        doXuLy(bt3);
    }

    void onClick_sp4()
    {

        doXuLy(bt4);
    }



    void onClick_sp5()
    {

        doXuLy(bt5);
    }

    void onClick_sp6()
    {

        doXuLy(bt6);
    }

    void onClick_sp7()
    {

        doXuLy(bt7);
    }

    void onClick_sp8()
    {

        doXuLy(bt8);
    }
    void onClick_sp9()
    {

        doXuLy(bt9);
    }
    void onClick_sp10()
    {

        doXuLy(bt10);
    }
    void onClick_sp11()
    {

        doXuLy(bt11);
    }
    void onClick_sp12()
    {

        doXuLy(bt12);
    }

    void onClick_sp13()
    {

        doXuLy(bt13);
    }

    void onClick_sp14()
    {

        doXuLy(bt14);
    }

    void onClick_sp15()
    {

        doXuLy(bt15);
    }

    void onClick_sp16()
    {

        doXuLy(bt16);
    }

    void onClick_sp17()
    {

        doXuLy(bt17);
    }

    void onClick_sp18()
    {

        doXuLy(bt18);
    }

    void onClick_sp19()
    {

        doXuLy(bt19);
    }

    void onClick_sp20()
    {

        doXuLy(bt20);
    }
    #endregion

    void doPhanPhat(ref List<PhepToan> lstP, ref int vt, ref float positionX, ref float positionY)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, positionY, lstP[chon], vt);
        lstP.RemoveAt(chon);

        positionX += distanceX;
        if ((vt) % 4 == 0)
        {
            positionY -= distanceY;
            positionX = startX;

        }
        vt++;
    }

    public void Create()
    {
        #region Singleton

        float positionX = startX;
        float positionY = startY;
        List<PhepToan> lstTMG = new List<PhepToan>();
        if (GameController.instance.level == 4)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(10, 80, 1, GameController.instance.lstCongTruHai), GameController.instance.level);
        }
        else if (GameController.instance.level == 5)
        {

            chonData(ref lstTMG, GameController.instance.lstCongTruHai, GameController.instance.level);
        }
        else if (GameController.instance.level == 6)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(0, 50, 0, GameController.instance.lstCongTruBa), GameController.instance.level);
        }
        else if (GameController.instance.level == 7)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(30, 100, 1, GameController.instance.lstCongTruBa), GameController.instance.level);
        }
        else if (GameController.instance.level == 8)
        {

            var bien = GameController.instance.lstNhanHaiBa.Concat(ClsThaoTac.ChuanHoaDaTa(1, 32, 0, GameController.instance.lstNhanBonNam)).Concat(ClsThaoTac.FakeData(2,50)).ToList();
            chonData(ref lstTMG, bien, GameController.instance.level);
        }
        else if (GameController.instance.level == 9)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanCong23, GameController.instance.level);
        }
        else if (GameController.instance.level == 10)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanCong45, GameController.instance.level);
        }
        else if (GameController.instance.level == 11)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanTru23, GameController.instance.level);
        }
        else if (GameController.instance.level == 12)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanTru45, GameController.instance.level);
        }
        else if (GameController.instance.level == 13)
        {

            chonData(ref lstTMG, GameController.instance.lstTruNhan23, GameController.instance.level);
        }
        else if (GameController.instance.level == 14)
        {

            chonData(ref lstTMG, GameController.instance.lstTruNhan45, GameController.instance.level);
        }
        else if (GameController.instance.level == 15)
        {
            var bien = GameController.instance.lstChia23.Concat(GameController.instance.lstNhanHaiBa).Concat(ClsThaoTac.FakeData(2, 33)).ToList();
            chonData(ref lstTMG, bien, GameController.instance.level);
        }
        else if (GameController.instance.level == 16)
        {
            var bien = GameController.instance.lstChia45.Concat(GameController.instance.lstNhanBonNam).Concat(ClsThaoTac.FakeData(2, 52)).ToList();
            chonData(ref lstTMG, bien, GameController.instance.level);
        }

        else if (GameController.instance.level == 17)
        {

            chonData(ref lstTMG, GameController.instance.lstCongChia23.Concat(GameController.instance.lstTruChia23).ToList(), GameController.instance.level);
        }
        else if (GameController.instance.level == 18)
        {

            chonData(ref lstTMG, GameController.instance.lstCongChia45.Concat(GameController.instance.lstTruChia45).ToList(), GameController.instance.level);
        }

        else if (GameController.instance.level == 19 || GameController.instance.level == 20)
        {
            var bien = GameController.instance.lstNhanHaiBa.Concat(GameController.instance.lstNhanBonNam).Concat(GameController.instance.lstChia23).Concat(GameController.instance.lstChia45).ToList();

            chonData(ref lstTMG, bien, GameController.instance.level);
        }

        #endregion

        lstSapXep = lstSapXep.OrderBy(p => p.Ketqua).ToList();


        if (checkCreate)
        {
            int vt = 1;

            for (int i = 0; i < 20; i++)
            {

                doPhanPhat(ref lstTMG, ref vt, ref positionX, ref positionY);
            }

            checkCreate = false;
        }
        else
        {
            setDataLst(ref lstTMG);
        }

        currentState = State.InGame1;
        txtLoading.gameObject.SetActive(false);
    }

    void setDataLst(ref List<PhepToan> lstP)
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            children.Add(child.gameObject);
        }

        int i = 0;
        foreach (GameObject item in children)
        {

            if (item.CompareTag("nguoi"))
            {
                continue;
            }

            item.SetActive(true);

            item.GetComponent<SpItem>().Giatri = lstP[i].Ketqua;
            item.GetComponent<SpItem>().Pheptoan = "" + lstP[i].Congthuc;
            item.GetComponent<SpItem>().setData(lstP[i].Loai);
            item.GetComponent<SpItem>().Trangthai = true;
            i++;

        }

    }

    void chonData(ref List<PhepToan> tmg1, List<PhepToan> lstRank, int loai)
    {

        #region Singleton
        if (loai == 4||loai==5||loai==19||loai==20)
        {
            //1 phep toan
            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (lstRank[chon].Ketqua % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }                   
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 10);
                        if (nh == 0)
                        {
                            if (lstRank[chon].Ketqua > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (lstRank[chon].Ketqua - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }
           
                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }




        }else if (loai == 6 || loai==7||loai==9||loai==10||loai==11||loai==12||loai==13||loai==14||loai==17||loai==18)
        {
            //2 phep toan
            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (lstRank[chon].Ketqua % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
                        if (nh == 0)
                        {
                            if (lstRank[chon].Ketqua > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (lstRank[chon].Ketqua - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }                      
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }

        }
        else if (loai == 8||loai==15||loai==16)
        {
            //1 phep toan biet truopc number
            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (lstRank[chon].Ketqua % 7 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 4 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
                        if (nh == 0 && lstRank[chon].Loai.Equals("number"))
                        {
                            if (lstRank[chon].Ketqua > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (lstRank[chon].Ketqua - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else if (nh == 1 && lstRank[chon].Loai.Equals("number"))
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }




        }
        
       
   
        #endregion


    }

	// Use this for initialization
	void Start () {

        txtLoading.text = ClsLanguage.doLoading();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (currentState == State.InGame1 || currentState == State.Click1)
        {
            //đếm ngược thời gian từ 20 phút
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                mTime--;
                txtTime.text = ClsThaoTac.CoverTimeToString(mTime);
                //if (mTime <= 10)
                //{
                //    txtTime.color = new Color(1, 0, 1, 1);
                //}

                demframe = 0;
                if (mTime <= 0)
                {
                    //hết giờ thì game over
                    GameOver();
                }
            }
        }
	}
}

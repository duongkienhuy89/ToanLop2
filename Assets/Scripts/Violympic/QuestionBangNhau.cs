using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionBangNhau : MonoBehaviour {


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

    int gt1 = 0;
    int gt2 = 0;

    private tk2dSprite sprite1;
    private tk2dSprite sprite2;

    public int mDiemB1=0;
    public tk2dSprite khocCuoi;
    int mDem = 0;
    int mTime = 1200;

    int demframe = 0;



    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;
    bool checkCreate = true;

    public enum State
    {
        Start,
        InGame1,
        Click1,
        Click2

    }

    public State currentState;
    public void setPlay()
    {
       
        //currentState = State.InGame1;
        StartCoroutine(WaitTimeLoadData(1.2f));
    }



    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();
    }

    void doXuLy(SpItem bt)
    {
      
        if (currentState == State.InGame1)
        {
            sp1 = bt;
            if (sp1.Trangthai == true)
            {
                sp1.Trangthai = false;
                currentState = State.Click1;
                khocCuoi.SetSprite("khixet");
                sprite1 = bt.GetComponent<tk2dSprite>();
                sprite1.color = new Color(1, 1, 0.5f, 1);

                gt1 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
            }

        }
        else if (currentState == State.Click1)
        {
            if (bt.Trangthai == true)
            {
                bt.Trangthai = false;
                currentState = State.Click2;

                sprite2 = bt.GetComponent<tk2dSprite>();
                sprite2.color = new Color(1, 1, 0.5f, 1);

                gt2 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLyBN(1f, bt));
            }
        }
           
    }

    IEnumerator WaitTimeXuLyBN(float time, SpItem bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        sprite1.color = new Color(1, 1, 1, 1);
        sprite2.color = new Color(1, 1, 1, 1);


        sp1.Trangthai = true;
        bt.Trangthai = true;


        if (gt1 == gt2)
        {
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();

            bt.gameObject.SetActive(false);
            sp1.gameObject.SetActive(false);
            
            mDiemB1 += 10;
            khocCuoi.SetSprite("khicuoi");
            StartCoroutine(WaitTimeDungRoiBN(0.5f));
        }
        else
        {
            mDiemB1 -= 2;
            khocCuoi.SetSprite("khikhoc");
            StartCoroutine(WaitTimeSaiRoiBN(0.5f));
        }
    }

    IEnumerator WaitTimeSaiRoiBN(float time)
    {
        yield return new WaitForSeconds(time);


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

        currentState = State.InGame1;

        if (mDem >= 3)
        {
            GameOver();
        }

    }

    IEnumerator WaitTimeDungRoiBN(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

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

        if (mDiemB1 < 91)
        {
            currentState = State.InGame1;

        }
        else
        {
            GameOver();
        }



    }

    public void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionBangNhau();
        if (mDiemB1 < 0)
        {
            mDiemB1 = 0;
        }
        GameController.instance.sumCoin += mDiemB1;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopBangNhau(mDiemB1, ClsThaoTac.CoverTimeToString(1200 - mTime));
        resetTL();
    }
    public void resetTL()
    {
        mTime = 1200;
       
        demframe = 0;
        mDem = 0;

        mDiemB1 = 0;
        setEmptyChild();
        khocCuoi.SetSprite("khihoi");
        txtLoading.gameObject.SetActive(true);
    }

    public void setEmptyChild()
    {
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
        if (GameController.instance.level == 1)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(0, 50, 0, GameController.instance.lstCongTruHai), GameController.instance.level);
        }
        else if (GameController.instance.level == 2)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(20, 70, 1, GameController.instance.lstCongTruHai), GameController.instance.level);
        }
        else if (GameController.instance.level == 3)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(0, 40, 0, GameController.instance.lstCongTruBa), GameController.instance.level);
        }
        else if (GameController.instance.level == 4)
        {

            chonData(ref lstTMG, ClsThaoTac.ChuanHoaDaTa(30, 80, 1, GameController.instance.lstCongTruBa), GameController.instance.level);
        }
        else if (GameController.instance.level == 5)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanHaiBa, GameController.instance.level);
        }
        else if (GameController.instance.level == 6)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanBonNam, GameController.instance.level);
        }
        else if (GameController.instance.level == 7)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanCong23, GameController.instance.level);
        }
        else if (GameController.instance.level == 8)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanCong45, GameController.instance.level);
        }
        else if (GameController.instance.level == 9)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanTru23, GameController.instance.level);
        }
        else if (GameController.instance.level == 10)
        {

            chonData(ref lstTMG, GameController.instance.lstNhanTru45, GameController.instance.level);
        }else if (GameController.instance.level == 11)
        {

            chonData(ref lstTMG, GameController.instance.lstTruNhan23, GameController.instance.level);
        }else if (GameController.instance.level == 12)
        {

            chonData(ref lstTMG, GameController.instance.lstTruNhan45, GameController.instance.level);
        }
        else if (GameController.instance.level == 13)
        {

            chonData(ref lstTMG, GameController.instance.lstChia23, GameController.instance.level);
        }
        else if (GameController.instance.level == 14)
        {

            chonData(ref lstTMG, GameController.instance.lstChia45, GameController.instance.level);
        }
        else if (GameController.instance.level == 15)
        {

            chonData(ref lstTMG, GameController.instance.lstCongChia23, GameController.instance.level);
        }
        else if (GameController.instance.level == 16)
        {

            chonData(ref lstTMG, GameController.instance.lstCongChia45, GameController.instance.level);
        }
        else if (GameController.instance.level == 17)
        {

            chonData(ref lstTMG, GameController.instance.lstTruChia23, GameController.instance.level);
        }
        else if (GameController.instance.level == 18)
        {

            chonData(ref lstTMG, GameController.instance.lstTruChia45, GameController.instance.level);
        }
        else if (GameController.instance.level == 19 || GameController.instance.level == 20)
        {
            var bien = GameController.instance.lstNhanHaiBa.Concat(GameController.instance.lstNhanBonNam).Concat(GameController.instance.lstChia23).Concat(GameController.instance.lstChia45).ToList();

            chonData(ref lstTMG, bien, GameController.instance.level);
        }

        #endregion



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


        foreach (GameObject item in children)
        {

            if (item.CompareTag("nguoi"))
            {
                continue;
            }

            item.SetActive(true);

            int chon = UnityEngine.Random.Range(0, lstP.Count);

            item.GetComponent<SpItem>().Giatri = lstP[chon].Ketqua;
            item.GetComponent<SpItem>().Pheptoan = "" + lstP[chon].Congthuc;
            item.GetComponent<SpItem>().setData(lstP[chon].Loai);
            item.GetComponent<SpItem>().Trangthai = true;

            lstP.RemoveAt(chon);
        }

    }

    void chonData(ref List<PhepToan> tmg1, List<PhepToan> lstRank,int loai)
    {

        #region Singleton
        if (loai == 1)
        {

            while (tmg1.Count < 15)
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
                    if (lstRank[chon].Ketqua % 3 == 0)
                    {
                         pt1= new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                         pt1= new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhTron(), -1, "number");
            PhepToan pta = new PhepToan("", -1, "hinhtron");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhTamGiac(), -2, "number");
            PhepToan pta1 = new PhepToan("", -2, "hinhtamgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 2)
        {

            while (tmg1.Count < 15)
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
                    if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
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
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhVuong(), -3, "number");
            PhepToan pta = new PhepToan("", -3, "hinhvuong");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhTamGiac(), -2, "number");
            PhepToan pta1 = new PhepToan("", -2, "hinhtamgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 3)
        {

            while (tmg1.Count < 15)
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
                    if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
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
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhNgoiSao(), -5, "number");
            PhepToan pta = new PhepToan("", -5, "hinhngoisao");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhLucGiac(), -7, "number");
            PhepToan pta1 = new PhepToan("", -7, "hinhlucgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 4||loai==7||loai==8||loai==9||loai==10||loai==11||loai==12||loai==15||loai==16||loai==17||loai==18)
        {

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
                    if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (lstRank[chon].Ketqua % 6 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
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
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai==5 ||loai==6||loai==13||loai==14)
        {

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
                    if (lstRank[chon].Ketqua % 4 == 0)
                    {
                        if (chon % 2 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {

                            pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }
                    else if (lstRank[chon].Ketqua % 7 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
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
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                       
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                     
                    }
                    PhepToan pt2;
                    if (chon % 2 == 0)
                    {
                         pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt2 = ClsThaoTac.getCongThuc(lstRank[chon]);
                    }
                    
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai == 19)
        {

            var bien = GameController.instance.lstCongTruHai.Concat(GameController.instance.lstCongTruBa).ToList();
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
                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    PhepToan pt2= ClsThaoTac.getPhepToan(lstRank[chon], bien);
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }


            }
        }
        else if (loai == 20)
        {

            var bien = GameController.instance.lstNhanCong23.Concat(GameController.instance.lstNhanCong45).Concat(GameController.instance.lstNhanTru23).Concat(GameController.instance.lstNhanTru45).Concat(GameController.instance.lstTruNhan23).Concat(GameController.instance.lstTruNhan45).ToList();
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
                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    PhepToan pt2 = ClsThaoTac.getPhepToan(lstRank[chon], bien);
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }


            }
        }
        #endregion


    }

    // Use this for initialization
    void Start()
    {
        txtLoading.text = ClsLanguage.doLoading();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentState == State.InGame1 || currentState == State.Click1 || currentState == State.Click2)
        {
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
                    GameOver();
                }
            }
        }

	}
}

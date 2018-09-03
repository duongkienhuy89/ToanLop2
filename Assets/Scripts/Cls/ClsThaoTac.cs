using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ClsThaoTac  {

    public static string CoverTimeToString(int mTime)
    {
        string stTime = "";
        int timeN = mTime / 60;
        int timeD = mTime % 60;
        if (timeD >= 10)
        {
            stTime = "" + timeN + ":" + timeD;
        }
        else
        {
            stTime = "" + timeN + ":0" + timeD;
        }
        return stTime;
    }

    public static List<PhepToan> ChuanHoaDaTa(int dau,int cuoi,int khoang,List<PhepToan> lst)
    {
        List<PhepToan> lstTmg = new List<PhepToan>();
        foreach (PhepToan item in lst)
        {
            int loai = int.Parse(item.Loai);
            string tmg = item.Congthuc;
            string[] mang = tmg.Split(new Char[] { '-', '+','x',':' });

         
            if(loai==51||loai==53||loai==54)
            {
                    if (khoang == 0)
                    {
                        if (int.Parse(mang[0].Trim()) < cuoi && int.Parse(mang[1].Trim()) < cuoi)
                        {
                            lstTmg.Add(item);
                        }
                    }
                    else if (khoang == 1)
                    {
                        if ((int.Parse(mang[0].Trim()) > dau && int.Parse(mang[0].Trim()) < cuoi) && (int.Parse(mang[1].Trim()) > dau && int.Parse(mang[1].Trim()) < cuoi))
                        {
                            lstTmg.Add(item);
                        }
                    }
                    else
                    {
                        if (int.Parse(mang[0].Trim()) > cuoi && int.Parse(mang[1].Trim()) > cuoi)
                        {
                            lstTmg.Add(item);
                        }
                    }
            }
              
            //-------------
            if(loai==52||loai==55||loai==56)
            {
                    if (khoang == 0)
                    {
                        if (int.Parse(mang[0].Trim()) < cuoi)
                        {
                            lstTmg.Add(item);
                        }
                    }
                    else if (khoang == 1)
                    {
                        if (int.Parse(mang[0].Trim()) > dau && int.Parse(mang[0].Trim()) < cuoi)
                        {
                            lstTmg.Add(item);
                        }
                    }
                    else
                    {
                        if (int.Parse(mang[0].Trim()) > cuoi)
                        {
                            lstTmg.Add(item);
                        }
                    }
            }
            //===========

              
            }

        return lstTmg;
        }

    public static List<PhepToan> FakeData(int dau, int cuoi)
    {
        List<PhepToan> lstTam = new List<PhepToan>();
        for (int i = dau; i <= cuoi; i++)
        {
            PhepToan pt = new PhepToan("" + i, i, "number");
            lstTam.Add(pt);
        }
        return lstTam;
        
    }

    public static PhepToan getCongThuc(PhepToan giatri)
    {
        string ct = giatri.Congthuc.Trim();
        string[] items = ct.Split(new Char[] { '-', '+', 'x', ':' });
        string tm = "";
        if (ct.Contains("+"))
        {
            tm = ClsLanguage.doTong();
        }else if(ct.Contains("-"))
        {
            tm = ClsLanguage.doHieu();
        }
        else if (ct.Contains("x"))
        {
            tm = ClsLanguage.doNhan();
        }
        else if (ct.Contains(":"))
        {
            tm = ClsLanguage.doChia();
        }

        if (tm.Trim().Equals(""))
        {
            return new PhepToan("" + giatri.Congthuc, giatri.Ketqua, "number");
        }
        else
        {
            return new PhepToan(tm + items[0] + ClsLanguage.doAnd() + items[1], giatri.Ketqua, "number");
        }
    }


    public static PhepToan getPhepToan(PhepToan giatri, List<PhepToan> lst)
    {
        List<PhepToan> tmg = new List<PhepToan>();
        foreach (PhepToan item in lst)
        {
            if (item.Congthuc.Equals(giatri.Congthuc))
                continue;
            if (item.Ketqua == giatri.Ketqua)
            {
                tmg.Add(item);
            }
        }

        if (tmg.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, tmg.Count);
            return new PhepToan(tmg[chon].Congthuc, tmg[chon].Ketqua, "number");
        }
        else
        {
            return new PhepToan("" + giatri.Ketqua, giatri.Ketqua, "number");
        }
    }

    }


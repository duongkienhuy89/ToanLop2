using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    #region Singleton
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }
    #endregion

    public int sumCoin = 0;
    public int sumTime;
    public int level = 1;
    public int vuotqua = 0;
    public bool tienganh = true;
    public List<DinhNui> lstSum = new List<DinhNui>();
   
    public List<PhepToan> lstCongTruHai = new List<PhepToan>();
    public List<PhepToan> lstCongTruBa = new List<PhepToan>();
    public List<PhepToan> lstNhanHaiBa = new List<PhepToan>();
    public List<PhepToan> lstNhanBonNam = new List<PhepToan>();
    public List<PhepToan> lstNhanCong23 = new List<PhepToan>();
    public List<PhepToan> lstNhanCong45 = new List<PhepToan>();
    public List<PhepToan> lstNhanTru23 = new List<PhepToan>();
    public List<PhepToan> lstNhanTru45 = new List<PhepToan>();
    public List<PhepToan> lstTruNhan23 = new List<PhepToan>();
    public List<PhepToan> lstTruNhan45 = new List<PhepToan>();
    public List<PhepToan> lstChia23 = new List<PhepToan>();
    public List<PhepToan> lstChia45 = new List<PhepToan>();
    public List<PhepToan> lstCongChia23 = new List<PhepToan>();
    public List<PhepToan> lstCongChia45 = new List<PhepToan>();
    public List<PhepToan> lstTruChia23 = new List<PhepToan>();
    public List<PhepToan> lstTruChia45 = new List<PhepToan>();

    public string stSumcoin = "";
    public string[] mang;
    public bool ckResetLv = true;
    public int checkvip = 0;

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
        tienganh = CheckNgonNgu();

        vuotqua = DataManager.GetHightLevel();
        level = vuotqua + 1;
        checkvip = DataManager.GetVip();

    }

    void GetDaTaBang(string tmg)
    {
        string[] mang = tmg.Trim().Split('*');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {
            string[] items = mang[i].Split(',');
            int rank = int.Parse(items[2]);
            PhepToan pt = new PhepToan(items[0], int.Parse(items[1]), items[2]);
            if (rank == 51 || rank == 52)
            {
                lstCongTruHai.Add(pt);
            }
            else if (rank == 53 || rank == 54 || rank == 55 || rank == 56)
            {
                lstCongTruBa.Add(pt);
            }
            else if (rank == 57 || rank == 58)
            {
                lstNhanHaiBa.Add(pt);
            }
            else if (rank == 59 || rank == 60)
            {
                lstNhanBonNam.Add(pt);
            }
            else if (rank == 61 || rank == 62)
            {
                lstNhanCong23.Add(pt);
            }
            else if (rank == 63 || rank == 64)
            {
                lstNhanCong45.Add(pt);
            }
            else if (rank == 65 || rank == 66)
            {
                lstNhanTru23.Add(pt);
            }
            else if (rank == 67 || rank == 68)
            {
                lstNhanTru45.Add(pt);
            }
            else if (rank == 69 || rank == 70)
            {
                lstTruNhan23.Add(pt);
            }
            else if (rank == 71 || rank == 72)
            {
                lstTruNhan45.Add(pt);
            }
            else if (rank == 73 || rank == 74)
            {
                lstChia23.Add(pt);
            }
            else if (rank == 75 || rank == 76)
            {
                lstChia45.Add(pt);
            }
            else if (rank == 77 || rank == 78)
            {
                lstCongChia23.Add(pt);
            }
            else if (rank == 79 || rank == 80)
            {
                lstCongChia45.Add(pt);
            }
            else if (rank == 81 || rank == 82)
            {
                lstTruChia23.Add(pt);
            }
            else if (rank == 83 || rank == 84)
            {
                lstTruChia45.Add(pt);
            }
          
        }


        // Debug.Log("1:" + lst1.Count + "2:" + lst2.Count + "3:" + lst3.Count + "4:" + lst4.Count + "5:" + lst5.Count + "6:" + lst6.Count);

    }

 

    public bool CheckNgonNgu()
    {
        bool ok = true;
        string ngonngu = Application.systemLanguage.ToString().ToLower().Trim();
        if (ngonngu.Equals("vietnamese"))
        {
            ok = false;
        }
        return ok;
    }

    public void ShowLevel3()
    {
        PopUpController.instance.ShowStartThongThai();
    }

    public void ShowLevel2()
    {
        if (level < 4)
        {
            
            PopUpController.instance.ShowStartDinhNui(2);
        }
        else
        {
            int chon = UnityEngine.Random.Range(0, 3);
            if (chon == 0)
            {
                PopUpController.instance.ShowStartSapXep();
            }
            else
            {
                PopUpController.instance.ShowStartBangNhau(2);
            }
        }
    }

    public void ShowLevel1()
    {
        if (level < 4)
        {
            PopUpController.instance.ShowStartBangNhau(1);
        }
        else
        {
            PopUpController.instance.ShowStartDinhNui(1);
        }
       
           
       
    }

    //IEnumerator WaitTimeLoading(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    PopUpController.instance.HideLoading();
    //    PopUpController.instance.HideLevel();
    //}
      void GetDaTa(string tmg)
    {
        string[] mang = tmg.Trim().Split('#');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {
            
            string[] items = mang[i].Split('*');
            DinhNui dn = new DinhNui(items[1], items[2], items[3], items[4], items[5], int.Parse(items[6]), items[7], int.Parse(items[8]));
            lstSum.Add(dn);
           
        }
       
        
      }

	// Use this for initialization
	void Start () {

		try
		{
        stSumcoin = DataManager.GetHightStringCoin();
        mang = stSumcoin.Split('+');
        
        StartCoroutine(WaitTimeLoadData());
		}
		catch (System.Exception)
		{

			throw;
		}
    
	}

    IEnumerator WaitTimeLoadData()
    {
        yield return new WaitForSeconds(0);

        TextAsset txtBang = (TextAsset)Resources.Load("violympic", typeof(TextAsset));
        string data = txtBang.text;
        GetDaTaBang(data);

        PopUpController.instance.HideLoading();
        PopUpController.instance.HideLevel();

        TextAsset txt;
        if (tienganh)
        {
            txt = (TextAsset)Resources.Load("violympica", typeof(TextAsset));
        }
        else
        {
            txt = (TextAsset)Resources.Load("violympicv", typeof(TextAsset));
        }
        string content = txt.text;

        GetDaTa(content);
    }



    // Update is called once per frame
    void Update()
    {
	
	}
}

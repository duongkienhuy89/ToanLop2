using UnityEngine;
using System.Collections;

public class SpItem : MonoBehaviour {


    public string mLoai;
    public int giatri = 1;
    
    //dung de test

    //int vitri = 0;

    //public int Vitri
    //{
    //    get { return vitri; }
    //    set { vitri = value; }
    //}

    public int Giatri
    {
        get { return giatri; }
        set { giatri = value; }
    }

    string pheptoan = "";

    public string Pheptoan
    {
        get { return pheptoan; }
        set { pheptoan = value; }
    }

    private bool trangthai = true;

    public bool Trangthai
    {
        get { return trangthai; }
        set { trangthai = value; }
    }

    //public void RecycleSp()
    //{
    //    this.Recycle<SpItem>();
    //}

 

    public void setData(string loai)
    {
        
        if (loai.Trim().Equals("number"))
        {
            this.gameObject.GetComponent<tk2dSprite>().SetSprite("nhapnhay");
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = pheptoan;
        }      
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.GetComponent<tk2dSprite>().SetSprite(loai);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

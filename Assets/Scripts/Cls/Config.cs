using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
	public static string adsInIDGameOver = "ca-app-pub-2127327600096597/8996492068";
	public static string adsInIDTrigger = "ca-app-pub-2127327600096597/4420086869";
	public static string adsInIDBanner = "ca-app-pub-2127327600096597/6209840586";
	public static string hedieuhanh = "ios";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/3430365361";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/7464319729";
                         public static string hedieuhanh = "android";

#endif

}

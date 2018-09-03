using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
    public static string adsInID = "ca-app-pub";
     public static string hedieuhanh="ios";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/3430365361";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/7464319729";
                         public static string hedieuhanh = "android";

#endif

}

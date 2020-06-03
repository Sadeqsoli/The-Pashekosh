using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public static class SMS
{

    // can give verified coins


    // this is for rememebering only/ tapsell, unity ads, admob, etc...

    // maybe we need to send some hook on this
    public static void ShowAdvertisement() { }



    // we can add image but it has stories
    public static void BasicShare(string subject, string title,  string text) 
    {
        new NativeShare().SetSubject(subject).SetTitle(title).SetText(text);
    }

    public static void SendSms(string text)
    {
        string mobile_num = "Your_Number";
        // string message = "This is a test from Unity *^#$#$((*&& Test Symbols";
        string message = text;
#if UNITY_ANDROID
        //Android SMS URL - doesn't require encoding for sms call to work
        string URL = string.Format("sms:{0}?body={1}", mobile_num, System.Uri.EscapeDataString(message));
#endif

#if UNITY_IOS
            //ios SMS URL - ios requires encoding for sms call to work
            //string URL = string.Format("sms:{0}?&body={1}",mobile_num,WWW.EscapeURL(message)); //Method1 - Works but puts "+" for spaces
            //string URL ="sms:"+mobile_num+"?&body="+WWW.EscapeURL(message); //Method2 - Works but puts "+" for spaces
            //string URL = string.Format("sms:{0}?&body={1}",mobile_num,System.Uri.EscapeDataString(message)); //Method3 - Works perfect
            string URL ="sms:"+mobile_num+"?&body="+ System.Uri.EscapeDataString(message); //Method4 - Works perfectly
#endif

        //Execute Text Message
        Application.OpenURL(URL);
    }
    public static void SendTelegram(string url, string title)
    {
        // https://t.me/share/url?url={url}&text={title}&to={phone_number}
        //https://telegram.me/share/url?url={url}&text={title}&to={phone_number}
        //tg://msg?url={url}&text={title}&to={phone_number}
        Application.OpenURL("https://t.me/share/url?url=" + url + "&text=" + title + "&to={phone_number}");
    }
    public static void SendWhatsApp(string text)
    {
        Application.OpenURL("https://wa.me/whatsappphonenumber/?text=" + text);
    }
    public static void SendInstagram(string text) 
    {
    }
    public static void SendFacebook(string text) { }
    public static void SendEmail(string text)
    {
        string email = "your email address";
        string subject = MyEscapeURL("My Subject");
        string body = MyEscapeURL(text);
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }


    // we cant verify coins on this
    public static void GiveStarOnStore()
    {
        switch (GameData.CurrentStoreForBuild)
        {
            case Store.CafeBazaar:
                break;
            case Store.Myket:
                break;
            case Store.IranApps:
                break;
            case Store.GoogleStore:
                break;
            case Store.SibApp:
                break;
            case Store.AppleStore:
                break;
            default:
                break;
        }
    }
    public static void LikeInstagram(string url)
    {
        Application.OpenURL("instagram://user?username=" + url);
    }
    public static void LikeFacebook(string url)
    {
        Application.OpenURL("fb://profile/" + url);
    }

    public static void SeeOurOtherProducts()
    {
        switch (GameData.CurrentStoreForBuild)
        {
            case Store.CafeBazaar:
                break;
            case Store.Myket:
                break;
            case Store.IranApps:
                break;
            case Store.GoogleStore:
                break;
            case Store.SibApp:
                break;
            case Store.AppleStore:
                break;

        }
    }



    #region helper functions
    public static string MyEscapeURL(string URL)
    {
        return UnityWebRequest.EscapeURL(URL).Replace("+", "%20");
    }


    #endregion





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToastCenter 
{
    static ToastFactory ToastFactory;



    public static void SendToast(string message, bool isToastLong)
    {
        ToastFactory.SendToastyToast(message, isToastLong);
    }



    public static void InitializeToaster()
    {
        ToastFactory = new ToastFactory();
    }
}//EndClasssss/SadeQ

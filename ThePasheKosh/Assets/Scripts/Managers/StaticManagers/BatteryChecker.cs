
using UnityEngine;

public static class BatteryChecker 
{
    public static void CurrentStatus(BatteryStatus batteryStatus,ToastFactory toast)
    {
        switch (batteryStatus)
        {
            case BatteryStatus.Unknown:
                string msgUnknown = "";
                toast.SendToastyToast(msgUnknown, true);
                break;
            case BatteryStatus.Charging:
                string msgCharging = "";
                toast.SendToastyToast(msgCharging, true);
                break;
            case BatteryStatus.Discharging:
                string msgDischarging = "";
                toast.SendToastyToast(msgDischarging, true);
                break;
            case BatteryStatus.NotCharging:
                string msgNotCharging = "";
                toast.SendToastyToast(msgNotCharging, true);
                break;
            case BatteryStatus.Full:
                string msgFull = "";
                toast.SendToastyToast(msgFull, true);
                break;
        }
    }


    public static float CurrentPercent()
    {
        float batteryLevel;
        batteryLevel = SystemInfo.batteryLevel;

        return batteryLevel * 100;
    }




}//EndClasssss/SadeQ
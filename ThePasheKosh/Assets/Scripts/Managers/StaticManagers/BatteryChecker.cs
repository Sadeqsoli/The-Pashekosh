
using UnityEngine;

public static class BatteryChecker 
{
    public static void CurrentStatus(BatteryStatus batteryStatus)
    {
        switch (batteryStatus)
        {
            case BatteryStatus.Unknown:

                break;
            case BatteryStatus.Charging:

                break;
            case BatteryStatus.Discharging:

                break;
            case BatteryStatus.NotCharging:

                break;
            case BatteryStatus.Full:
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
using System;

public static class NotificationCenter 
{

    public static void SendNotification(string gameTitle , string notifBody , TimeSpan timeSpan, string smallIconName, string largeIconName, string gameStatus )
    {
        GleyNotifications.SendNotification(gameTitle, notifBody, timeSpan, smallIconName, largeIconName, gameStatus);
    }

    public static void InitializeCheck()
    {
        GleyNotifications.Initialize();
    }

    public static string PushingCustomDataNotification()
    {
        return GleyNotifications.AppWasOpenFromNotification();
    }
}//EndClasssss/SadeQ

using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailFactory : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    InputField emailTarget;
    private int confirmationCode;
    private string myEmail = "myEmail@gmail.com";
    private string myPass = "MyPasswordGoesHere";
    private string subject = "Test Email through C Sharp App";
    private string confirmationMSG = "ConfirmationMSG";
    #endregion

    #region Public Methods
    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress(myEmail);
        mail.To.Add(new MailAddress(emailTarget.text));

        mail.Subject = subject;
        mail.Body = confirmationMSG;


        SmtpServer.Credentials = new System.Net.NetworkCredential(myEmail, myPass) as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }


    public void SendText(string phoneNumber)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;

        mail.From = new MailAddress("myEmail@gmail.com");

        mail.To.Add(new MailAddress(phoneNumber + "@txt.att.net"));//See carrier destinations below
                                                                   //message.To.Add(new MailAddress("5551234568@txt.att.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vtext.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@messaging.sprintpcs.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@tmomail.net"));
        mail.To.Add(new MailAddress(phoneNumber + "@vmobl.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@messaging.nextel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@myboostmobile.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@message.alltel.com"));
        mail.To.Add(new MailAddress(phoneNumber + "@mms.ee.co.uk"));



        mail.Subject = "Subject";
        mail.Body = "";

        SmtpServer.Port = 587;

        SmtpServer.Credentials = new System.Net.NetworkCredential("myEmail@gmail.com", "MyPasswordGoesHere") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }

    #endregion

    #region Private Methods
    private void Start()
    {
        confirmationCode = (int)Random.Range(1000000000000000, 9999999999999999999);
    }
    #endregion
}//EndClassss/SadeQ
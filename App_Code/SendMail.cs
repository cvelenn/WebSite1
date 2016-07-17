using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{

    private static string email = ConfigurationManager.AppSettings["emailaddress"].ToString();    
    private static string emailpassword = ConfigurationManager.AppSettings["emailpassword"].ToString();
    private static string smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
    private static string smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
    private static bool mailnotExcessible = true;
    public static bool IsMailExcessible {
        get {
            return mailnotExcessible;
        }
    }

    public static void SendEmail(string subject, string body, string toEmail)
    {

        try
        {
            //https://www.google.com/settings/security/lesssecureapps?rfn=27&rfnc=1&asae=2&anexp=lbe-R1_A
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = smtpHost;
                smtp.Port = int.Parse(smtpPort);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(email, emailpassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(email, toEmail, subject, body);
        }
        catch (Exception ex)
        {
            
            mailnotExcessible = true;
        }

    }

}
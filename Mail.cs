using System;
using System.Collections.Generic;
using System.Configuration;
using Spire.Email;
using Spire.Email.Pop3;


public static class Mail
{
    public static List<string> ReceiveMailSubject()
    {
        var RFIDStrings = new List<string>();
        var pop = new Pop3Client
        {
            Host = ConfigurationManager.AppSettings["host"],
            Username = ConfigurationManager.AppSettings["Username"],
            Password = ConfigurationManager.AppSettings["Password"],
            Port = Int32.Parse(ConfigurationManager.AppSettings["Port"]),
            EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"])
        };
        try
        {
            pop.Connect();
            int messageCount = pop.GetMessageCount();
            for (int i = 1; i <= messageCount; i++)
            {
                MailMessage message = pop.GetMessage(i);
                Console.WriteLine($"------------------ HEADERS #{i} ---------------");
                Console.WriteLine("Subject: " + message.Subject);
                Console.WriteLine("------------------- END ------------------");
                RFIDStrings.Add(message.Subject);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            pop.Disconnect();
            pop.Dispose();
        }
        return RFIDStrings;
    }
}

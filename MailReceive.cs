using System;
using System.Configuration;
using Spire.Email;
using Spire.Email.Pop3;


public class mailReceive
{
    public mailReceive()
    {
        Pop3Client pop = new Pop3Client
        {
            //Set host, username, password etc. for the client
            Host = ConfigurationManager.AppSettings["host"],
            Username = ConfigurationManager.AppSettings["Username"],
            Password = ConfigurationManager.AppSettings["Password"],
            Port = Int32.Parse(ConfigurationManager.AppSettings["Port"]),
            EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"])
        };
        //Connect the server
        pop.Connect();
        int messageCount = pop.GetMessageCount();
        try
        {
            for (int i = 1; i <= messageCount; i++)
            {
                MailMessage message = pop.GetMessage(i);
                Console.WriteLine($"------------------ HEADERS #{i} ---------------");
                Console.WriteLine("Subject: " + message.Subject);
                Console.WriteLine("------------------- END ------------------");

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            pop.Disconnect();
        }

    }
}

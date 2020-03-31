using Spire.Email;
using Spire.Email.Pop3;
using System;

public class mailReceive
{
	public mailReceive()
	{
        Pop3Client pop = new Pop3Client
        {
            //Set host, username, password etc. for the client
            Host = "pop.mail.ru",
            Username = "mickola1983@mail.ru",
            Password = "best4metoo",
            Port = 995,
            EnableSsl = true
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

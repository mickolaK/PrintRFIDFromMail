using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Email;
using Spire.Email.Pop3;

namespace ReceiveMail
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();

            Console.WriteLine("-------PRINT ZPL-------------------");
            //string ZPLString = @"^XA^MMP^PW300^LS0^LT0^FT10,60^APN,30,30^FH\^FDSAMPLE TEXT^FS^XZ";
            //string ZPLString = @"^XA^FO100,550^BC^FD12345678^FS^XZ";
            string RFIDZPLString = @"^XA^FO50,50^A0N,65^FDSimple write example^FS^RFW,A^FD00 rfid data^FS^XZ";
            // Open connection

            try
            {
                var client = new System.Net.Sockets.TcpClient("172.18.8.150", 9100);
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
                writer.Write(RFIDZPLString);
                writer.Flush();
                writer.Close();
                client.Close();
                Console.WriteLine("------------END------------");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}


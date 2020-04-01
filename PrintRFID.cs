using System;
using System.Configuration;
using System.Net.Sockets;
using System.IO;

public static class PrintRFID
{
    public static void PrintRFIDString(string RFIDZPLString)
    {
        Console.WriteLine("-------PRINT ZPL--_--------------");
        try
        {
            var client = new TcpClient(ConfigurationManager.AppSettings["PrinterIP"], Int32.Parse(ConfigurationManager.AppSettings["PrinterPort"]));
            StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
            writer.Write(RFIDZPLString);
            writer.Flush();
            writer.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("-------END ZPL---------------");
            Console.ReadKey();
        }
        
    }
}

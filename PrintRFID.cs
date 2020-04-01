using System;
using System.Configuration;

public static class PrintRFID
{
    public static void PrintRFIDString(string RFIDZPLString)
    {
        Console.WriteLine("-------PRINT ZPL--_--------------");
        try
        {
            var client = new System.Net.Sockets.TcpClient("172.18.8.150", 9100);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
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

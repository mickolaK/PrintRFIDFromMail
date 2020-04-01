using System;
using System.Configuration;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;

public static class PrintRFID
{
    public static void PrintRFIDString(List<string> RFIDZPLString)
    {
        Console.WriteLine("-------PRINT ZPL-----------------");
        try
        {
            var client = new TcpClient(ConfigurationManager.AppSettings["PrinterIP"], Int32.Parse(ConfigurationManager.AppSettings["PrinterPort"]));
            StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
            foreach (var item in RFIDZPLString)
            {
                Console.WriteLine($"Print {RFIDZPLString}");
                //Next string Disabled until real printer is not connected
                //format string like string RFIDZPLString = @"^XA^FO50,50^A0N,65^FDSimple write example^FS^RFW,A^FD00 rfid data^FS^XZ";
                /* writer.Write(RFIDZPLString);*/
            }
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
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        
    }
}

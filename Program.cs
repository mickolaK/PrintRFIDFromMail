using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReceiveMail
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Mail.ReceiveMailSubject();
            PrintRFID.PrintRFIDString(list);
        }
    }
}


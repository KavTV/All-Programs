using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EZ_Console
{
    class Settings
    {
        
        public static string PortName { get; set; }
        public static int BaudRate { get; set; }
        public static int DataBit { get; set; }
        public static string StopBit { get; set; }
        public static string Parity { get; set; }
    }
}

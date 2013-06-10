using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer
{
    public class ExceptionHandler
    {
        public static void ErrorMsg(int E)
        {
            switch (E)
            {
                case 1: Console.WriteLine("Directory nicht gefunden"); break;
                case 2: Console.WriteLine("File nicht gefunden"); break;
            }
        }
    }
}

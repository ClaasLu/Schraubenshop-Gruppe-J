using System;
using System.Threading;

namespace Schraubenshop
{


    public static class Program
    { 

        [STAThread]
        static void Main()
        {
            new GUI_control();                   
        }
        
    }
}



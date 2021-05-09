using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Schraubenshop
{
    public class GUI_control
    {
        public GUI_control()
        {
            Window fenster = new Window();
            UserControl1 meineGUI = new UserControl1();
            fenster.Content = meineGUI;
            fenster.ShowDialog();

            Console.ReadKey();

        }
        



    }
}

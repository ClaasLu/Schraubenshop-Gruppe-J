using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen im Schraubenshop!");    //Begrüßung
            auswahlSM();
            //Ausgabe
            //Preis etc.
        }

        static void auswahlSM()
        {
            int auswahl;
            Console.WriteLine("Wollen Sie eine Mutter oder Schraube kaufen?");
            Console.WriteLine("Für Schrauben geben Sie bitte die 1, für Muttern bitte die 2 ein");
            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.WriteLine("Schrauben");
                schraube();
            }
            else if (auswahl == 2)
            {
                Console.WriteLine("Muttern");
                muttern();
            }
            else
            {
                Console.WriteLine("Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                auswahlSM();
            }
        }
        static void schraube()
        {
            int auswahl;
            Console.WriteLine("Norm oder Sonderanfertigung?");
            Console.WriteLine("Für Norm geben Sie bitte die 1, für Sonderanfertigung bitte die 2 ein. Mit 3 gelangen Sie zum Hauptmenü!");
            auswahl = Convert.ToInt32(Console.ReadLine());
            if (auswahl == 1)
            {
                Console.WriteLine("Norm");
                schraube();
            }
            else if (auswahl == 2)
            {
                Console.WriteLine("Sonderanfertigung");
                muttern();
            }
            else if (auswahl == 3)
            {
                auswahlSM();
            }
            else
            {
                Console.WriteLine("Bitte wählen Sie eine der vorgeschlagenen Möglichkeiten aus!");
                schraube();
            }
        }
        static void muttern()
        {
            int auswahl;
            Console.WriteLine("Norm oder Sonderanfertigung?");
            Console.WriteLine("Für Norm geben Sie bitte die 1, für Sonderanfertigung bitte die 2 ein");
            auswahl = Convert.ToInt32(Console.ReadLine());
            if (auswahl == 1)
            {
                Console.WriteLine("Norm");
                schraube();
            }
            else if (auswahl == 2)
            {
                Console.WriteLine("Sonderanfertigung");
                muttern();
            }
            else
            {
                Console.WriteLine("Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                schraube();
            }


        }

        static void SechskantZylinderkopf()
        {

        }

        static void Zylinderkopf()
        {

        }

        static void Sechskant()
        {

        }


        static void SonderanfertigungSchraube()
        {

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Program
    {
        struct SechskantISO4017          // Struktur Sechskantschraube durchgehendes Gewinde            //????
        {
            public string Gewindgroeße;
            public int Gewindelaenge;
            public int Kopfhoehe;
            public int Schluesselweite;

        }
            
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen im Schraubenshop GJ!");    //Begrüßung
            SchraubenOderMuttern();


            //fehlt noch Ausgaben, Preis, etc.
        }

        static void SchraubenOderMuttern()          //Hauptmenü
        {
            int auswahl;

            Console.WriteLine("Wollen Sie Muttern oder Schrauben kaufen?");
            Console.WriteLine("Für Schrauben geben Sie bitte die 1, für Muttern bitte die 2 ein.");
           
            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Schrauben");
                Schrauben();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Muttern");
                Muttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                SchraubenOderMuttern();
            }
        }
        static void Schrauben()
        {
            int auswahl;

            Console.WriteLine("Wollen Sie Schrauben nach Norm oder nach Sonderanfertigung?");
            Console.WriteLine("Für Norm geben Sie bitte die 1, für Sonderanfertigung bitte die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl.");
            
            auswahl = Convert.ToInt32(Console.ReadLine());
           
            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Schrauben nach Norm");
                NormSchrauben();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Schrauben nach Sonderanfertigung");
                SonderanfertigungSchrauben();
            }
            else if (auswahl == 3)          //Zurück zur vorherigen Auswahl
            {
                Console.Clear();
                SchraubenOderMuttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der vorgeschlagenen Möglichkeiten aus!");
                Schrauben();
            }
        }

        static void Muttern()
        {
            int auswahl;

            Console.WriteLine("Wollen Sie eine Mutter nach Norm oder nach Sonderanfertigung?");
            Console.WriteLine("Für Norm geben Sie bitte die 1, für Sonderanfertigung bitte die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl.");

            auswahl = Convert.ToInt32(Console.ReadLine());
           
            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Norm");
                Schrauben();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Sonderanfertigung");
                Muttern();
            }
            else if (auswahl == 3)
            {
                Console.Clear();
                SchraubenOderMuttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der beiden vorgeschlagenen Möglichkeiten aus!");
                Muttern();
            }


        }

        static void NormSchrauben()
        {
            int auswahl;

            Console.WriteLine("Wollen Sie Sechskantschrauben oder Zylinderkopfschrauben kaufen?");
            Console.WriteLine("Für Sechskantschrauben geben Sie bitte die 1, für Zylinderkopfschrauben bitte die 2 ein. ");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Sechskantschrauben");
                Sechskantschrauben();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Zylinderkopfschrauben mit Innensechskant");
                Zylinderkopfschrauben();
            }
            else if (auswahl == 3)          //Zurück zur vorherigen Auswahl
            {
                Console.Clear();
                Schrauben();
            }
            else if (auswahl == 4)          //Zurück zum Hauptmenü
            {
                Console.Clear();
                SchraubenOderMuttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der vorgeschlagenen Möglichkeiten aus!");
                NormSchrauben();
            }
        }

        static void SonderanfertigungSchrauben()
        {
           
        }


        static void Sechskantschrauben()
        {
            int auswahl;

            Console.WriteLine("Wollen Sie Sechskantschrauben nach ISO 4017 (durchgehendes Gewinde) oder Sechskantschrauben nach ISO 4014 (mit Schaft) kaufen?");
            Console.WriteLine("Für ISO 4017 (durchgehendes Gewinde) geben Sie bitte die 1, für ISO 4014 (mit Schaft) bitte die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");


            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Sechskantschrauben nach ISO 4017 (durchgehendes Gewinde)");
                ISO4017();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Sechskantschrauben nach ISO 4014 (mit Schaft)");
                ISO4014();
            }
            else if (auswahl == 3)          //Zurück zur vorherigen Auswahl
            {
                Console.Clear();
                NormSchrauben();
            }
            else if (auswahl == 4)          //Zurück zum Hauptmenü
            {
                Console.Clear();
                SchraubenOderMuttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der vorgeschlagenen Möglichkeiten aus!");
                Sechskantschrauben();
            }
        }

        static void Zylinderkopfschrauben()
        {
            int auswahl;

            Console.WriteLine("Wollen Sie Zylinderkopfschrauben nach ISO 4762 (normaler Schraubenkopf) oder nach ISO 6912 (niedrieger Schraubenkopf) kaufen?");
            Console.WriteLine("Für ISO 4762 (normaler Schraubenkopf) geben Sie bitte die 1, für ISO 6912 (niedriger Kopf) bitte die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");


            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Zylinderkopfschrauben nach ISO 4762 (normaler Schraubenkopf)");
                ISO4762();
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Zylinderkopfschrauben nach ISO 6912 (niedrieger Schraubenkopf)");
                ISO6912();
            }
            else if (auswahl == 3)          //Zurück zur vorherigen Auswahl
            {
                Console.Clear();
                NormSchrauben();
            }
            else if (auswahl == 4)          //Zurück zum Hauptmenü
            {
                Console.Clear();
                SchraubenOderMuttern();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine der vorgeschlagenen Möglichkeiten aus!");
                Zylinderkopfschrauben();
            }
        }

        static void ISO4017()           //Sechskantschrauben nach ISO 4017 (durchgehendes Gewinde)
        {
            Console.WriteLine("Bitte geben Sie ihre Gewindegröße ein (z.B. M6).");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");        //noch nicht realiesiert

        }

        static void ISO4014()           //Sechskantschrauben nach ISO 4014 (Schaft)
        {
            Console.WriteLine("Bitte geben Sie ihre Gewindegröße ein (z.B. M6).");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");        //noch nicht realiesiert

        }

        static void ISO4762()           //Zylinderkopfschrauben nach ISO 4762 (normaler Schraubenkopf)
        {
            Console.WriteLine("Bitte geben Sie ihre Gewindegröße ein (z.B. M6).");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");        //noch nicht realiesiert

        }

        static void ISO6912()           //Zylinderkopfschrauben nach ISO 6912 (niedriger Schraubenkopf)
        {
            Console.WriteLine("Bitte geben Sie ihre Gewindegröße ein (z.B. M6).");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");        //noch nicht realiesiert
        }

    }
}

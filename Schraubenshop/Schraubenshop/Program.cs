using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Program 
    {
        struct Schraube //Struktur für eine Schraube
        {
            public string kopfart; //welcher Kopf (Sechskannt, Zylinderkopf...)
            public double kopfdicke; //wie hoch ist der Kopf
            public double antreibsgroeße; //SW bzw. Innensechskannt größe
            public double gewindedurchmesser; //bei Metrischen Gewinde ergibt sich das
            public double gewindesteigung; //bei Metrischen Gewinde ergibt sich das
            public double schaftlaenge; //muss länger bzw. gleich des Gewindes sein
            public double gewindelaenge; //muss kürzer bzw. gleich Schaft sein
        }
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
            Schraube sonderschraube = new Schraube(); //in diese Struktur werden die Informationen der geschreiben //was passiert wenn bei der Eingabe eine Minuszahl/0/Buchstaben eingibt eingegeben wird???

            int auswahl; //Variable zur Auswahl

            step1:

            Console.WriteLine("Welchen Schraubenkopf möchten bzw. mit welchem Antrieb");
            Console.WriteLine("Für Sechskanntschraube geben Sie bitte die 1, für Zylinderkopfschraube mit Innensechskannt die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Sechskantschrauben");
                sonderschraube.kopfart = "Sechskantschrauben";                
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Innensechskannt");
                sonderschraube.kopfart = "Innensechskannt";
            }
            else if (auswahl == 3)          //Zurück zur vorherigen Auswahl 
            {
                Console.Clear();
                goto step1; //springt am Anfang dieser Auswahl
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
                goto step1; //springt am Anfang dieser Auswahl
            }

            step2:
            
            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie hoch soll der Kopf werden"); 
            Console.WriteLine("Bitte geben Sie die Länge in mm ein (Mindestdicke:4mmm)");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if(auswahl>=4)
            {
                Console.Clear();
                Console.WriteLine("Dicke eingegeben");
                sonderschraube.kopfdicke = auswahl;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step2; //springt am Anfang dieser Auswahl
            }

            step3:

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie groß soll der Innensechskannt/die Schlüsselweite sein?");
            Console.WriteLine("Bitte geben sie für Ihre Schraube den passenden Wert ein (Minimum: SW3/Innenschechskant von 3");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl >= 3)
            {
                Console.Clear();
                Console.WriteLine("Der Antrieb ist vollständig angegegben");
                sonderschraube.antreibsgroeße = auswahl;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step3; //springt am Anfang dieser Auswahl
            }


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

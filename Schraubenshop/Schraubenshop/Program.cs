using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenshop
{
    class Program 
    {
        struct Schraube //Struktur für eine Schraube (bisher nur Sonderschrauben)
        {
            public string kopfart; //welcher Kopf (Sechskannt, Zylinderkopf...)
            public double kopfdicke; //wie hoch ist der Kopf
            public double antreibsgroeße; //SW bzw. Innensechskannt größe
            public double schaftdicke; //die Dicke des Schaftes
            public double schaftlaenge; //muss länger bzw. gleich des Gewindes sein
            public double gewindesteigung; //die Steigung des Gewindes (bei Metrischen Gewinden ergibt sich das)            
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
            int anzahl; //Variable zur Anzahl der Schrauben
            int preis = 0; ////Variable für den Preis der Schraube

            step1: //zur wiederholten Eingabe des Antriebs

            Console.WriteLine("Welchen Schraubenkopf möchten bzw. mit welchem Antrieb");
            Console.WriteLine("Für Sechskanntschraube geben Sie bitte die 1, für Zylinderkopfschraube mit Innensechskannt die 2 ein.");
            Console.WriteLine("Mit 3 kommen Sie zurück zur vorherigen Auswahl und mit 4 zurück zum Hauptmenü.");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl == 1)
            {
                Console.Clear();
                Console.WriteLine("Sechskantschrauben");
                sonderschraube.kopfart = "Sechskantschrauben"; //Sechskanntschraube ist ausgewählt und wird in "sonderschraube" gespeichert               
            }
            else if (auswahl == 2)
            {
                Console.Clear();
                Console.WriteLine("Innensechskannt");
                sonderschraube.kopfart = "Innensechskannt"; //Innensechskann ist ausgewählt und wird in "sonderschraube" gespeichert    
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

            step2: //zur wiederholten Eingabe der Kopfdicke

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie hoch soll der Kopf werden"); 
            Console.WriteLine("Bitte geben Sie die Länge in mm ein (Mindestdicke:4mmm)");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if(auswahl>=4)
            {
                Console.Clear();
                Console.WriteLine("Dicke eingegeben");
                sonderschraube.kopfdicke = auswahl; //Kopfdicke ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step2; //springt am Anfang dieser Auswahl
            }

            step3: //zur wiederholten Eingabe des Antriebs

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie groß soll der Innensechskannt/die Schlüsselweite sein?");
            Console.WriteLine("Bitte geben sie für Ihre Schraube den passenden Wert ein (Minimum: SW3/Innenschechskant von 3");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl >= 3)
            {
                Console.Clear();
                Console.WriteLine("Der Antrieb ist vollständig angegegben");
                sonderschraube.antreibsgroeße = auswahl; //Kopfdicke ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step3; //springt am Anfang dieser Auswahl
            }

            step4: //zur wiederholten Eingabe der Schaftdicke

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Welchen Durchmesser soll der Schaft haben?");
            Console.WriteLine("Bitte geben Sie den Durchmesser in mm ein (Mindestdurchmesser:3mmm)");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl >= 3)
            {
                Console.Clear();
                Console.WriteLine("Die Schaftdicke ist eingegegben"); 
                sonderschraube.schaftdicke = auswahl; //Schaftdicke ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step4; //springt am Anfang dieser Auswahl
            }

            step5: //zur wiederholten Eingabe der Schaftlänge

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie lang soll der Schaft sein?");
            Console.WriteLine("Bitte geben Sie die Länge in mm ein (Mindestlänge: 5mm)");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl >= 5)
            {
                Console.Clear();
                Console.WriteLine("Die Schaftlänge ist eingegegben");
                sonderschraube.schaftlaenge = auswahl; //Schaftlänge ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step5; //springt am Anfang dieser Auswahl
            }

            step6: //zur wiederholten Eingabe der Gewindesteigung ein

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Welche Steigung soll das Gewinde haben?");
            Console.WriteLine("Bitte geben Sie die Steigung ein");

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl > 0)
            {
                Console.Clear();
                Console.WriteLine("Die Steigung des Gewindes ist eingegegben");
                sonderschraube.gewindesteigung = auswahl; //die Steigung des Gewindes ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step6; //springt am Anfang dieser Auswahl
            }

            step7: //zur wiederholten Eingabe der Gewindelänge

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie lang soll das Gewinde gehen?");
            Console.WriteLine("Bitte geben Sie die Gewindelänge in mm ein");
            Console.WriteLine("Beachten Sie, das die Länge des Gewindes nicht länger als der Schaft sein!");
            Console.WriteLine("Schaftlänge:"+Convert.ToString(sonderschraube.schaftlaenge)+ "mm"); //Ausgae der Schaftlänge (geht noch nicht)

            auswahl = Convert.ToInt32(Console.ReadLine());

            if (auswahl <= sonderschraube.schaftlaenge)
            {
                Console.Clear();
                Console.WriteLine("Die Länge des Gewindes ist eingegeben");
                sonderschraube.gewindelaenge = auswahl; //die Länge des Gewindes ist eingegben und wird in "sonderschraube" gespeichert
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step7; //springt am Anfang dieser Auswahl
            }

            step8: //zur wiederholten Eingabe der Anzahl

            auswahl = 0;//Zur Sicherheit Variable clearen

            Console.WriteLine("Wie oft möchten sie die Scharube haben?");
            Console.WriteLine("Bitte geben Sie die gewünschte Anzahl einfach als Zahl ein");

            anzahl = Convert.ToInt32(Console.ReadLine());

            if (anzahl > 0)
            {
                Console.Clear();
                Console.WriteLine("Die Anzahl ist eigegen ist eingegeben");
                
            }
            else if (anzahl == 0) //keine Schraube
            {
                Console.Clear();
                Console.WriteLine("Sind sie sich Sicher keine Schraube haben zu wollen");
                Console.WriteLine("Wenn Sie keine Schraube haben wollen geben Sie bitte die 1 ein , für eine erneute Eingabe geben Sie 2 ein.");

                auswahl = Convert.ToInt32(Console.ReadLine());

                if (auswahl==1)
                {
                    Console.Clear();
                    SchraubenOderMuttern();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("erneute Eingabe");
                    goto step8; //springt am Anfang dieser Auswahl
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("ungültiger Wert!");
                goto step8; //springt am Anfang dieser Auswahl
            }

            Console.WriteLine("Schraubenkopfart:");
            Console.WriteLine("Schraubenkopfdicke");
            Console.WriteLine("Antriebsgröße:");
            Console.WriteLine("Schaftdicke:");
            Console.WriteLine("Schaftlänge");
            Console.WriteLine("Gewindesteigung:");
            Console.WriteLine("Gewindelänge:");
            Console.WriteLine("Anzahl:");

            preis = 3 * anzahl;

            Console.WriteLine("Preis:");
            Console.ReadLine();

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

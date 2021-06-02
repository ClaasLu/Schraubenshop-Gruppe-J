using System;
using System.Windows;

namespace Schraubenshop
{
    public class CatiaControl
    {
 

        public CatiaControl(Schraube myScrew)
        {
            Schraube dieSchraube = myScrew;
            try
            {
                
                CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    // Sechskantschraube
                    if (myScrew.Schraubenart == 1)
                    {
                        // Öffne ein neues Part
                        cc.ErzeugePart();

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        cc.ErzeugeZylinder2(dieSchraube);

                        // cc.ErzeugeGewindeFeature();
                        cc.ErzeugeGewindeHelix(dieSchraube);

                        // Kopf und Offset Ebene
                        cc.OffsetEbeneSk(dieSchraube);

                        MessageBox.Show("Daten wurden erfolgreich an Catia übergeben!");

                    }

                    //Zylinderkopfschraube
                    else if (myScrew.Schraubenart == 2)
                    {
                        // Öffne ein neues Part
                        cc.ErzeugePart();

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        cc.ErzeugeZylinder2(dieSchraube);

                        // cc.ErzeugeGewindeFeature();
                        cc.ErzeugeGewindeHelix(dieSchraube);
                        

                        // Offset Ebene und Kopf erzeugen
                        cc.OffsetEbene(dieSchraube);

                        MessageBox.Show("Daten wurden erfolgreich an Catia übergeben!");


                    }


                    //Gewindestift
                    else if (myScrew.Schraubenart == 3)
                    {
                        // Öffne ein neues Part
                        cc.ErzeugePart();

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        cc.ErzeugeZylinder(dieSchraube);

                        // cc.ErzeugeGewindeFeature();
                        cc.ErzeugeGewindeHelix(dieSchraube);
                        MessageBox.Show("Daten wurden erfolgreich an Catia übergeben!");
                    }

                    //Senkkopfschraube
                    else
                    {
                        // Öffne ein neues Part
                        cc.ErzeugePart();

                        // Erstelle eine Skizze
                        cc.ErstelleLeereSkizze();

                        cc.ErzeugeZylinder2(dieSchraube);

                        // cc.ErzeugeGewindeFeature();
                        cc.ErzeugeGewindeHelix(dieSchraube);

                        // Erzeuge neue Skizze
                        cc.ErzeugeSkizzeSenkkopf(dieSchraube);

                        // Erzeuge Senkkopf
                        cc.ErzeugeSenkkopf(dieSchraube);
                      

                        MessageBox.Show("Daten wurden erfolgreich an Catia übergeben!");
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }
            
            

        }

        
    }
}


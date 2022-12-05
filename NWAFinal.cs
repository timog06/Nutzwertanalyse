using System.Text;

namespace NWA
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool check = false;
            bool abrechen = false;
            List<string> Angabe = new List<string>();
            List<string> Kriterien = new List<string>();
            List<int> Gewichtung = new List<int>();
            List<int> Benotung = new List<int>();
            Program t = new Program();
            t.Oeberflaeche();
            int anzahl = 1;
            do
            {
                Console.Clear();
                t.Oeberflaeche();
                Console.WriteLine("Geben sie Angabe {0} ein: ", anzahl);
                if (anzahl > 2)
                {
                    Console.WriteLine("(n für den nächsten schritt)");
                }
                string abbruch = Console.ReadLine();
                if (abbruch == "n")
                {
                    abrechen = true;
                }
                else
                {
                    Angabe.Add(abbruch);
                }
                anzahl++;
            } while (abrechen == false);
            abrechen = false;
            anzahl = 1;
            do
            {
                Console.Clear();
                t.Oeberflaeche();
                Console.WriteLine("Geben sie Kriterien {0} ein: ", anzahl);
                if (anzahl > 2)
                {
                    Console.WriteLine("(n für den nächsten schritt)");
                }
                string abbruch = Console.ReadLine();
                if (abbruch == "n")
                {
                    abrechen = true;
                }
                else
                {
                    Kriterien.Add(abbruch);
                }
                anzahl++;
            } while (abrechen == false);
            int maximum = 100;
            for (int i = 0; i < Kriterien.Count; i++)
            {
                Console.Clear();
                t.Oeberflaeche();
                do
                {
                    try
                    {
                        check = false;
                        Console.WriteLine("Welche Gewichtung soll Kriterium {0} haben? (Max 100)", Kriterien[i]);
                        Console.WriteLine("(Sie haben noch {0} Punkte)", maximum);
                        int eingabe = Convert.ToInt32(Console.ReadLine());
                        if (eingabe > maximum || eingabe < 0)
                        {
                            throw new Exception();
                        }
                        maximum = maximum - eingabe;
                        Gewichtung.Add(eingabe);
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        check = true;
                    }
                } while (check == true);
            }
            Console.Clear();
            t.Oeberflaeche();
            for (int i = 0; i < Angabe.Count; i++)
            {
                Console.Clear();
                t.Oeberflaeche();
                Console.WriteLine("Angabe {0}:", Angabe[i]);
                for (int z = 0; z < Kriterien.Count; z++)
                {
                    do
                    {
                        try
                        {
                            check = false;
                            Console.WriteLine("Welche Benotung für das Kriterium {0} (1-6)", Kriterien[z]);
                            int eingabe = Convert.ToInt32(Console.ReadLine());
                            if (eingabe > 6 || eingabe < 1)
                            {
                                throw new Exception();
                            }
                            Benotung.Add(eingabe);
                        }
                        catch
                        {
                            Console.WriteLine("Ungültige Eingabe");
                            check = true;
                        }
                    } while (check == true);
                }
            }
            Console.Clear();
            t.Oeberflaeche();
            int d = 0;
            for (int i = 0; i < Angabe.Count; i++)
            {
                Console.WriteLine("Angabe {0}:", Angabe[i]);
                Console.WriteLine("Kriterien:   Gewichtung:   Benotung:");
                for (int f = 0; f < Kriterien.Count; f++)
                {
                    Console.WriteLine("{0}, {1}, {2}", Kriterien[f], Gewichtung[f], Benotung[d]);
                    d++;
                }
            }
            Console.WriteLine("Beliebige Taste drücken zum Fortfahren");
            Console.ReadKey();
            Console.Clear();
            t.Oeberflaeche();
            List<int> summList = new List<int>();
            d = 0;
            for (int f = 0; f < Angabe.Count; f++)
            {
                int zwischensumme = 0;
                for (int i = 0; i < Kriterien.Count; i++)
                {
                    zwischensumme = zwischensumme + (Benotung[d] * Gewichtung[i]);
                    d++;
                }
                summList.Add(zwischensumme);
                Console.WriteLine("Das Resultat von Angabe {0} ist: {1}", Angabe[f], zwischensumme);
            }
            Console.WriteLine("Beliebige Taste drücken zum Fortfahren");
            Console.ReadKey();
            Console.Clear();
            t.Oeberflaeche();
            for (int i = 0; i < Angabe.Count; i++)
            {
                if (summList[i] == summList.Max())
                {
                    Console.WriteLine("Die beste Angabe ist {0} mit {1} Punkten", Angabe[i], summList.Max());
                }
            }
            for (int i = 0; i < Angabe.Count; i++)
            {
                if (summList[i] == summList.Min())
                {
                    Console.WriteLine("Die schlechteste Angabe ist {0} mit {1} Punkten", Angabe[i], summList.Min());
                }
            }
            try
            {
                bool hm = false;
                do
                {
                    Console.Clear();
                    t.Oeberflaeche();
                    Console.WriteLine("Geben Sie den Dateipfad und den Dateiname ein (Wenn Sie einen schon existierenden Namen eingeben wird diese Datei überschrieben): ");
                    Console.WriteLine("Bsp. C:/Users/Benutzer/OneDrive/Dokumente/Nutzwertanalyse.txt");
                    string eingabe = Console.ReadLine();
                    StreamWriter sw = new StreamWriter(eingabe, false, Encoding.Unicode);
                    Thread.Sleep(300);
                    Console.WriteLine("Sind Sie sicher das {0} Ihr Dateipfad ist? [ja/nein]", eingabe);
                    string bestätigung = Console.ReadLine();
                    switch (bestätigung)
                    {
                        case "ja":
                            hm = true;
                            break;

                        case "nein":
                            hm = true;
                            break;

                        case "[ja]":
                            hm = true;
                            break;

                        case "[nein]":
                            hm = true;
                            break;

                        default:
                            Console.WriteLine("Bitte geben sie [ja] oder [nein] ein. ");
                            Thread.Sleep(500);
                            hm = false;
                            break;
                    }
                    for (int i = 0; i < Angabe.Count; i++)
                    {
                        if (summList[i] == summList.Max())
                        {
                            sw.WriteLine("Die beste Angabe ist {0} mit {1} Punkten", Angabe[i], summList.Max());
                        }
                    }
                    for (int i = 0; i < Angabe.Count; i++)
                    {
                        if (summList[i] == summList.Min())
                        {
                            sw.WriteLine("Die schlechteste Angabe ist {0} mit {1} Punkten", Angabe[i], summList.Min());
                        }
                    }
                    sw.Close();
                } while (hm == false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Datei wurde erfolgreich gespeichert.");
            }
        }

        public void Oeberflaeche()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  _   _       _                          _                    _                ");
            Console.WriteLine(" | \\ | |_   _| |_ ______      _____ _ __| |_ __ _ _ __   __ _| |_   _ ___  ___ ");
            Console.WriteLine(" |  \\| | | | | __|_  /\\ \\ /\\ / / _ \\ '__| __/ _` | '_ \\ / _` | | | | / __|/ _ \\");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" | |\\  | |_| | |_ / /  \\ V  V /  __/ |  | || (_| | | | | (_| | | |_| \\__ \\  __/");
            Console.WriteLine(" |_| \\_|\\__,_|\\__/___|  \\_/\\_/ \\___|_|   \\__\\__,_|_| |_|\\__,_|_|\\__, |___/\\___|");
            Console.WriteLine("                                                                |___/          ");
        }
    }
}

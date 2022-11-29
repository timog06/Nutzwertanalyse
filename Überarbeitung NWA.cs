using System.Data;
using System.Text;
using System.Xml;

namespace Nutzwertanalyse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int x = 0;
            int krit = 0;
            int k = 0;
            int n = 0;
            int y = 0;
            int zahlkrit = 1;
            bool check = true;
            string weiter = "";
            string weiter2 = "";

            List<int> Note = new List<int>();

            int[] AnzKrit = new int[0];
            int[] AnzFir = new int[y];

            List<string> listFirma = FirmList(check, y, AnzFir, x, weiter, n);

            Console.WriteLine("-----------------------");
            Console.WriteLine("Eingegebenen Angaben");
            listFirma.ForEach(Console.WriteLine);

            Console.WriteLine("Drücken Sie eine Taste um weiterzufahren...");
            Console.ReadKey();
            Thread.Sleep(300);
            Console.Clear();

            bool check2 = true;
            n = 0;

            List<string> listKriterien = KritList(check, k, AnzKrit, n, zahlkrit, check2, weiter2);

            Console.WriteLine("Die Kriterien zu den Angaben");
            Console.WriteLine("----------------------------");
            listKriterien.ForEach(Console.WriteLine);

            Console.WriteLine("Drücken Sie eine Taste um weiterzufahren...");
            Console.ReadKey();
            Thread.Sleep(300);
            Console.Clear();

            k = listKriterien.Count;

            Console.WriteLine("Gib die Bewertung der " + k + " Kriterien ein");

            int[] Bewertung = new int[k];
            int hundert = 100;

            krit = -1;
            n = 0;

            for (; n < Bewertung.Length; n++)
            {
                do
                {
                    Console.Clear();
                    krit++;
                    Console.WriteLine("Bewertung zur " + listKriterien[krit]);
                    Console.WriteLine("(Max 100) Momentan übrig: {0} ", hundert);
                    check = true;
                    try
                    {
                        Bewertung[krit] = Convert.ToInt32(Console.ReadLine());
                        hundert -= Bewertung[krit];

                        if (hundert < 0 || hundert > 100)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(800);
                        hundert += Bewertung[krit];
                        krit--;
                        check = false;
                    }
                } while (check == false);
            }
            Console.WriteLine("-----------------------");
            Array.ForEach(Bewertung, Console.WriteLine);

            n = 0;
            int not = -1;
            int notZahl = 0;
            int hallo = listKriterien.Count * listFirma.Count;
            List<List <int> > benotungMalKriterien = new List<List <int>>();
            for (int i = 0; i < listFirma.Count; i++)
            {
                Note = new();

                for (n = 0; n < listKriterien.Count; n++)
                {
                    do
                    {
                        Console.Clear();
                        check = true;
                        not++;
                        Console.WriteLine("Firma {0}", listFirma[i]);
                        Console.WriteLine("Kriterium {0}", listKriterien[n]);
                        Console.WriteLine("Gebe nun die Note für " + " (1-6)");
                        try
                        {
                            notZahl = (Convert.ToInt32(Console.ReadLine()));
                            if (notZahl >= 1 && notZahl <= 6)
                            {
                                Note.Add(notZahl);
                            }
                            else
                            {
                                Console.WriteLine("Ungültige Eingabe");
                                Thread.Sleep(800);
                                not--;
                                check = false;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ungültige Eingabe");
                            Thread.Sleep(800);
                            not--;
                            check = false;
                        }
                    } while (check == false);
                }
                benotungMalKriterien.Add(Note);
            }

            Console.WriteLine("-----------------------");
            Note.ForEach(Console.WriteLine);

            int ne = 0;
            krit = 0;
            int me = 0;

            int kl = 0;
            int sv = 0;

            int ArryErg = 0;
            double EndRoundMax = 0;
            double EndRoundMin = 0;
            int[] anzahl = new int[0];

            List<double> Ergebnis = new List<double>();

            n = 0;

            for (; n < Bewertung.Length; n++)
            {
                Ergebnis.Add(Note[ne] * Bewertung[me]);
                ne++;
                me++;
                kl++;
            }
            Console.Clear();
            n = 0;
            anzahl = new int[kl];

            Console.WriteLine("Gerechnete Angaben");
            Console.WriteLine("-----------------------");
            Ergebnis.ForEach(Console.WriteLine);

            EndRoundMax = Ergebnis.Max();
            EndRoundMin = Ergebnis.Min();
            Console.WriteLine("Die beste Angabe ist: " + EndRoundMax);
            Console.WriteLine("Die schlechteste Anagbe ist: " + EndRoundMin);
            for (int i = 0; i < listFirma.Count; i++)
            {
                Console.WriteLine("Angabe:");
                Console.WriteLine(listFirma[i]);
                Console.WriteLine("Kriterien, Gewichtung, Note:");
                for (int z = 0; z < Bewertung.Length; z++)
                {
                    Console.WriteLine("{0},   {1},   {2}", listKriterien[z], Bewertung[z], Note[z]);
                }
            }

            try
            {
                bool hm = false;
                do
                {
                    Console.WriteLine("Geben Sie den Dateipfad und den Dateiname ein:");
                    Console.WriteLine("Bsp. C:/Users/timog/OneDrive/Dokumente/Nutzwertanalyse.txt");
                    StreamWriter sw = new StreamWriter(Console.ReadLine(), false, Encoding.Unicode);
                    Thread.Sleep(300);
                    Console.WriteLine("Sind Sie sicher das {0} Ihr Dateipfad ist? [ja/nein]", sw);
                    string eingabe = Console.ReadLine();
                    if (eingabe != "ja" && eingabe != "nein")
                    {
                        Console.WriteLine("Bitte geben sie [ja] oder [nein] ein. ");
                        Thread.Sleep(500);
                        hm = false;
                    }
                    else if (eingabe == "nein")
                    {
                        hm = false;
                    }
                    else if (eingabe == "ja")
                    {
                        hm = true;
                    }
                    else if (eingabe == "[ja]" || eingabe == "[nein]")
                    {
                        hm = true;
                    }

                    Ergebnis.ForEach(sw.WriteLine);
                    sw.WriteLine("Die meist geignete Angabe ist: {0}", EndRoundMax);
                    sw.WriteLine("Die wenigst geignete Angabe ist: {0}", EndRoundMin);
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

        private static List<string> KritList(bool check, int k, int[] AnzKrit, int n, int zahlkrit, bool check2, string weiter2)
        {
            List<string> Kriterien = new List<string>();

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Geben Sie nun die Anzahl Kritreien ein ");
                    check = true;
                    try
                    {
                        k = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(800);
                        check = false;
                    }
                } while (check == false);
                AnzKrit = new int[k];

                for (; n < AnzKrit.Length; n++)
                {
                    do
                    {
                        check = true;

                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Kriterium: {0}", zahlkrit);
                            Kriterien.Add(Console.ReadLine());
                            zahlkrit++;
                        }
                        catch
                        {
                            Console.WriteLine("Ungültige Eingabe");
                            Thread.Sleep(800);
                            check2 = false;
                        }
                    } while (check2 == false);
                }
            } while (weiter2 == "y");

            return Kriterien;
        }

        public static List<string> FirmList(bool check, int y, int[] AnzFir, int x, string weiter, int n)
        {
            List<string> Firma = new List<string>();
            do
            {
                do
                {
                    check = true;
                    try
                    {
                        Console.Clear();
                        Program t = new Program();
                        t.Oeberflaeche();
                        Console.WriteLine("Nutzwertanalyse");
                        Console.WriteLine("Wie viele Angaben wollen Sie Eingeben?");
                        y = Convert.ToInt32(Console.ReadLine());
                        AnzFir = new int[y];

                        for (; n < AnzFir.Length; n++)
                        {
                            Console.WriteLine("Geben sie eine Angabe ein: ");
                            Firma.Add(Console.ReadLine());
                            x++;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(800);
                        check = false;
                    }
                } while (check == false);
            } while (weiter == "y" || check == false);
            Console.WriteLine("Anzahl Angaben: {0}", x);
            return Firma;
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

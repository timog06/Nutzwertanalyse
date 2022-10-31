```c#
using System.IO;
using System.Text;

namespace Nutzwertanalyse_LISTE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int x = 0;
            int krit = 0;
            int k = 0;
            int n = 0;
            int zahlkrit = 1;
            bool check = true;


            string weiter = "";
            string weiter2 = "";

            List<string> Firma = new List<string>();
            List<string> Kriterien = new List<string>();
            List<int> Note = new List<int>();

            int[] AnzKrit = new int[0];

            do
            {
                do
                {
                    check = true;
                    try
                    {
                        Console.WriteLine("Nutzwertanalyse");
                        Console.WriteLine("Wie viele Firmen wollen Sie Eingeben?");
                        int y = Convert.ToInt32(Console.ReadLine());
                        int[] AnzFir = new int[y];

                        for (; n < AnzFir.Length; n++)
                        {
                            Console.WriteLine("Gebe Firma ein: ");
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

                try
                {
                    do
                    {
                        check = true;
                        Console.WriteLine("Noch eine Firma? [y|n]");
                        weiter = Console.ReadLine();
                        if (weiter != "y" && weiter != "n")
                        {
                            Console.WriteLine("Ungültige Eingabe");
                            Thread.Sleep(800);
                            check = false;
                        }
                    } while (check == false);
                }
                catch
                {
                    Console.WriteLine("Ungültige Eingabe");
                    Thread.Sleep(800);
                    check = false;
                }

            } while (weiter == "y" || check == false);

            Console.WriteLine("Anzahl Firmen: {0}", x);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Eingegebenen Firmen");
            Firma.ForEach(Console.WriteLine);

            Console.WriteLine("");
            Console.WriteLine("Drücken Sie eine Taste um weiterzufahren");
            Console.ReadKey();

            Thread.Sleep(300);
            Console.Clear();

            n = 0;
            do
            {

                do
                {
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

                bool check2 = true;
                for (; n < AnzKrit.Length; n++)
                {
                    do
                    {
                        check = true;

                        try
                        {
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




                do
                {
                    check2 = true;
                    do
                    {
                        check = true;
                        try
                        {
                            Console.WriteLine("Möchten Sie noch Kriterien Eingeben? [y|n]");
                            weiter2 = Console.ReadLine();
                        }
                        catch
                        {
                            Console.WriteLine("Ungültige Eingabe");
                            check2 = false;
                        }
                    } while (check2 == false);

                    check2 = true;

                    if (weiter2 != "y" && weiter2 != "n")
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(500);
                        Console.Clear();
                        check2 = false;

                    }
                } while (check2 == false);

            } while (weiter2 == "y");

            Console.WriteLine("Die Kriterien zu den Firmen");
            Console.WriteLine("----------------------------");
            Kriterien.ForEach(Console.WriteLine);

            Console.WriteLine("");
            Console.WriteLine("Drücken Sie eine Taste um weiterzufahren");
            Console.ReadKey();

            Thread.Sleep(300);
            Console.Clear();


            Console.WriteLine("Gib die Bewertung der " + k + " Kriterien ein");

            int[] Bewertung = new int[k];
            int hundert = 100;


            krit = -1;
            n = 0;


            for (; n < Bewertung.Length; n++)
            {

                do
                {
                    krit++;
                    Console.WriteLine("Bewertung zur " + Kriterien[krit]);
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

            for (; n < Bewertung.Length; n++)
            {
                do
                {
                    check = true;
                    not++;
                    Console.WriteLine("Gebe nun die Note für " + Kriterien[not] + " (1-6)");
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




            Console.WriteLine("-----------------------");
            Note.ForEach(Console.WriteLine);

            int ne = 0;
            krit = 0;
            int me = 0;
            int kl = 0;
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

            Console.WriteLine("Gerechnete Firmen");
            Console.WriteLine("-----------------------");
            Ergebnis.ForEach(Console.WriteLine);

            EndRoundMax = Ergebnis.Max();
            EndRoundMin = Ergebnis.Min();

            Console.WriteLine("Die beste Firma ist: " + EndRoundMax);

            try
            {
                Console.WriteLine("Geben Sie den Dateipfad und den Dateiname ein:");
                Console.WriteLine("Bsp. C:/Users/timog/OneDrive/Dokumente/Nutzwertanalyse.txt");

                StreamWriter sw = new StreamWriter(Console.ReadLine(), true, Encoding.Unicode);

                Ergebnis.ForEach(sw.WriteLine);

                sw.WriteLine("Die meist geignete Firma ist: {0}", EndRoundMax);

                sw.WriteLine("Die wenigst geignete Firma ist: {0}", EndRoundMin);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
    }
}
```
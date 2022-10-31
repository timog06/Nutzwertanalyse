```c#
namespace Nutzwertanalyse_LISTE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int x = 0;
            int p = 0;
            int krit = 0;
            int not = -1;
            int k = 0;
            int ze = 0;
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

            Console.ReadKey();

            Thread.Sleep(500);
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

            Console.ReadKey();

            Thread.Sleep(500);
            Console.Clear();


            Console.WriteLine("Gib die Bewertung der " + k + " Kriterien ein");

            int[] Bewertung = new int[k];
            bool gemacht = false;
            int zahlfürber = 0;
            int hundert = 100;

            int FürBewertung = hundert - Bewertung[krit];



            krit = 0;
            n = 0;

            for (; n < Bewertung.Length; n++)
            {

                do
                {
                    Console.WriteLine("Bewertung zur " + Kriterien[krit]);
                    Console.WriteLine("(Max 100) Momentan übrig: {0} ", FürBewertung);
                    check = true;
                    try
                    {
                        Bewertung[krit] = Convert.ToInt32(Console.ReadLine());
                        FürBewertung = hundert -= Bewertung[krit];
                        krit++;



                        if (FürBewertung < 0 || FürBewertung > 100)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(800);
                        krit--;
                        FürBewertung += Bewertung[krit];
                        check = false;
                    }
                } while (check == false);

            }
            Console.WriteLine("-----------------------");
            Array.ForEach(Bewertung, Console.WriteLine);
            n = 0;



            for (; n < Bewertung.Length; n++)
            {
                check = true;
                do
                {


                    not++;
                    Console.WriteLine("Gebe nun die Note für " + Kriterien[not] + " (1-6)");
                    try
                    {
                        Note.Add(Convert.ToInt32(Console.ReadLine()));
                        if (Note[not] > 6 || Note[not] < 1)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        Thread.Sleep(800);
                        check = false;
                    }
                } while (check == false);

            }




            Console.WriteLine("-----------------------");
            Note.ForEach(Console.WriteLine);

            int me = 0;
            int ne = 0;
            krit = 0;

            int kl = 0;
            int sv = 0;

            int ArryErg = 0;
            double EndRound = 0;
            int[] anzahl = new int[0];



            List<double> Ergebnis = new List<double>();

            n = 0;

            for (; n < Bewertung.Length; n++)
            {


                Ergebnis.Add(Note[ne] * Bewertung[me]);


                ArryErg++;

                me++;
                ne++;
                kl++;
                sv++;

            }
            n = 0;
            anzahl = new int[kl];

            Console.WriteLine("Gerechnete Firmen");
            Console.WriteLine("-----------------------");
            Ergebnis.ForEach(Console.WriteLine);

            int zählzahl = 0;
            for (; n < anzahl.Length; n++)
            {
                EndRound = (Math.Max(Ergebnis[zählzahl], 0));
                zählzahl++;
            }

            Console.WriteLine("Die beste Firma ist: " + EndRound);



        }
    }
}
```

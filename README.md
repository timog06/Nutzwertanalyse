```c#

using System;

namespace Nutzwertanalyse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int check = -1;
            int anzFirmen = 0;
            int anzKriterien = 0;
            int[] end = new int[anzFirmen];
            int i = 0;
            int x = 0;
            int y = 0;

            Console.WriteLine("Willkommen zur Nutzwertanalyse.");
        Start1:
            Console.WriteLine("Wie viele Alternativen wollen Sie haben? ");
            string anzFirmenStr = Console.ReadLine();
            if (!int.TryParse(anzFirmenStr, out check))
            {
                Console.WriteLine("Bitte geben sie eine Zahl ein.");
                Thread.Sleep(500);
                Console.Clear();
                goto Start1;
            }
            else
            {
                anzFirmen = Convert.ToInt32(anzFirmenStr);
            }

        Start2:
            string[] firmen = new string[anzFirmen];
            for (; y < anzFirmen; y++)
            {
                Console.WriteLine("Geben Sie eine Alternative ein: ");
                firmen[y] = Console.ReadLine();
                if (int.TryParse(firmen[y], out check))
                {
                    Console.WriteLine("Ungültige Eingabe");
                    Thread.Sleep(500);
                    Console.Clear();
                    goto Start2;
                }

            }

            Thread.Sleep(500);
            Console.Clear();

        Start3:
            Console.WriteLine("Wie viele Kriterien wollen Sie haben? ");
            string anzKriterienStr = Console.ReadLine();
            if (!int.TryParse(anzKriterienStr, out check))
            {
                Console.WriteLine("Bitte geben sie eine Zahl ein.");
                Thread.Sleep(500);
                Console.Clear();
                goto Start3;
            }
            else
            {
                anzKriterien = Convert.ToInt32(anzKriterienStr);
            }
        Restart1:
            string[] kriterien = new string[anzKriterien];
            for (; i < anzKriterien; i++)
            {
                Console.WriteLine("Geben Sie ein Kriterium ein: ");
                kriterien[i] = Console.ReadLine();
                if (int.TryParse(kriterien[i], out check))
                {
                    Console.WriteLine("Ungültige Eingabe.");
                    Thread.Sleep(500);
                    Console.Clear();
                    goto Restart1; ;
                }
            }

            Thread.Sleep(500);
            Console.Clear();

        Start4:
            int[] gewichtung = new int[anzKriterien];
            Console.WriteLine("Geben Sie Ihren Kriterien eine Gewichtung von Insgesamt 100.");
            for (; x < anzKriterien; x++)
            {
                Console.WriteLine("Geben Sie dem Kriterium {0} eine Gewichtung: ", kriterien[x]);
                gewichtung[x] = Convert.ToInt32(Console.ReadLine());
                if (gewichtung[x] < 1 || gewichtung[x] > 100)
                {
                    Console.WriteLine("Ungültige Eingabe");
                    Thread.Sleep(500);
                    Console.Clear();
                    goto Start4;
                }
            }
            int sum = gewichtung.Sum();

            if (sum > 100)
            {
                Thread.Sleep(1500);
                Console.WriteLine("Ihre Totale Gewichtung liegt über 100.");
                Console.WriteLine("Gewichten Sie Ihre Kriterien nocheinmal");
                Thread.Sleep(3000);
                x = 0;
                goto Start4;
            }

            Thread.Sleep(500);
            Console.Clear();

            Console.WriteLine("Dies sind Ihre eingegebenen Firmen: ");
            Array.ForEach(firmen, Console.WriteLine);

            Console.WriteLine("Dies sind Ihre Kriterien: ");
            Array.ForEach(kriterien, Console.WriteLine);


            Console.WriteLine("Dies sind die Gewichtungen zu den Kriterien: ");
            Array.ForEach(gewichtung, Console.WriteLine);
            Console.WriteLine("Ihre Totale Gewichtung liegt bei {0}.", sum);

            Console.WriteLine("Drücken Sie eine Taste, um weiterzufahren.");
            Console.ReadKey();
            Console.Clear();

        Start5:

            int anzBenotungen = anzFirmen * anzKriterien;
            int[] benotung = new int[anzBenotungen];

            for (int f = 0; f < firmen.Length; f++)
            {
                for (int j = 0; j < kriterien.Length; j++)
                {
                    Console.WriteLine("Geben Sie {0} für das Kriterium {1} eine Benotung von 1 bis 10: ", firmen[f], kriterien[j]);
                    benotung[f] = Convert.ToInt32(Console.ReadLine());
                    if (benotung[f] > 10 || benotung[f] < 1)
                    {
                        Console.WriteLine("Ungültige Eingabe");
                        goto Start5;
                    }
                }
            }

            for (int zähler = 0; zähler < gewichtung.Length; zähler++)
            {
                end[zähler] = gewichtung[zähler] * benotung[zähler];
            }

            int maxValue = end.Max();
            Array.ForEach(end, Console.WriteLine);
            Console.WriteLine("Ihr höchster Totaler Nutzwert ist {0}", maxValue);
        }
    }
}
```

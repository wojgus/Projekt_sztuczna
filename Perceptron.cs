using System;
using System.Collections.Generic;
using System.Linq;

namespace Perceptron
{
    class Perceptron
    {
        // można zamienić na pola, przy czym niektóre mogą być readonly
        #region wlasciwosci klasy
        /// <summary>Liczba punktów w zbiorze uczącym</summary>
        int N { get; set; }
        /// <summary>Współczynnik uczenia</summary>
        double Rho { get; set; }
        double[] Wagi { get; set; }     //w0. w1 i w2
        Punkt[] Punkty { get; set; }    //x1 i x2 n razy
        int[] Wartosci { get; set; }    //d n razy
        List<double> Sygnal { get; set; }   //s
        List<int> Wyjscia { get; set; }  //y
        //int Epoka { get; set; }         //e
        int Czas { get; set; }          //t
        #endregion

        public Perceptron(int n, IEnumerable<double> wagi, double rho, double a, double b)
        {
            N = n;
            Wagi = wagi.ToArray();
            Rho = rho;
            Czas = -1;
            Punkty = WylosujNRoznychPunktow(N);
            Wartosci = GetWartosciDlaPunktowIUnipolarnejFunkcjiAktywacji(Punkty, a, b);
            Sygnal = new List<double>();
            Wyjscia = new List<int>();

            Console.WriteLine("Epoka | t | x0(t) | x1(t) |  x2(t) |  d(t) | w0(t) | w1(t) |  w2(t) |  s(t) | y(t) | ok?");

            while (!Test())
            {
                WykonajKrok();
                Console.Write($"{Czas / N + 1}| {Czas} | 1 | {Punkty[Czas % N].X} | {Punkty[Czas % N].Y} ");
                Console.Write($"| {Wartosci[Czas % N]} ");
                Console.Write($"| {Wagi[0]} | {Wagi[1]} | {Wagi[2]} | {Sygnal[Czas]} | {Wyjscia[Czas]} ");
                Console.WriteLine(Wartosci[Czas % N] == Wyjscia[Czas] ? "| ok" : "| -");
            }
        }

        private void WykonajKrok()
        {
            Czas++; // uwaga: czas startuje od -1
            if (Czas != 0)
            {
                int roznica = Wartosci[(Czas - 1) % N] - Wyjscia[Czas - 1];

                // obliczenie nowego wektora wag
                Wagi[0] = Wagi[0] + Rho * roznica;
                Wagi[1] = Wagi[1] + Rho * roznica * Punkty[Czas % N].X;
                Wagi[2] = Wagi[2] + Rho * roznica * Punkty[Czas % N].Y;
            }

            // obliczenie sygnału i wyjścia
            Sygnal.Add(Wagi[0] + Punkty[Czas % N].X * Wagi[1] + Punkty[Czas % N].Y * Wagi[2]);
            Wyjscia.Add(Sygnal[Czas] > 0 ? 1 : 0);
        }

        private bool Test()
        {
            if (Wyjscia.Count < N)
                return false;
            for (int i = 0; i < N; i++)
                if (Wyjscia[Czas - i] != Wartosci[(Czas - i) % N])
                    return false;
            return true;
        }

        private static Punkt[] WylosujNRoznychPunktow(int n)
        {
            if (n < 1)
                throw new ArgumentException("Niepoprawna wartość w parametrze metody WylosujNRoznychPunktow. Liczba punktów do wylosowania musi być dodatnia.");

            var zwracanePunkty = new List<Punkt>();
            Random rnd = new Random();
            while (zwracanePunkty.Count < n)
            {
                Punkt punkt = new Punkt()
                {
                    X = rnd.NextDouble() * (20) - 10,
                    Y = rnd.NextDouble() * (20) - 10
                };
                if (!zwracanePunkty.Where(p => p.X.Equals(punkt.X) && p.Y.Equals(punkt.Y)).Any())
                    zwracanePunkty.Add(punkt);
            }
            return zwracanePunkty.ToArray();
        }

        private int[] GetWartosciDlaPunktowIUnipolarnejFunkcjiAktywacji(Punkt[] wejsciowePunkty, double a, double b)
        {
            var zwracaneWartosci = new List<int>();
            foreach (var wejsciowyPunkt in wejsciowePunkty)
            {
                zwracaneWartosci.Add(wejsciowyPunkt.Y > a * wejsciowyPunkt.X + b ? 1 : 0);
            }
            return zwracaneWartosci.ToArray();
        }
    }
}

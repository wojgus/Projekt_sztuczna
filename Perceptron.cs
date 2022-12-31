using System;
using System.Linq;

namespace Perceptron
{
    class Perceptron
    {
        // prawdopodobnie czytelniej będzie działać na listach a nie tablicach

        /// <summary>Liczba punktów w zbiorze uczącym</summary>
        int N { get; set; }
        /// <summary>Współczynnik uczenia</summary>
        double Rho { get; set; }
        double[] Wagi { get; set; }     //w0. w1 i w2
        Punkt[] Punkty { get; set; }    //x1 i x2 n razy
        int[] Wartosci { get; set; }    //d n razy
        double[] Sygnal { get; set; }   //s
        double[] Wyjscia { get; set; }  //y
        //int Epoka { get; set; }         //e
        int Czas { get; set; }          //t

        private void WykonajKrok()
        {
            Czas++; // uwaga: czas starruje od -1
            if (Czas != 0 && Wyjscia[Czas - 1] != Wartosci[Czas - 1])
            {
                //todo: obliczenie nowych wag
            }

            Sygnal = Sygnal.Append(Wagi[0] + Punkty[Czas].X * Wagi[1] + Punkty[Czas].Y * Wagi[2]).ToArray();
            Wyjscia = Wyjscia.Append(Sygnal[Czas] > 0 ? 1 : 0).ToArray();
        }

        private bool Test()
        {
            for (int i = 0; i < N; i++)
                if (Wyjscia[Czas - i] != Wartosci[Czas - i])
                    return false;
            return true;
        }

        private Punkt[] WylosujNRoznychPunktow(int n)
        {
            if (n < 1)
                throw new ArgumentException("Niepoprawna wartość w parametrze metody WylosujNRoznychPunktow. Liczba punktów do wylosowania musi być dodatnia.");

            var zwracanePunkty = new Punkt[n];
            Random rnd = new Random();
            while (zwracanePunkty.Length < n)
            {
                Punkt punkt = new Punkt()
                {
                    X = rnd.NextDouble() * (20) - 10,
                    Y = rnd.NextDouble() * (20) - 10
                };
                if (!zwracanePunkty.Where(p => p.X.Equals(punkt.X) && p.Y.Equals(punkt.Y)).Any())
                    zwracanePunkty.Append(punkt);
            }
            return zwracanePunkty;
        }

        private int[] GetWartosciDlaPunktowIUnipolarnejFunkcjiAktywacji(Punkt[] wejsciowePunkty, double a, double b)
        {
            var zwracaneWartosci = new int[wejsciowePunkty.Length];
            foreach (var wejsciowyPunkt in wejsciowePunkty)
            {
                zwracaneWartosci.Append(wejsciowyPunkt.Y > a * wejsciowyPunkt.X + b ? 1 : 0);
            }
            return zwracaneWartosci;
        }
    }
}

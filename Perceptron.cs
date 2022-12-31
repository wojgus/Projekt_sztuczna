using System;
using System.Collections.Generic;
using System.Linq;

namespace Perceptron
{
    class Perceptron
    {
        /// <summary>Współczynnik uczenia</summary>
        double Rho { get; set; } // może zamienić na decimal?

        private IEnumerable<Punkt> WylosujNRoznychPunktow(int n)
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
            return zwracanePunkty;
        }

        // Zmienić nazwę klasy!
        // Nie wiem czy o to w tym chodzi!
        private IEnumerable<Punkt> GetWartosciDlaUnipolarnejFunkcjiAktywacji(IEnumerable<Punkt> wejsciowePunkty, double a, double b)
        {
            var zwracanePunkty = new List<Punkt>();
            foreach (var wejsciowyPunkt in wejsciowePunkty)
            {
                zwracanePunkty.Add(new Punkt()
                {
                    X = wejsciowyPunkt.X,
                    Y = wejsciowyPunkt.Y > a * wejsciowyPunkt.X + b ? 1 : 0 // O to w tym chodzi?
                });
            }
            return zwracanePunkty;
        }
    }
}

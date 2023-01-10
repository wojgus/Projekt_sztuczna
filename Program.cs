using System;
using System.Collections.Generic;
using System.Linq;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = PobierzCalkowitaDodatniaLiczbeOdUzytkownika("Podaj liczbę badanych punktów:");
            double p = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj początek przedziału dla wylosowania wag:");
            double q = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj koniec przedziału dla wylosowania wag:");
            double a = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj współczynnik kierunkowy funkcji:");
            double b = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj wyraz wolny funkcji:");

            IEnumerable<double> wagi = WylosujWektorWag(p, q);
            var perceptron = new Perceptron(n, wagi, 0.5, a, b);
            perceptron.RozpocznijProcesUczenia();
        }

        private static IEnumerable<double> WylosujWektorWag(double p, double q)
        {
            var zwracaneWagi = new List<double>();
            Random rnd = new Random();
            while (zwracaneWagi.Count < 3)
            {
                //var wylosowanaWaga = rnd.NextDouble() * (p - q) + q;
                //if (!zwracaneWagi.Where(w => w == wylosowanaWaga).Any())
                //zwracaneWagi.Add(wylosowanaWaga);
                zwracaneWagi.Add(rnd.NextDouble() * (p - q) + q);
            }
            return zwracaneWagi;
        }

        private static int PobierzCalkowitaDodatniaLiczbeOdUzytkownika(string wyswietlanyTekst)
        {
            Console.WriteLine(wyswietlanyTekst);
            var liczbaString = Console.ReadLine();
            int liczbaInt;
            while (!int.TryParse(liczbaString, out liczbaInt) || liczbaInt < 1)
            {
                Console.WriteLine("Wprowadzono niepoprawną liczbę. " + wyswietlanyTekst);
                liczbaString = Console.ReadLine();
            }
            return liczbaInt;
        }

        private static double PobierzRzeczywistaLiczbeOdUzytkownika(string wyswietlanyTekst)
        {
            Console.WriteLine(wyswietlanyTekst);
            var liczbaString = Console.ReadLine();
            double liczbaDouble;
            while (!double.TryParse(liczbaString, out liczbaDouble))
            {
                Console.WriteLine("Wprowadzono niepoprawną liczbę. " + wyswietlanyTekst);
                liczbaString = Console.ReadLine();
            }
            return liczbaDouble;
        }
    }
}

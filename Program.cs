using System;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = PobierzCalkowitaDodatniaLiczbeOdUzytkownika("Podaj liczbę badanych punktów:");
            double p = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj początek przedziału dla wylosowania wag:");
            double q = PobierzRzeczywistaLiczbeOdUzytkownika("Podaj koniec przedziału dla wylosowania wag:");


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

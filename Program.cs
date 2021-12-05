using System;
using System.Collections.Generic;

namespace gra_geekon
{
    public class Program
    {
        private static string Imie;
        private static Bohater _bohater;
        public static List<IBron> _bronie;

        static void Main(string[] args)
        {
            StworzBronie();
            ObslugaMenu();

        }
        static void ObslugaMenu()
        {
            Console.WriteLine("1. Nowa gra");
            Console.WriteLine("2. Wczytaj grę");
            Console.WriteLine("3. Koniec");
            Console.Write("Wybierz opcję: ");

            string opcja = Console.ReadLine();
            Console.Clear();

            if (opcja == "1")
            {
                KreatorPostaci();
                MenuGry();

            }

            else if (opcja == "2")
            {
                WczytajGre();
                MenuGry();
            }

            else if (opcja == "3")
            {
                Console.Clear();
                Console.WriteLine("Do zobaczenia!");
                Console.ReadLine();

            }

            else
            {
                Console.WriteLine("Wybierz wartość z zakresu 1-3");

                return;
            }
            Console.ReadLine();
        }

        static void KreatorPostaci()
        {
            Console.WriteLine("Wpisz imię wybranej postaci: ");
            string imie = Console.ReadLine();
            _bohater = new Bohater(imie);
            Console.Clear();
            Console.WriteLine("Twoja postać nazywa się: " + _bohater.Imie);
            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();
        }
        static void StworzBronie()
        {
            Dane dane = new Dane();

            _bronie = dane.WczytajBronie();
            
        }
        static void WczytajGre()
        {
            Console.WriteLine("Wczytuję grę...");
            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();
        }

        static void MenuGry()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("0. Zobacz postać");
            Console.WriteLine("1. Wyrusz na wyprawę");
            Console.WriteLine("2. Odwiedź medyka");
            Console.WriteLine("3. Odwiedź sklep");
            Console.WriteLine("4. Sprawdź rysztunek");
            Console.WriteLine("5. Odpocznij");
            Console.WriteLine("6. Szukaj kanjpy");
            Console.WriteLine("7.Zapisz i zakończ grę");

            Console.WriteLine();

            Console.Write("Wybierz cel " + _bohater.Imie + "!");
            string WyborMenuGlownego = Console.ReadLine();

            while (WyborMenuGlownego != "7")
            {
                if (WyborMenuGlownego == "0")
                {
                    _bohater.PokazPostac();
                    MenuGry();
                }
                else if (WyborMenuGlownego == "1")
                {
                    WyruszNaWyprawe();
                    MenuGry();
                }

                else if (WyborMenuGlownego == "2")
                {
                    OdwiedzMedyka();
                    MenuGry();
                }
                else if (WyborMenuGlownego == "3")
                {
                    OdwiedzSklep();
                    MenuGry();
                }
                else if (WyborMenuGlownego == "4")
                {
                    SprawdzRynsztunek();
                    MenuGry();
                }
                else if (WyborMenuGlownego == "5")
                {
                    _bohater.Odpocznij();
                    MenuGry();
                }
                else if (WyborMenuGlownego == "6")
                {
                    SzukajKnajpy();
                    MenuGry();
                }
                else
                {
                    Console.WriteLine("Zapisano grę, do zobaczenia " + _bohater.Imie + "!");
                    return;
                }
                Console.ReadLine();
            }

        }
        static void WyruszNaWyprawe()
        {
            Console.Clear();
            Console.WriteLine("Zatem w drogę " + _bohater.Imie + " !");

            bool WynikWalki = Walka();
            if (WynikWalki)
            {
                Wygrana();
            }
            else
            {
                _bohater.Przegrana();
            }
        }
        static void OdwiedzMedyka()
        {
            Console.Clear();
            Console.WriteLine("Odzwiedziles medyka, zyskujesz dodatkowy punkt życia.");
            _bohater.PosiadaneZycie++;
            Console.ReadLine();
            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            MenuGry();
        }
        static void OdwiedzSklep()
        {
            Console.Clear();
            Console.WriteLine(" Witaj, " + _bohater.Imie + ".");
            Console.WriteLine("Dostępne towary: ");

            Sklep();

            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();
            MenuGry();
        }

        static void SprawdzRynsztunek()
        {
            Console.Clear();
            Console.WriteLine("Rynsztunek sprawdzony, w drogę " + _bohater.Imie + "!");
            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();
            MenuGry();

        }

        static void SzukajKnajpy()
        {
            Console.Clear();
            Console.WriteLine("Niestety w tym miescie nie ma zadnych knajp... Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();

            MenuGry();

        }

        static bool Walka()
        {
            Random losuj = new Random();
            int obrazenia = _bohater.NoszonaBron.ObliczObrazenia();
            int ZyciePrzeciwnika = losuj.Next(obrazenia - 1 , obrazenia + 3);

            while (_bohater.PosiadaneZycie > 0)
            {
                int ZadaneObrazenia = losuj.Next(2, 5);
                ZyciePrzeciwnika -= ZadaneObrazenia;
                Console.WriteLine("Zadane obrazenia: " + ZadaneObrazenia + ".");
                Console.WriteLine("Twój przeciwnik ma jeszcze " + ZyciePrzeciwnika + " punktów życia.");
                Console.WriteLine("Naciśnij enter, aby kontynuować walkę");
                Console.ReadLine();

                if (ZyciePrzeciwnika <= 1)
                    return true;

                int OtrzymaneObrazenia = losuj.Next(0, 2);
                _bohater.PosiadaneZycie -= OtrzymaneObrazenia;
                Console.WriteLine("Otrzymane Obrazenia: " + OtrzymaneObrazenia);
                Console.WriteLine("Pozostało Ci jeszcze " + _bohater.PosiadaneZycie + " punktów życia.");
                Console.WriteLine("Naciśnij enter, aby kontynuować walkę");
                Console.ReadLine();

                if (ZyciePrzeciwnika == 0)
                    return false;

                if (_bohater.PosiadaneZycie <= 2)
                    Console.WriteLine(_bohater.Imie + ", zostały Ci " + _bohater.PosiadaneZycie + " punkty życia.");
                    Console.WriteLine("Jeśli chcesz ratować się ucieczką wciśnij x");
                    string ucieczka = Console.ReadLine();
                if (ucieczka == "x")
                    Ucieczka();
            }
            return false;
        }

        static void Wygrana()
        {
            Console.WriteLine("Wygrałeś " + _bohater.Imie + "!");
            Console.WriteLine("Od dzisiaj w każdej karczmie będą sławić Twe imię!");
            Console.ReadLine();

            BonusyZaZwyciestwo();
        
        }

        static void BonusyZaZwyciestwo()
        {
            Random losuj = new Random();
            int wygranezloto = losuj.Next(2, 20);
            _bohater.Sakiewka += wygranezloto;
            Console.WriteLine("Otrzymujesz " + wygranezloto + " sztuk złota. Zrób z niego dobry użytek");

            int wygranepd = losuj.Next(10, 40);
            _bohater.PunktyDoswiadczenia += wygranepd;
            Console.WriteLine("Otrzymujesz " + wygranepd + " punktów doświadczenia.");

            Console.ReadLine();

            
        }



        static void Przegrana()
        {
            _bohater.PosiadaneZycie = 1;
            Console.WriteLine("Prezgrana...");
            Console.ReadLine();

        }
        static void Sklep()
        {
            Console.Clear();
            int licznik = 1;

            foreach (IBron bron in _bronie)
            {
                
                Console.WriteLine(licznik + ". " + bron.Nazwa + " Cena: " + bron.Cena + " Obrażenia: " + bron.Obrazenia);
                licznik++;
            }

            //for (int nrBroni = 0; nrBroni < _bronie.Count; nrBroni++)
            //{
            //    Console.WriteLine((nrBroni + 1) + ". " + _bronie[nrBroni].Nazwa);
            //}
            Console.WriteLine("Wybierz broń: ");
            string odczyt = Console.ReadLine();
            int opcja = int.Parse(odczyt);

            IBron WybranaBron = _bronie[opcja - 1];
            _bohater.KupBron(WybranaBron);

        }
        static void Ucieczka()
        {
            Console.WriteLine("Haniebnie uciekłeś z miejsca walki... tracisz 20 sztuk złota i 3 punkty doświadczenia. O opinii nie wspomnę!");
            Console.WriteLine("Ale przynajmniej żyjesz..");
            _bohater.Sakiewka -= 20;
            _bohater.PunktyDoswiadczenia -= 3;
            Console.ReadLine();
        }
    }


}

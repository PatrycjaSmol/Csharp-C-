using System;

namespace gra_geekon
{
    public class Bohater
    {
        public string Imie { get; set; }
        public int MaksymalneZycie { get; set; }
        public int PosiadaneZycie { get; set; }
        public int Obrazenia { get; set; }
        public int Level { get; set; }
        public int PunktyDoswiadczenia { get; set; }
        public int Sakiewka { get; set; }
        public IBron NoszonaBron { get; set; }
        public Bohater(string imie)
        {
            Imie = imie;
            MaksymalneZycie = 200;
            PosiadaneZycie = 100;
            Level = 1;
            PunktyDoswiadczenia = 0;
            Sakiewka = 100;
            //NoszonaBron.Nazwa = JAKA BRON NA START?
        }

        public void PokazPostac()
        {
            Console.WriteLine("Nazwa Postaci: " + Imie);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Punkty życia: " + PosiadaneZycie + "/" + MaksymalneZycie);
            Console.WriteLine("Sakiewka: " +Sakiewka);
            if(NoszonaBron != null)
            {
                Console.WriteLine("Noszona broń: " + NoszonaBron.Nazwa + "/ Obrażenia: " + NoszonaBron.Obrazenia);
            }
            else
            {
                Console.WriteLine("Nie masz narazie żadnej broni, może czas udać się do sklepu?");
            }

            Console.WriteLine("Naciśnij enter, aby wrócić do menu głównego.");
            Console.ReadLine();
        }
        
        public void Przegrana()
        {
            if (PosiadaneZycie <= 0)
                Console.WriteLine("Prezgrana walka!");
            Console.ReadLine();
        }


        public void Odpocznij()
        {
            Console.Clear();
            Console.WriteLine("Dzięki medytacji odzyskałeś 3 punkty życia. Naciśnij enter, aby wrócić do menu głównego.");
            PosiadaneZycie += 3;
            if (MaksymalneZycie < PosiadaneZycie)
                PosiadaneZycie = MaksymalneZycie;
            Console.ReadLine();
        }
        public void KupBron(IBron bron)
        {
            if(bron.Cena <= Sakiewka)
            {
                Console.WriteLine("Twoja nowa broń to: " + bron.Nazwa + ". Zrób z niej dobry użytek!" );
                Sakiewka -= bron.Cena;
                NoszonaBron = bron;

            }

            else
            {
                Console.WriteLine("Masz za mało złota biedaku, wyrusz na wyprawę, aby trochę zarobić!");

            }
            
                
        }
    }
}

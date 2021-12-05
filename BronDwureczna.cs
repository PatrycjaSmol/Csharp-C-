namespace gra_geekon
{
    public class BronDwureczna : IBron

    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Obrazenia { get; set; }

        public BronDwureczna(string nazwa, int cena, int obrazenia)
        {
            Nazwa = nazwa;
            Cena = cena;
            Obrazenia = obrazenia;
        }

        public bool MozliwoscNoszeniaTarczy
        { get
            {
                return false;
            }

        }
        
        public int ObliczObrazenia()
        {
            return Obrazenia * 2;
        }
    }
}

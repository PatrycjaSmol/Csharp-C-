namespace gra_geekon
{
    public class Bron : IBron
    {
       
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Obrazenia { get; set; }
       
    
        public bool MozliwoscNoszeniaTarczy
        { get
            {
                return true;
            }
        }

        public Bron(string nazwa, int cena, int obrazenia)
        {
            Nazwa = nazwa;
            Cena = cena;
            Obrazenia = obrazenia;
        }

        public int ObliczObrazenia()
        {
            return Obrazenia;
        }
        
    }
}

using System.Collections.Generic;
using System.IO;


namespace gra_geekon
{
    public class Dane
    {
        public List<IBron> WczytajBronie()
        {
            var bronie = new List<IBron>();

            using (StreamReader reader = new StreamReader("bronie.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {                                    
                        var odczyt = linia.Split(';');
                        bronie.Add(new Bron(odczyt[0], int.Parse(odczyt[1]), int.Parse(odczyt[2])));
                        linia = reader.ReadLine();                 
                }
            }
            using (StreamReader reader = new StreamReader("bronieDwureczne.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    string[] odczyt = linia.Split(';');
                    bronie.Add(new BronDwureczna(odczyt[0], int.Parse(odczyt[1]), int.Parse(odczyt[2])));
                    linia = reader.ReadLine();
                }
            }

            return bronie;
        }
    }
}

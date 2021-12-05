namespace gra_geekon
{
    public interface IBron
    {
        string Nazwa { get; set; }
        int Cena { get; set; }
        int Obrazenia { get; set; }
        int ObliczObrazenia();
        bool MozliwoscNoszeniaTarczy { get; }
        
    }
}

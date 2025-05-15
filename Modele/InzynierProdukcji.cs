namespace COMPLINEX;

public class InzynierProdukcji : Pracownik
{
    public string Specjalizacja { get; set; }
    public int LiczbaNadzorowychProjektow { get; set; }
        
    public InzynierProdukcji(string imie, string nazwisko, DateTime dataUrodzenia, 
        string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie,
        string specjalizacja, int liczbaNadzorowychProjektow)
        : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie)
    {
        Specjalizacja = specjalizacja;
        LiczbaNadzorowychProjektow = liczbaNadzorowychProjektow;
    }
        
    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Jestem inżynierem produkcji specjalizującym się w {Specjalizacja}.");
    }
        
    public override void OpisObowiazkow()
    {
        Console.WriteLine("Jako inżynier produkcji odpowiadam za nadzór nad procesami produkcyjnymi, " +
                          "optymalizację linii produkcyjnych i kontrolę jakości produktów.");
    }
        
    public override decimal ObliczPremie()
    {
        // Premia zależna od liczby nadzorowanych projektów
        return Wynagrodzenie * 0.1m + (LiczbaNadzorowychProjektow * 500);
    }
}
namespace COMPLINEX;

public class SpecjalistaHR : Pracownik
{
    public int LiczbaZrekrutowanychPracownikow { get; set; }
    public string ObszarSpecjalizacji { get; set; }

    public SpecjalistaHR(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika,
        DateTime dataZatrudnienia, decimal wynagrodzenie, int liczbaZrekrutowanychPracownikow, string obaObszarSpecjalizacji) : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie)
    {
        LiczbaZrekrutowanychPracownikow = liczbaZrekrutowanychPracownikow;
        ObszarSpecjalizacji = obaObszarSpecjalizacji;
    }

    public SpecjalistaHR(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie)
    {
        throw new NotImplementedException();
    }

    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Jestem specjalistą HR specjalizującym się w {ObszarSpecjalizacji}.");
    }
    
    public override void OpisObowiazkow()
    {
        Console.WriteLine("Jako specjalista HR odpowiadam za rekrutację, onboarding nowych pracowników, prowadzenie dokumentacji pracowniczej, organizację szkoleń oraz wsparcie w sprawach związanych z zasobami ludzkimi.");
    }
    
    public override decimal ObliczPremie()
    {
        return Wynagrodzenie * 0.08m + (LiczbaZrekrutowanychPracownikow * 200);
    }
}
namespace COMPLINEX;

public class PrzedstawicielHandlowy : Pracownik
{
    public decimal WartoscSprzedazy { get; set; }
    public double ProcentProwizji { get; set; }
    
    public PrzedstawicielHandlowy(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, decimal wartoscSprzedazy, double procentProwizji) 
        : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie)
    {
        WartoscSprzedazy = wartoscSprzedazy;
        ProcentProwizji = procentProwizji;
    }

    public PrzedstawicielHandlowy(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, decimal wartoscSprzedazy) : base()
    {
        WartoscSprzedazy = wartoscSprzedazy;
        ProcentProwizji = 0.05; // Domyślny procent prowizji
    }

    public override string PodajInformacje()
    {
        throw new NotImplementedException();
    }

    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Jestem przedstawicielem handlowym. Moja wartość sprzedaży to {WartoscSprzedazy:C}");
    }

    public override void OpisObowiazkow()
    {
        Console.WriteLine("Jako przedstawiciel handlowy odpowiadam za pozyskiwanie nowych klientów, utrzymywanie relacji z obecnymi klientami, negocjacje warunków współpracy oraz realizację planów sprzedażowych.");
    }

    public override decimal ObliczPremie()
    {
        return Wynagrodzenie * 0.05m + (WartoscSprzedazy * (decimal)(ProcentProwizji));
    }
}
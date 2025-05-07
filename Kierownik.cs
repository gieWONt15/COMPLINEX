namespace COMPLINEX;

public abstract class Kierownik : Pracownik
{
    public int LiczbaPodwladnych { get; set; }
    public string Dzial { get; set; }
    
    protected Kierownik(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, int liczbaPodwladnych, string dzial) 
        : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie)
    {
        LiczbaPodwladnych = liczbaPodwladnych;
        Dzial = dzial;
    }

    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Jestem kierownikiem działu {Dzial} i zarządzam {LiczbaPodwladnych} pracownikami.");
    }

    public abstract void PrzeprowadzEwaluacjePracownikow();

    public override decimal ObliczPremie()
    {
        return Wynagrodzenie * 0.15m + (LiczbaPodwladnych * 100);
    }
    
    
}
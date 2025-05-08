namespace COMPLINEX;

public class KierownikSprzedazy : Kierownik
{
    public decimal KwartalnyTargetSprzedazy { get; set; }
    public decimal AktualnaSprzedaz { get; set; }
    
    public KierownikSprzedazy(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, int liczbaPodwladnych, string dzial, decimal kwartalnyTargetSprzedazy, decimal aktualnaSprzedaz) : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie, liczbaPodwladnych, dzial)
    {
        KwartalnyTargetSprzedazy = kwartalnyTargetSprzedazy;
        AktualnaSprzedaz = aktualnaSprzedaz;
    }

    public override void OpisObowiazkow()
    {
        Console.WriteLine("Jako kierownik sprzedaży odpowiadam za realizację celów sprzedażowych, zarządzanie zespołem przedstawicieli handlowych, opracowywanie strategii sprzedaży, analizę rynku oraz raportowanie wyników sprzedażowych.");
    }

    public override void PrzeprowadzEwaluacjePracownikow()
    {
        Console.WriteLine("Przeprowadzam miesięczną ewaluację przedstawicieli handlowych na podstawie realizacji indywidualnych targetów sprzedażowych, pozyskiwania nowych klientów oraz utrzymywania relacji z obecnymi.");
    }

    public override decimal ObliczPremie()
    {
        // Premia zależy od stopnia realizacji targetu sprzedażowego
        decimal stopienRealizacji = AktualnaSprzedaz / KwartalnyTargetSprzedazy;
            
        if (stopienRealizacji >= 1.0m)
        {
            // Przekroczenie targetu
            return Wynagrodzenie * 0.2m + (stopienRealizacji - 1.0m) * KwartalnyTargetSprzedazy * 0.05m;
        }
        else
        {
            // Częściowa realizacja targetu
            return Wynagrodzenie * 0.1m * stopienRealizacji;
        }
    }
}
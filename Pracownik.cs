using System.Reflection.Metadata;

namespace COMPLINEX;

public abstract class Pracownik : Osoba
{
    public string NumerPracownika { get; set; }
    public DateTime DataZatrudnienia { get; set; }
    public decimal Wynagrodzenie { get; set; }
    
    //Konstruktor
    protected Pracownik(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie) : base(imie, nazwisko, dataUrodzenia)
    {
        NumerPracownika = numerPracownika;
        DataZatrudnienia = dataZatrudnienia;
        Wynagrodzenie = wynagrodzenie;
    }

    protected Pracownik() : base(imie: "Nieznany", nazwisko: "Nieznany", dataUrodzenia: DateTime.Now)
    {
        throw new NotImplementedException();
    }

    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Jestem pracownikiem firmy od {DataZatrudnienia.ToShortDateString()}, mój numer pracownika to {NumerPracownika}.");
    }

    public abstract void OpisObowiazkow();

    public virtual decimal ObliczPremie()
    {
        return Wynagrodzenie * 0.1m;
    }

    public override string PodajInformacje()
    {
        return $"{Imie} {Nazwisko}, Nr: {NumerPracownika}, Zatrudniony: {DataZatrudnienia.ToShortDateString()}";
    }
}
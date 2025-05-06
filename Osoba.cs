namespace COMPLINEX;

public abstract class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public DateTime DataUrodzenia { get; set; }

    protected Osoba(string imie, string nazwisko, DateTime dataUrodzenia)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        DataUrodzenia = dataUrodzenia;
    }

    public virtual void PrzedstawSie()
    {
        Console.WriteLine($"Nazywam się {Imie} {Nazwisko}.");
    }
}
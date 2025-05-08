namespace COMPLINEX;

public class KierownikProdukcji : Kierownik
{
    public double WskaznikEfektywnosciProdukcji { get; set; }
    
    public KierownikProdukcji(string imie, string nazwisko, DateTime dataUrodzenia, string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, int liczbaPodwladnych, string dzial, double wskaznikEfektywnosciProdukcji) : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie, liczbaPodwladnych, dzial)
    {
        WskaznikEfektywnosciProdukcji = wskaznikEfektywnosciProdukcji;
    }

    public override void OpisObowiazkow()
    {
        Console.WriteLine($"\"Jako kierownik produkcji odpowiadam za planowanie produkcji zarządzanie zespołem produkcyjnym, optymalizację procesów, kontrolę jakości oraz zapewnienie ciągłości produkcji.");
    }

    public override void PrzeprowadzEwaluacjePracownikow()
    {
        Console.WriteLine("Przeprowadzam kwartalną ewaluację pracowników produkcji na podstawie wskaźników efektywności, jakości pracy oraz dyscypliny.");
    }

    public override decimal ObliczPremie()
    {
        decimal premia = base.ObliczPremie();
        return premia * (decimal)(WskaznikEfektywnosciProdukcji / 100);
    }
}
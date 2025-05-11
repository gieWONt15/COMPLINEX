namespace COMPLINEX;

// Rozszerzenie klasy KierownikProdukcji o implementację IKierownikProjektu
public class KierownikProdukcjiProjektu : KierownikProdukcji, IKierownikProjektu
{
    public int LiczbaProjektow { get; set; }
    
    public KierownikProdukcjiProjektu(string imie, string nazwisko, DateTime dataUrodzenia, 
        string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, 
        int liczbaPodwladnych, string dzial, double wskaznikEfektywnosciProdukcji, int liczbaProjektow) 
        : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie, 
            liczbaPodwladnych, dzial, wskaznikEfektywnosciProdukcji)
    {
        LiczbaProjektow = liczbaProjektow;
    }
    
    public void ZarzadzajProjektem()
    {
        Console.WriteLine($"Kierownik produkcji {Imie} {Nazwisko} zarządza projektem, przydzielając zadania i nadzorując postęp prac.");
    }
    
    public void PrzeprowadzEwaluacjeProjektu()
    {
        Console.WriteLine($"Kierownik produkcji {Imie} {Nazwisko} przeprowadza ewaluację efektywności projektu i jakości wykonania.");
    }
    
    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Zarządzam również {LiczbaProjektow} projektami wewnętrznymi.");
    }
    
    public override decimal ObliczPremie()
    {
        // Dodatkowa premia za zarządzanie projektami
        return base.ObliczPremie() + (LiczbaProjektow * 1000);
    }
}
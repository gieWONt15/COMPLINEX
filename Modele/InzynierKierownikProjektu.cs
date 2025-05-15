namespace COMPLINEX;

public class InzynierKierownikProjektu : InzynierProdukcji, IKierownikProjektu
{
    public int LiczbaProjektow { get; set; }
    
    public InzynierKierownikProjektu(string imie, string nazwisko, DateTime dataUrodzenia, 
        string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie,
        string specjalizacja, int liczbaNadzorowychProjektow, int liczbaProjektow)
        : base(imie, nazwisko, dataUrodzenia, numerPracownika, dataZatrudnienia, wynagrodzenie,
            specjalizacja, liczbaNadzorowychProjektow)
    {
        LiczbaProjektow = liczbaProjektow;
    }
    
    public void ZarzadzajProjektem()
    {
        Console.WriteLine($"Inżynier {Imie} {Nazwisko} zarządza projektem, nadzorując jego realizację techniczną.");
    }
    
    public void PrzeprowadzEwaluacjeProjektu()
    {
        Console.WriteLine($"Inżynier {Imie} {Nazwisko} przeprowadza ewaluację projektu pod względem technicznym.");
    }
    
    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        Console.WriteLine($"Dodatkowo pełnię funkcję kierownika {LiczbaProjektow} projektów.");
    }
    
    public override decimal ObliczPremie()
    {
        // Dodatkowa premia za zarządzanie projektami
        return base.ObliczPremie() + (LiczbaProjektow * 800);
    }
}
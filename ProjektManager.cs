namespace COMPLINEX;

public interface IKierownikProjektu
{
    void ZarzadzajProjektem();
    void PrzeprowadzEwaluacjeProjektu();
}

public class Projekt
{
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime DataRozpoczecia { get; set; }
    public DateTime? DataZakonczenia { get; set; }
    public IKierownikProjektu Kierownik { get; private set; }
    public List<Pracownik> Zespol { get; private set; }
    public bool CzyAktywny => DataZakonczenia == null || DataZakonczenia > DateTime.Now;
    
    public Projekt(string nazwa, string opis, DateTime dataRozpoczecia, DateTime? dataZakonczenia = null)
    {
        Nazwa = nazwa;
        Opis = opis;
        DataRozpoczecia = dataRozpoczecia;
        DataZakonczenia = dataZakonczenia;
        Zespol = new List<Pracownik>();
    }
    
    public void UstawKierownika(IKierownikProjektu kierownik)
    {
        Kierownik = kierownik;
        Console.WriteLine($"Ustawiono kierownika projektu '{Nazwa}'.");
    }
    
    public void DodajCzlonkaZespolu(Pracownik pracownik)
    {
        if (!Zespol.Contains(pracownik))
        {
            Zespol.Add(pracownik);
            Console.WriteLine($"Dodano {pracownik.Imie} {pracownik.Nazwisko} do zespołu projektu '{Nazwa}'.");
        }
        else
        {
            Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko} już jest członkiem zespołu projektu '{Nazwa}'.");
        }
    }
    
    public void UsunCzlonkaZespolu(Pracownik pracownik)
    {
        if (Zespol.Contains(pracownik))
        {
            Zespol.Remove(pracownik);
            Console.WriteLine($"Usunięto {pracownik.Imie} {pracownik.Nazwisko} z zespołu projektu '{Nazwa}'.");
        }
        else
        {
            Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko} nie jest członkiem zespołu projektu '{Nazwa}'.");
        }
    }
    
    public void WyswietlInformacjeOProjekcie()
    {
        Console.WriteLine($"\n=== PROJEKT: {Nazwa} ===");
        Console.WriteLine($"Opis: {Opis}");
        Console.WriteLine($"Data rozpoczęcia: {DataRozpoczecia.ToShortDateString()}");
        Console.WriteLine($"Data zakończenia: {(DataZakonczenia.HasValue ? DataZakonczenia.Value.ToShortDateString() : "W trakcie")}");
        Console.WriteLine($"Status: {(CzyAktywny ? "Aktywny" : "Zakończony")}");
        
        if (Kierownik != null)
        {
            var kierownikJakoPracownik = Kierownik as Pracownik;
            if (kierownikJakoPracownik != null)
            {
                Console.WriteLine($"Kierownik projektu: {kierownikJakoPracownik.Imie} {kierownikJakoPracownik.Nazwisko}");
            }
        }
        else
        {
            Console.WriteLine("Projekt nie ma przypisanego kierownika.");
        }
        
        Console.WriteLine("\nCzłonkowie zespołu:");
        if (Zespol.Count == 0)
        {
            Console.WriteLine("Brak członków zespołu.");
        }
        else
        {
            foreach (var pracownik in Zespol)
            {
                Console.WriteLine($"- {pracownik.Imie} {pracownik.Nazwisko} ({pracownik.GetType().Name})");
            }
        }
    }
}
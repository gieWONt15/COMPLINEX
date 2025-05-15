namespace COMPLINEX;

/// <summary>
/// Ocena dla inżyniera kierownika projektu
/// </summary>
public class OcenaInzynieraKierownikaProjektu : OcenaPracownika
{
    /// <summary>
    /// Ocena efektywności pracy (1-5)
    /// </summary>
    public int EfektywnoscPracy { get; set; }
    
    /// <summary>
    /// Ocena zarządzania projektami (1-5)
    /// </summary>
    public int ZarzadzanieProjektami { get; set; }
    
    /// <summary>
    /// Ocena umiejętności technicznych (1-5)
    /// </summary>
    public int UmiejetnosciTechniczne { get; set; }
    
    /// <summary>
    /// Ocena zarządzania zespołem (1-5)
    /// </summary>
    public int ZarzadzanieZespolem { get; set; }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaInzynieraKierownikaProjektu
    /// </summary>
    public OcenaInzynieraKierownikaProjektu(InzynierKierownikProjektu pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int efektywnoscPracy, int zarzadzanieProjektami, 
        int umiejetnosciTechniczne, int zarzadzanieZespolem)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        EfektywnoscPracy = WalidujOcene(efektywnoscPracy);
        ZarzadzanieProjektami = WalidujOcene(zarzadzanieProjektami);
        UmiejetnosciTechniczne = WalidujOcene(umiejetnosciTechniczne);
        ZarzadzanieZespolem = WalidujOcene(zarzadzanieZespolem);
        ObliczOcene();
    }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaInzynieraKierownikaProjektu na podstawie danych z bazy
    /// </summary>
    public OcenaInzynieraKierownikaProjektu(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria,
        int efektywnoscPracy, int zarzadzanieProjektami, int umiejetnosciTechniczne, int zarzadzanieZespolem)
        : base(id, idPracownika, idOceniajacegoHR, dataWystawienia, rok, komentarz, ocenaOgolna, status, kategoria)
    {
        EfektywnoscPracy = efektywnoscPracy;
        ZarzadzanieProjektami = zarzadzanieProjektami;
        UmiejetnosciTechniczne = umiejetnosciTechniczne;
        ZarzadzanieZespolem = zarzadzanieZespolem;
    }
    
    /// <summary>
    /// Waliduje ocenę, aby była w zakresie 1-5
    /// </summary>
    private int WalidujOcene(int ocena) => Math.Clamp(ocena, 1, 5);
    
    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów dla inżyniera kierownika projektu
    /// </summary>
    public override void ObliczOcene()
    {
        // Dla inżyniera kierownika projektu ważne są zarówno umiejętności techniczne jak i zarządcze
        double ocena = (EfektywnoscPracy * 0.2) + 
                       (ZarzadzanieProjektami * 0.3) + 
                       (UmiejetnosciTechniczne * 0.25) + 
                       (ZarzadzanieZespolem * 0.25);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    /// <summary>
    /// Wyświetla szczegóły oceny inżyniera kierownika projektu
    /// </summary>
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        Console.WriteLine("\nSzczegóły oceny inżyniera kierownika projektu:");
        
        var inzynierKierownik = Pracownik as InzynierKierownikProjektu;
        if (inzynierKierownik != null)
        {
            Console.WriteLine($"Specjalizacja: {inzynierKierownik.Specjalizacja}");
            Console.WriteLine($"Liczba nadzorowanych projektów: {inzynierKierownik.LiczbaNadzorowychProjektow}");
            Console.WriteLine($"Liczba projektów: {inzynierKierownik.LiczbaProjektow}");
        }
            
        Console.WriteLine($"Efektywność pracy: {EfektywnoscPracy}/5");
        Console.WriteLine($"Zarządzanie projektami: {ZarzadzanieProjektami}/5");
        Console.WriteLine($"Umiejętności techniczne: {UmiejetnosciTechniczne}/5");
        Console.WriteLine($"Zarządzanie zespołem: {ZarzadzanieZespolem}/5");
    }
}
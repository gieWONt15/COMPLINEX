namespace COMPLINEX;

/// <summary>
/// Ocena dla specjalisty HR
/// </summary>
public class OcenaSpecjalistyHR : OcenaPracownika
{
    /// <summary>
    /// Ocena efektywności rekrutacji (1-5)
    /// </summary>
    public int EfektywnoscRekrutacji { get; set; }
    
    /// <summary>
    /// Ocena jakości szkoleń (1-5)
    /// </summary>
    public int JakoscSzkolen { get; set; }
    
    /// <summary>
    /// Ocena dokumentacji (1-5)
    /// </summary>
    public int Dokumentacja { get; set; }
    
    /// <summary>
    /// Ocena współpracy z zespołem (1-5)
    /// </summary>
    public int WspolpracaZZespolem { get; set; }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaSpecjalistyHR
    /// </summary>
    public OcenaSpecjalistyHR(SpecjalistaHR pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int efektywnoscRekrutacji, int jakoscSzkolen, 
        int dokumentacja, int wspolpracaZZespolem)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        EfektywnoscRekrutacji = WalidujOcene(efektywnoscRekrutacji);
        JakoscSzkolen = WalidujOcene(jakoscSzkolen);
        Dokumentacja = WalidujOcene(dokumentacja);
        WspolpracaZZespolem = WalidujOcene(wspolpracaZZespolem);
        ObliczOcene();
    }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaSpecjalistyHR na podstawie danych z bazy
    /// </summary>
    public OcenaSpecjalistyHR(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria,
        int efektywnoscRekrutacji, int jakoscSzkolen, int dokumentacja, int wspolpracaZZespolem)
        : base(id, idPracownika, idOceniajacegoHR, dataWystawienia, rok, komentarz, ocenaOgolna, status, kategoria)
    {
        EfektywnoscRekrutacji = efektywnoscRekrutacji;
        JakoscSzkolen = jakoscSzkolen;
        Dokumentacja = dokumentacja;
        WspolpracaZZespolem = wspolpracaZZespolem;
    }
    
    /// <summary>
    /// Waliduje ocenę, aby była w zakresie 1-5
    /// </summary>
    private int WalidujOcene(int ocena) => Math.Clamp(ocena, 1, 5);
    
    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów dla specjalisty HR
    /// </summary>
    public override void ObliczOcene()
    {
        // Ocena ważona - różne aspekty mają różne wagi
        double ocena = (EfektywnoscRekrutacji * 0.3) + 
                       (JakoscSzkolen * 0.25) + 
                       (Dokumentacja * 0.2) + 
                       (WspolpracaZZespolem * 0.25);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    /// <summary>
    /// Wyświetla szczegóły oceny specjalisty HR
    /// </summary>
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        Console.WriteLine("\nSzczegóły oceny specjalisty HR:");
        Console.WriteLine($"Efektywność rekrutacji: {EfektywnoscRekrutacji}/5");
        Console.WriteLine($"Jakość szkoleń: {JakoscSzkolen}/5");
        Console.WriteLine($"Dokumentacja: {Dokumentacja}/5");
        Console.WriteLine($"Współpraca z zespołem: {WspolpracaZZespolem}/5");
    }
}
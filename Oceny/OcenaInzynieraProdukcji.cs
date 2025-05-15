namespace COMPLINEX;

/// <summary>
/// Ocena dla inżyniera produkcji
/// </summary>
public class OcenaInzynieraProdukcji : OcenaPracownika
{
    /// <summary>
    /// Ocena efektywności (1-5)
    /// </summary>
    public int OcenaEfektywnosci { get; set; }
    
    /// <summary>
    /// Ocena innowacyjności (1-5)
    /// </summary>
    public int OcenaInnowacyjnosci { get; set; }
    
    /// <summary>
    /// Ocena jakości pracy (1-5)
    /// </summary>
    public int OcenaJakosciPracy { get; set; }
    
    /// <summary>
    /// Ocena realizacji projektów (1-5)
    /// </summary>
    public int OcenaRealizacjiProjektow { get; set; }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaInzynieraProdukcji
    /// </summary>
    /// <param name="pracownik">Inżynier, którego dotyczy ocena</param>
    /// <param name="rok">Rok oceny</param>
    /// <param name="oceniajacyHR">Specjalista HR dokonujący oceny</param>
    /// <param name="komentarz">Komentarz do oceny</param>
    /// <param name="ocenaEfektywnosci">Ocena efektywności (1-5)</param>
    /// <param name="ocenaInnowacyjnosci">Ocena innowacyjności (1-5)</param>
    /// <param name="ocenaJakosciPracy">Ocena jakości pracy (1-5)</param>
    /// <param name="ocenaRealizacjiProjektow">Ocena realizacji projektów (1-5)</param>
    public OcenaInzynieraProdukcji(InzynierProdukcji pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaEfektywnosci, int ocenaInnowacyjnosci, 
        int ocenaJakosciPracy, int ocenaRealizacjiProjektow)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaEfektywnosci = WalidujOcene(ocenaEfektywnosci);
        OcenaInnowacyjnosci = WalidujOcene(ocenaInnowacyjnosci);
        OcenaJakosciPracy = WalidujOcene(ocenaJakosciPracy);
        OcenaRealizacjiProjektow = WalidujOcene(ocenaRealizacjiProjektow);
        ObliczOcene();
    }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaInzynieraProdukcji na podstawie danych z bazy
    /// </summary>
    public OcenaInzynieraProdukcji(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria,
        int ocenaEfektywnosci, int ocenaInnowacyjnosci, int ocenaJakosciPracy, int ocenaRealizacjiProjektow)
        : base(id, idPracownika, idOceniajacegoHR, dataWystawienia, rok, komentarz, ocenaOgolna, status, kategoria)
    {
        OcenaEfektywnosci = ocenaEfektywnosci;
        OcenaInnowacyjnosci = ocenaInnowacyjnosci;
        OcenaJakosciPracy = ocenaJakosciPracy;
        OcenaRealizacjiProjektow = ocenaRealizacjiProjektow;
    }
    
    /// <summary>
    /// Waliduje ocenę, aby była w zakresie 1-5
    /// </summary>
    private int WalidujOcene(int ocena) => Math.Clamp(ocena, 1, 5);
    
    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów dla inżyniera
    /// </summary>
    public override void ObliczOcene()
    {
        // Ocena ważona - różne aspekty mają różne wagi
        double ocena = (OcenaEfektywnosci * 0.25) + 
                       (OcenaInnowacyjnosci * 0.2) + 
                       (OcenaJakosciPracy * 0.3) + 
                       (OcenaRealizacjiProjektow * 0.25);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    /// <summary>
    /// Wyświetla szczegóły oceny inżyniera produkcji
    /// </summary>
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        Console.WriteLine("\nSzczegóły oceny inżyniera produkcji:");
        
        var inzynier = Pracownik as InzynierProdukcji;
        if (inzynier != null)
            Console.WriteLine($"Specjalizacja: {inzynier.Specjalizacja}");
            
        Console.WriteLine($"Efektywność: {OcenaEfektywnosci}/5");
        Console.WriteLine($"Innowacyjność: {OcenaInnowacyjnosci}/5");
        Console.WriteLine($"Jakość pracy: {OcenaJakosciPracy}/5");
        Console.WriteLine($"Realizacja projektów: {OcenaRealizacjiProjektow}/5");
    }
}
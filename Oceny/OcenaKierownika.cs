namespace COMPLINEX;

/// <summary>
/// Ocena dla kierownika
/// </summary>
public class OcenaKierownika : OcenaPracownika
{
    /// <summary>
    /// Ocena zarządzania zespołem (1-5)
    /// </summary>
    public int ZarzadzanieZespolem { get; set; }

    /// <summary>
    /// Ocena realizacji celów (1-5)
    /// </summary>
    public int RealizacjaCelow { get; set; }

    /// <summary>
    /// Ocena umiejętności organizacyjnych (1-5)
    /// </summary>
    public int UmiejetnosciOrganizacyjne { get; set; }

    /// <summary>
    /// Ocena innowacyjności (1-5)
    /// </summary>
    public int Innowacyjnosc { get; set; }

    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaKierownika
    /// </summary>
    public OcenaKierownika(Kierownik pracownik, int rok, SpecjalistaHR oceniajacyHR,
        string komentarz, int zarzadzanieZespolem, int realizacjaCelow,
        int umiejetnosciOrganizacyjne, int innowacyjnosc)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        ZarzadzanieZespolem = WalidujOcene(zarzadzanieZespolem);
        RealizacjaCelow = WalidujOcene(realizacjaCelow);
        UmiejetnosciOrganizacyjne = WalidujOcene(umiejetnosciOrganizacyjne);
        Innowacyjnosc = WalidujOcene(innowacyjnosc);
        ObliczOcene();
    }

    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaKierownika na podstawie danych z bazy
    /// </summary>
    public OcenaKierownika(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria,
        int zarzadzanieZespolem, int realizacjaCelow, int umiejetnosciOrganizacyjne, int innowacyjnosc)
        : base(id, idPracownika, idOceniajacegoHR, dataWystawienia, rok, komentarz, ocenaOgolna, status, kategoria)
    {
        ZarzadzanieZespolem = zarzadzanieZespolem;
        RealizacjaCelow = realizacjaCelow;
        UmiejetnosciOrganizacyjne = umiejetnosciOrganizacyjne;
        Innowacyjnosc = innowacyjnosc;
    }

    /// <summary>
    /// Waliduje ocenę, aby była w zakresie 1-5
    /// </summary>
    private int WalidujOcene(int ocena) => Math.Clamp(ocena, 1, 5);

    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów dla kierownika
    /// </summary>
    public override void ObliczOcene()
    {
        // Ocena ważona - różne aspekty mają różne wagi
        double ocena = (ZarzadzanieZespolem * 0.4) +
                       (RealizacjaCelow * 0.3) +
                       (UmiejetnosciOrganizacyjne * 0.2) +
                       (Innowacyjnosc * 0.1);

        OcenaOgolna = (int)Math.Round(ocena);
    }

    /// <summary>
    /// Wyświetla szczegóły oceny kierownika
    /// </summary>
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();

        Console.WriteLine("\nSzczegóły oceny kierownika:");
        Console.WriteLine($"Zarządzanie zespołem: {ZarzadzanieZespolem}/5");
        Console.WriteLine($"Realizacja celów: {RealizacjaCelow}/5");
        Console.WriteLine($"Umiejętności organizacyjne: {UmiejetnosciOrganizacyjne}/5");
        Console.WriteLine($"Innowacyjność: {Innowacyjnosc}/5");
    }
}
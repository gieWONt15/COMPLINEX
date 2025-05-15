namespace COMPLINEX;

/// <summary>
/// Ocena dla przedstawiciela handlowego
/// </summary>
public class OcenaPrzedstawicielaHandlowego : OcenaPracownika
{
    /// <summary>
    /// Ocena realizacji celów sprzedażowych (1-5)
    /// </summary>
    public int RealizacjaCelowSprzedazowych { get; set; }

    /// <summary>
    /// Ocena pozyskiwania klientów (1-5)
    /// </summary>
    public int PozyskiwanieKlientow { get; set; }

    /// <summary>
    /// Ocena obsługi klienta (1-5)
    /// </summary>
    public int ObslugaKlienta { get; set; }

    /// <summary>
    /// Ocena umiejętności negocjacyjnych (1-5)
    /// </summary>
    public int UmiejetnosciNegocjacyjne { get; set; }

    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaPrzedstawicielaHandlowego
    /// </summary>
    public OcenaPrzedstawicielaHandlowego(PrzedstawicielHandlowy pracownik, int rok, SpecjalistaHR oceniajacyHR,
        string komentarz, int realizacjaCelowSprzedazowych, int pozyskiwanieKlientow,
        int obslugaKlienta, int umiejetnosciNegocjacyjne)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        RealizacjaCelowSprzedazowych = WalidujOcene(realizacjaCelowSprzedazowych);
        PozyskiwanieKlientow = WalidujOcene(pozyskiwanieKlientow);
        ObslugaKlienta = WalidujOcene(obslugaKlienta);
        UmiejetnosciNegocjacyjne = WalidujOcene(umiejetnosciNegocjacyjne);
        ObliczOcene();
    }

    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaPrzedstawicielaHandlowego na podstawie danych z bazy
    /// </summary>
    public OcenaPrzedstawicielaHandlowego(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria,
        int realizacjaCelowSprzedazowych, int pozyskiwanieKlientow, int obslugaKlienta, int umiejetnosciNegocjacyjne)
        : base(id, idPracownika, idOceniajacegoHR, dataWystawienia, rok, komentarz, ocenaOgolna, status, kategoria)
    {
        RealizacjaCelowSprzedazowych = realizacjaCelowSprzedazowych;
        PozyskiwanieKlientow = pozyskiwanieKlientow;
        ObslugaKlienta = obslugaKlienta;
        UmiejetnosciNegocjacyjne = umiejetnosciNegocjacyjne;
    }

    /// <summary>
    /// Waliduje ocenę, aby była w zakresie 1-5
    /// </summary>
    private int WalidujOcene(int ocena) => Math.Clamp(ocena, 1, 5);

    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów dla przedstawiciela handlowego
    /// </summary>
    public override void ObliczOcene()
    {
        // Ocena ważona - różne aspekty mają różne wagi
        double ocena = (RealizacjaCelowSprzedazowych * 0.4) +
                       (PozyskiwanieKlientow * 0.3) +
                       (ObslugaKlienta * 0.2) +
                       (UmiejetnosciNegocjacyjne * 0.1);

        OcenaOgolna = (int)Math.Round(ocena);
    }

    /// <summary>
    /// Wyświetla szczegóły oceny przedstawiciela handlowego
    /// </summary>
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();

        Console.WriteLine("\nSzczegóły oceny przedstawiciela handlowego:");
        Console.WriteLine($"Realizacja celów sprzedażowych: {RealizacjaCelowSprzedazowych}/5");
        Console.WriteLine($"Pozyskiwanie klientów: {PozyskiwanieKlientow}/5");
        Console.WriteLine($"Obsługa klienta: {ObslugaKlienta}/5");
        Console.WriteLine($"Umiejętności negocjacyjne: {UmiejetnosciNegocjacyjne}/5");
    }
}
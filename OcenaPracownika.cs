namespace COMPLINEX;

/// <summary>
/// Abstrakcyjna klasa reprezentująca ocenę pracownika
/// </summary>
public abstract class OcenaPracownika
{
    /// <summary>
    /// Identyfikator oceny
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Identyfikator pracownika, którego dotyczy ocena
    /// </summary>
    public string IdPracownika { get; protected set; }
    
    /// <summary>
    /// Referencja do pracownika (nie przechowywana w bazie)
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public Pracownik Pracownik { get; private set; }
    
    /// <summary>
    /// Identyfikator osoby dokonującej oceny (specjalisty HR)
    /// </summary>
    public string IdOceniajacegoHR { get; protected set; }
    
    /// <summary>
    /// Referencja do oceniającego HR (nie przechowywana w bazie)
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public SpecjalistaHR OceniajacyHR { get; private set; }
    
    /// <summary>
    /// Data wystawienia oceny
    /// </summary>
    public DateTime DataWystawienia { get; set; }
    
    /// <summary>
    /// Rok, którego dotyczy ocena
    /// </summary>
    public int Rok { get; protected set; }
    
    /// <summary>
    /// Komentarz dodany do oceny
    /// </summary>
    public string Komentarz { get; set; }
    
    /// <summary>
    /// Ocena końcowa (w skali 1-5)
    /// </summary>
    public int OcenaOgolna { get; set; }
    
    /// <summary>
    /// Status oceny (np. wersja robocza, zatwierdzona, odrzucona)
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// Kategoria/dział, do którego należy pracownik
    /// </summary>
    public string Kategoria { get; set; }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaPracownika
    /// </summary>
    /// <param name="pracownik">Pracownik, którego dotyczy ocena</param>
    /// <param name="rok">Rok, którego dotyczy ocena</param>
    /// <param name="oceniajacyHR">Specjalista HR dokonujący oceny</param>
    /// <param name="komentarz">Komentarz do oceny</param>
    protected OcenaPracownika(Pracownik pracownik, int rok, SpecjalistaHR oceniajacyHR, string komentarz)
    {
        Pracownik = pracownik;
        IdPracownika = pracownik.NumerPracownika;
        OceniajacyHR = oceniajacyHR;
        IdOceniajacegoHR = oceniajacyHR.NumerPracownika;
        Rok = rok;
        Komentarz = komentarz;
        DataWystawienia = DateTime.Now;
        Status = "Wersja robocza";
        OkreslKategorie();
    }
    
    /// <summary>
    /// Inicjalizuje nową instancję klasy OcenaPracownika na podstawie danych z bazy
    /// </summary>
    /// <param name="id">Identyfikator oceny</param>
    /// <param name="idPracownika">Identyfikator pracownika</param>
    /// <param name="idOceniajacegoHR">Identyfikator oceniającego HR</param>
    /// <param name="dataWystawienia">Data wystawienia oceny</param>
    /// <param name="rok">Rok oceny</param>
    /// <param name="komentarz">Komentarz do oceny</param>
    /// <param name="ocenaOgolna">Ocena ogólna</param>
    /// <param name="status">Status oceny</param>
    /// <param name="kategoria">Kategoria pracownika</param>
    protected OcenaPracownika(int id, string idPracownika, string idOceniajacegoHR, DateTime dataWystawienia,
        int rok, string komentarz, int ocenaOgolna, string status, string kategoria)
    {
        Id = id;
        IdPracownika = idPracownika;
        IdOceniajacegoHR = idOceniajacegoHR;
        DataWystawienia = dataWystawienia;
        Rok = rok;
        Komentarz = komentarz;
        OcenaOgolna = ocenaOgolna;
        Status = status;
        Kategoria = kategoria;
    }
    
    /// <summary>
    /// Określa kategorię pracownika na podstawie jego typu
    /// </summary>
    protected virtual void OkreslKategorie()
    {
        if (Pracownik is InzynierProdukcji)
            Kategoria = "Produkcja";
        else if (Pracownik is PrzedstawicielHandlowy)
            Kategoria = "Sprzedaż";
        else if (Pracownik is Kierownik kierownik)
            Kategoria = $"Kierownictwo - {kierownik.Dzial}";
        else if (Pracownik is SpecjalistaHR)
            Kategoria = "HR";
        else
            Kategoria = "Inna";
    }
    
    /// <summary>
    /// Ustawia referencje do obiektów (pracownik, oceniający HR) po załadowaniu z bazy
    /// </summary>
    /// <param name="pracownik">Pracownik, którego dotyczy ocena</param>
    /// <param name="oceniajacyHR">Specjalista HR dokonujący oceny</param>
    public void UstawReferencje(Pracownik pracownik, SpecjalistaHR oceniajacyHR)
    {
        Pracownik = pracownik;
        OceniajacyHR = oceniajacyHR;
    }
    
    /// <summary>
    /// Oblicza ocenę końcową na podstawie kryteriów
    /// </summary>
    public abstract void ObliczOcene();
    
    /// <summary>
    /// Zatwierdza ocenę
    /// </summary>
    public virtual void ZatwierdzOcene()
    {
        Status = "Zatwierdzona";
    }
    
    /// <summary>
    /// Odrzuca ocenę
    /// </summary>
    /// <param name="powod">Powód odrzucenia oceny</param>
    public virtual void OdrzucOcene(string powod)
    {
        Status = "Odrzucona";
        Komentarz += $"\nOdrzucono: {powod}";
    }
    
    /// <summary>
    /// Wyświetla szczegóły oceny pracownika
    /// </summary>
    public virtual void WyswietlOcene()
    {
        Console.WriteLine($"\n=== OCENA ZA ROK {Rok} ===");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Data wystawienia: {DataWystawienia.ToShortDateString()}");
        
        string informacjePracownika;
        if (Pracownik != null)
            informacjePracownika = $"{Pracownik.Imie} {Pracownik.Nazwisko} (ID: {IdPracownika})";
        else
            informacjePracownika = $"ID Pracownika: {IdPracownika}";
        
        string informacjeHR;
        if (OceniajacyHR != null)
            informacjeHR = $"{OceniajacyHR.Imie} {OceniajacyHR.Nazwisko}";
        else
            informacjeHR = $"ID HR: {IdOceniajacegoHR}";
        
        Console.WriteLine($"Pracownik: {informacjePracownika}");
        Console.WriteLine($"Oceniający HR: {informacjeHR}");
        Console.WriteLine($"Ocena ogólna: {OcenaOgolna}/5");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Kategoria: {Kategoria}");
        Console.WriteLine($"Komentarz: {Komentarz}");
    }
    
    /// <summary>
    /// Eksportuje ocenę do formatu JSON
    /// </summary>
    /// <returns>Reprezentacja oceny w formacie JSON</returns>
    public string EksportujDoJSON()
    {
        return System.Text.Json.JsonSerializer.Serialize(this, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
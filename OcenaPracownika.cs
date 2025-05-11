namespace COMPLINEX;

// Klasa bazowa reprezentująca ocenę pracownika
public abstract class OcenaPracownika
{
    public Pracownik Pracownik { get; private set; }
    public int Rok { get; private set; }
    public DateTime DataWystawienia { get; private set; }
    public SpecjalistaHR OceniajacyHR { get; private set; }
    public string Komentarz { get; set; }
    
    // Ocena w skali 1-5
    public int OcenaOgolna { get; protected set; }
    
    protected OcenaPracownika(Pracownik pracownik, int rok, SpecjalistaHR oceniajacyHR, string komentarz)
    {
        Pracownik = pracownik;
        Rok = rok;
        DataWystawienia = DateTime.Now;
        OceniajacyHR = oceniajacyHR;
        Komentarz = komentarz;
    }
    
    // Metoda abstrakcyjna do obliczania oceny - każdy typ pracownika będzie miał własny algorytm
    public abstract void ObliczOcene();
    
    // Metoda wyświetlająca szczegóły oceny
    public virtual void WyswietlOcene()
    {
        Console.WriteLine($"\n=== OCENA ROCZNA ZA ROK {Rok} ===");
        Console.WriteLine($"Pracownik: {Pracownik.Imie} {Pracownik.Nazwisko} (ID: {Pracownik.NumerPracownika})");
        Console.WriteLine($"Data wystawienia: {DataWystawienia.ToShortDateString()}");
        Console.WriteLine($"Oceniający HR: {OceniajacyHR.Imie} {OceniajacyHR.Nazwisko}");
        Console.WriteLine($"Ocena ogólna: {OcenaOgolna}/5");
        Console.WriteLine($"Komentarz: {Komentarz}");
    }
}

// Ocena dla inżyniera produkcji
public class OcenaInzynieraProdukcji : OcenaPracownika
{
    public int OcenaEfektywnosci { get; set; }          // 1-5
    public int OcenaInnowacyjnosci { get; set; }        // 1-5
    public int OcenaJakosciPracy { get; set; }          // 1-5
    public int OcenaRealizacjiProjektow { get; set; }   // 1-5
    
    public OcenaInzynieraProdukcji(InzynierProdukcji pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaEfektywnosci, int ocenaInnowacyjnosci, 
        int ocenaJakosciPracy, int ocenaRealizacjiProjektow)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaEfektywnosci = ocenaEfektywnosci;
        OcenaInnowacyjnosci = ocenaInnowacyjnosci;
        OcenaJakosciPracy = ocenaJakosciPracy;
        OcenaRealizacjiProjektow = ocenaRealizacjiProjektow;
        ObliczOcene();
    }
    
    public override void ObliczOcene()
    {
        // Ocena ważona - różne aspekty mają różne wagi
        double ocena = (OcenaEfektywnosci * 0.25) + 
                       (OcenaInnowacyjnosci * 0.2) + 
                       (OcenaJakosciPracy * 0.3) + 
                       (OcenaRealizacjiProjektow * 0.25);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        var inzynier = (InzynierProdukcji)Pracownik;
        Console.WriteLine("\nSzczegóły oceny inżyniera produkcji:");
        Console.WriteLine($"Specjalizacja: {inzynier.Specjalizacja}");
        Console.WriteLine($"Efektywność: {OcenaEfektywnosci}/5");
        Console.WriteLine($"Innowacyjność: {OcenaInnowacyjnosci}/5");
        Console.WriteLine($"Jakość pracy: {OcenaJakosciPracy}/5");
        Console.WriteLine($"Realizacja projektów: {OcenaRealizacjiProjektow}/5");
    }
}

// Ocena dla przedstawiciela handlowego
public class OcenaPrzedstawicielaHandlowego : OcenaPracownika
{
    public int OcenaRealizacjiCelowSprzedazowych { get; set; }    // 1-5
    public int OcenaPozyskiwaniaKlientow { get; set; }           // 1-5
    public int OcenaObslugiKlienta { get; set; }                 // 1-5
    public int OcenaUmiejetnosciNegocjacyjnych { get; set; }     // 1-5
    
    public OcenaPrzedstawicielaHandlowego(PrzedstawicielHandlowy pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaRealizacjiCelowSprzedazowych, int ocenaPozyskiwaniaKlientow, 
        int ocenaObslugiKlienta, int ocenaUmiejetnosciNegocjacyjnych)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaRealizacjiCelowSprzedazowych = ocenaRealizacjiCelowSprzedazowych;
        OcenaPozyskiwaniaKlientow = ocenaPozyskiwaniaKlientow;
        OcenaObslugiKlienta = ocenaObslugiKlienta;
        OcenaUmiejetnosciNegocjacyjnych = ocenaUmiejetnosciNegocjacyjnych;
        ObliczOcene();
    }
    
    public override void ObliczOcene()
    {
        // Dla handlowców najważniejsza jest realizacja celów sprzedażowych
        double ocena = (OcenaRealizacjiCelowSprzedazowych * 0.4) + 
                       (OcenaPozyskiwaniaKlientow * 0.25) + 
                       (OcenaObslugiKlienta * 0.2) + 
                       (OcenaUmiejetnosciNegocjacyjnych * 0.15);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        var handlowiec = (PrzedstawicielHandlowy)Pracownik;
        Console.WriteLine("\nSzczegóły oceny przedstawiciela handlowego:");
        Console.WriteLine($"Wartość sprzedaży: {handlowiec.WartoscSprzedazy:C}");
        Console.WriteLine($"Realizacja celów sprzedażowych: {OcenaRealizacjiCelowSprzedazowych}/5");
        Console.WriteLine($"Pozyskiwanie klientów: {OcenaPozyskiwaniaKlientow}/5");
        Console.WriteLine($"Obsługa klienta: {OcenaObslugiKlienta}/5");
        Console.WriteLine($"Umiejętności negocjacyjne: {OcenaUmiejetnosciNegocjacyjnych}/5");
    }
}

// Ocena dla specjalisty HR
public class OcenaSpecjalistyHR : OcenaPracownika
{
    public int OcenaEfektywnosciRekrutacji { get; set; }    // 1-5
    public int OcenaJakosciSzkolen { get; set; }           // 1-5
    public int OcenaDokumentacji { get; set; }             // 1-5
    public int OcenaWspolpracyZZespolem { get; set; }      // 1-5
    
    public OcenaSpecjalistyHR(SpecjalistaHR pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaEfektywnosciRekrutacji, int ocenaJakosciSzkolen, 
        int ocenaDokumentacji, int ocenaWspolpracyZZespolem)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaEfektywnosciRekrutacji = ocenaEfektywnosciRekrutacji;
        OcenaJakosciSzkolen = ocenaJakosciSzkolen;
        OcenaDokumentacji = ocenaDokumentacji;
        OcenaWspolpracyZZespolem = ocenaWspolpracyZZespolem;
        ObliczOcene();
    }
    
    public override void ObliczOcene()
    {
        // Dla HR ważna jest rekrutacja i dokumentacja
        double ocena = (OcenaEfektywnosciRekrutacji * 0.35) + 
                       (OcenaJakosciSzkolen * 0.2) + 
                       (OcenaDokumentacji * 0.3) + 
                       (OcenaWspolpracyZZespolem * 0.15);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        var hr = (SpecjalistaHR)Pracownik;
        Console.WriteLine("\nSzczegóły oceny specjalisty HR:");
        Console.WriteLine($"Obszar specjalizacji: {hr.ObszarSpecjalizacji}");
        Console.WriteLine($"Efektywność rekrutacji: {OcenaEfektywnosciRekrutacji}/5");
        Console.WriteLine($"Jakość szkoleń: {OcenaJakosciSzkolen}/5");
        Console.WriteLine($"Prowadzenie dokumentacji: {OcenaDokumentacji}/5");
        Console.WriteLine($"Współpraca z zespołem: {OcenaWspolpracyZZespolem}/5");
    }
}

// Ocena dla kierownika
public class OcenaKierownika : OcenaPracownika
{
    public int OcenaZarzadzaniaZespolem { get; set; }         // 1-5
    public int OcenaRealizacjiCelow { get; set; }             // 1-5
    public int OcenaUmiejetnosciPrzywodczych { get; set; }    // 1-5
    public int OcenaZarzadzaniaKryzysowego { get; set; }      // 1-5
    
    public OcenaKierownika(Kierownik pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaZarzadzaniaZespolem, int ocenaRealizacjiCelow, 
        int ocenaUmiejetnosciPrzywodczych, int ocenaZarzadzaniaKryzysowego)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaZarzadzaniaZespolem = ocenaZarzadzaniaZespolem;
        OcenaRealizacjiCelow = ocenaRealizacjiCelow;
        OcenaUmiejetnosciPrzywodczych = ocenaUmiejetnosciPrzywodczych;
        OcenaZarzadzaniaKryzysowego = ocenaZarzadzaniaKryzysowego;
        ObliczOcene();
    }
    
    public override void ObliczOcene()
    {
        // Dla kierownika ważne są umiejętności przywódcze i zarządzanie zespołem
        double ocena = (OcenaZarzadzaniaZespolem * 0.3) + 
                       (OcenaRealizacjiCelow * 0.25) + 
                       (OcenaUmiejetnosciPrzywodczych * 0.3) + 
                       (OcenaZarzadzaniaKryzysowego * 0.15);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        var kierownik = (Kierownik)Pracownik;
        Console.WriteLine("\nSzczegóły oceny kierownika:");
        Console.WriteLine($"Dział: {kierownik.Dzial}");
        Console.WriteLine($"Liczba podwładnych: {kierownik.LiczbaPodwladnych}");
        Console.WriteLine($"Zarządzanie zespołem: {OcenaZarzadzaniaZespolem}/5");
        Console.WriteLine($"Realizacja celów działu: {OcenaRealizacjiCelow}/5");
        Console.WriteLine($"Umiejętności przywódcze: {OcenaUmiejetnosciPrzywodczych}/5");
        Console.WriteLine($"Zarządzanie kryzysowe: {OcenaZarzadzaniaKryzysowego}/5");
    }
}

// Specjalna ocena dla inżyniera pełniącego rolę kierownika projektu
public class OcenaInzynieraKierownikaProjektu : OcenaPracownika
{
    public int OcenaEfektywnosciPracy { get; set; }           // 1-5
    public int OcenaZarzadzaniaProjektami { get; set; }       // 1-5
    public int OcenaUmiejetnosciTechnicznych { get; set; }    // 1-5
    public int OcenaZarzadzaniaZespolem { get; set; }         // 1-5
    
    public OcenaInzynieraKierownikaProjektu(InzynierKierownikProjektu pracownik, int rok, SpecjalistaHR oceniajacyHR, 
        string komentarz, int ocenaEfektywnosciPracy, int ocenaZarzadzaniaProjektami, 
        int ocenaUmiejetnosciTechnicznych, int ocenaZarzadzaniaZespolem)
        : base(pracownik, rok, oceniajacyHR, komentarz)
    {
        OcenaEfektywnosciPracy = ocenaEfektywnosciPracy;
        OcenaZarzadzaniaProjektami = ocenaZarzadzaniaProjektami;
        OcenaUmiejetnosciTechnicznych = ocenaUmiejetnosciTechnicznych;
        OcenaZarzadzaniaZespolem = ocenaZarzadzaniaZespolem;
        ObliczOcene();
    }
    
    public override void ObliczOcene()
    {
        // Hybrydowa ocena dla inżyniera kierownika projektu
        double ocena = (OcenaEfektywnosciPracy * 0.2) + 
                       (OcenaZarzadzaniaProjektami * 0.35) + 
                       (OcenaUmiejetnosciTechnicznych * 0.2) + 
                       (OcenaZarzadzaniaZespolem * 0.25);
        
        OcenaOgolna = (int)Math.Round(ocena);
    }
    
    public override void WyswietlOcene()
    {
        base.WyswietlOcene();
        
        var inzynierKierownik = (InzynierKierownikProjektu)Pracownik;
        Console.WriteLine("\nSzczegóły oceny inżyniera kierownika projektu:");
        Console.WriteLine($"Specjalizacja: {inzynierKierownik.Specjalizacja}");
        Console.WriteLine($"Liczba zarządzanych projektów: {inzynierKierownik.LiczbaProjektow}");
        Console.WriteLine($"Efektywność pracy: {OcenaEfektywnosciPracy}/5");
        Console.WriteLine($"Zarządzanie projektami: {OcenaZarzadzaniaProjektami}/5");
        Console.WriteLine($"Umiejętności techniczne: {OcenaUmiejetnosciTechnicznych}/5");
        Console.WriteLine($"Zarządzanie zespołem: {OcenaZarzadzaniaZespolem}/5");
    }
}
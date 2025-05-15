namespace COMPLINEX;

// Przykład użycia w Program.cs
class Program
{
    static void Main()
    {
        // Tworzenie pracowników
        var inzynier = new InzynierProdukcji(
            "Jan", "Kowalski", new DateTime(1980, 5, 15),
            "INZ001", new DateTime(2010, 6, 1), 8000m,
            "automatyzacja procesów", 3);
            
        var inzynierKierownik = new InzynierKierownikProjektu(
            "Tomasz", "Wiśniewski", new DateTime(1978, 11, 5),
            "INZ003", new DateTime(2008, 4, 10), 9500m,
            "optymalizacja produkcji", 4, 2);
            
        var handlowiec = new PrzedstawicielHandlowy(
            "Piotr", "Zieliński", new DateTime(1988, 9, 25),
            "PH001", new DateTime(2017, 2, 1), 6000m,
            150000m, 0.02);
            
        var kierownik = new KierownikProdukcji(
            "Maria", "Dąbrowska", new DateTime(1975, 3, 18),
            "KP001", new DateTime(2005, 7, 1), 12000m,
            12, "Produkcja", 110.5);
            
        var specjalistaHr = new SpecjalistaHR(
            "Katarzyna", "Lewandowska", new DateTime(1990, 7, 12),
            "HR001", new DateTime(2018, 9, 1), 6500m,
            15, "rekrutacja i onboarding");
            
        // Tworzenie systemu ocen
        var systemOcen = new SystemOcenPracowniczych();
        
        // Tworzenie ocen dla różnych typów pracowników
        
        // Ocena dla inżyniera
        var ocenaSzczegolowaInzyniera = new Dictionary<string, int>
        {
            {"Efektywnosc", 4},
            {"Innowacyjnosc", 5},
            {"JakoscPracy", 4},
            {"RealizacjaProjektow", 3}
        };
        
        var ocenaInzyniera = FabrykaOcen.UtworzOcene(
            inzynier, 2023, specjalistaHr, 
            "Wybitny specjalista, wprowadził kilka innowacyjnych rozwiązań w procesie produkcji.",
            ocenaSzczegolowaInzyniera);
            
        // Ocena dla inżyniera kierownika projektu
        var ocenaSzczegolowaInzynieraKierownika = new Dictionary<string, int>
        {
            {"EfektywnoscPracy", 4},
            {"ZarzadzanieProjektami", 5},
            {"UmiejetnosciTechniczne", 4},
            {"ZarzadzanieZespolem", 4}
        };
        
        var ocenaInzynieraKierownika = FabrykaOcen.UtworzOcene(
            inzynierKierownik, 2023, specjalistaHr, 
            "Skutecznie łączy umiejętności techniczne z zarządzaniem zespołem. Projekty realizowane terminowo.",
            ocenaSzczegolowaInzynieraKierownika);
            
        // Ocena dla handlowca
        var ocenaSzczegolowaHandlowca = new Dictionary<string, int>
        {
            {"RealizacjaCelowSprzedazowych", 5},
            {"PozyskiwanieKlientow", 4},
            {"ObslugaKlienta", 3},
            {"UmiejetnosciNegocjacyjne", 5}
        };
        
        var ocenaHandlowca = FabrykaOcen.UtworzOcene(
            handlowiec, 2023, specjalistaHr, 
            "Przekroczył cele sprzedażowe o 15%. Bardzo dobre umiejętności negocjacyjne.",
            ocenaSzczegolowaHandlowca);
            
        // Ocena dla kierownika
        var ocenaSzczegolowaKierownika = new Dictionary<string, int>
        {
            {"ZarzadzanieZespolem", 4},
            {"RealizacjaCelow", 5},
            {"UmiejetnosciPrzywodcze", 4},
            {"ZarzadzanieKryzysowe", 3}
        };
        
        var ocenaKierownika = FabrykaOcen.UtworzOcene(
            kierownik, 2023, specjalistaHr, 
            "Efektywnie zarządza zespołem, terminowo realizuje cele produkcyjne. Wysoka kultura osobista.",
            ocenaSzczegolowaKierownika);
            
        // Ocena dla specjalisty HR
        var ocenaSzczegolowaSpecjalistyHr = new Dictionary<string, int>
        {
            {"EfektywnoscRekrutacji", 5},
            {"JakoscSzkolen", 4},
            {"Dokumentacja", 4},
            {"WspolpracaZZespolem", 5}
        };
        
        var ocenaSpecjalistyHr = FabrykaOcen.UtworzOcene(
            specjalistaHr, 2023, specjalistaHr, 
            "Doskonała skuteczność w rekrutacji i onboardingu nowych pracowników. Bardzo dobre relacje z pracownikami.",
            ocenaSzczegolowaSpecjalistyHr);
            
        // Dodawanie ocen do systemu ocen
        systemOcen.DodajOcene(ocenaInzyniera);
        systemOcen.DodajOcene(ocenaInzynieraKierownika);
        systemOcen.DodajOcene(ocenaHandlowca);
        systemOcen.DodajOcene(ocenaKierownika);
        systemOcen.DodajOcene(ocenaSpecjalistyHr);
        
        // Wyświetlanie ocen
        systemOcen.WyswietlWszystkieOceny();
    }
}
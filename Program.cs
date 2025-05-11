namespace COMPLINEX;

class Program
{
    static void Main()
    {
        // Tworzenie rejestru pracowników
        var rejestrPracownikow = new RejestrPracownikow();
        
        // Tworzenie pracowników różnych typów
        var inzynier1 = new InzynierProdukcji(
            "Jan", "Kowalski", new DateTime(1980, 5, 15),
            "INZ001", new DateTime(2010, 6, 1), 8000m,
            "automatyzacja procesów", 3);
            
        var inzynier2 = new InzynierProdukcji(
            "Anna", "Nowak", new DateTime(1985, 8, 20),
            "INZ002", new DateTime(2015, 3, 15), 7500m,
            "kontrola jakości", 2);
            
        var inzynierKierownik = new InzynierKierownikProjektu(
            "Tomasz", "Wiśniewski", new DateTime(1978, 11, 5),
            "INZ003", new DateTime(2008, 4, 10), 9500m,
            "optymalizacja produkcji", 4, 2);
            
        var kierownikProdukcji = new KierownikProdukcjiProjektu(
            "Maria", "Dąbrowska", new DateTime(1975, 3, 18),
            "KP001", new DateTime(2005, 7, 1), 12000m,
            12, "Produkcja", 110.5, 3);
            
        var handlowiec = new PrzedstawicielHandlowy(
            "Piotr", "Zieliński", new DateTime(1988, 9, 25),
            "PH001", new DateTime(2017, 2, 1), 6000m,
            150000m, 0.02);
            
        var specjalistaHr = new SpecjalistaHR(
            "Katarzyna", "Lewandowska", new DateTime(1990, 7, 12),
            "HR001", new DateTime(2018, 9, 1), 6500m,
            15, "rekrutacja i onboarding");
            
        // Dodawanie pracowników do rejestru
        rejestrPracownikow.DodajPracownika(inzynier1);
        rejestrPracownikow.DodajPracownika(inzynier2);
        rejestrPracownikow.DodajPracownika(inzynierKierownik);
        rejestrPracownikow.DodajPracownika(kierownikProdukcji);
        rejestrPracownikow.DodajPracownika(handlowiec);
        rejestrPracownikow.DodajPracownika(specjalistaHr);
        
        // Tworzenie rejestru projektów
        var rejestrProjektow = new RejestrProjektow();
        
        // Tworzenie projektów
        var projektA = new Projekt(
            "Optymalizacja linii produkcyjnej A", 
            "Projekt mający na celu zwiększenie efektywności linii produkcyjnej A o 20%",
            new DateTime(2023, 1, 15),
            new DateTime(2023, 6, 30));
            
        var projektB = new Projekt(
            "Wdrożenie systemu kontroli jakości", 
            "Implementacja nowego systemu kontroli jakości zgodnego z ISO 9001:2015",
            new DateTime(2023, 4, 1));
            
        // Ustawienie kierowników projektów
        projektA.UstawKierownika(kierownikProdukcji);
        projektB.UstawKierownika(inzynierKierownik);
        
        // Dodawanie członków zespołu
        projektA.DodajCzlonkaZespolu(inzynier1);
        projektA.DodajCzlonkaZespolu(handlowiec);
        
        projektB.DodajCzlonkaZespolu(inzynier2);
        projektB.DodajCzlonkaZespolu(specjalistaHr);
        
        // Dodawanie projektów do rejestru
        rejestrProjektow.DodajProjekt(projektA);
        rejestrProjektow.DodajProjekt(projektB);
        
        // Wyświetlanie informacji o projektach
        rejestrProjektow.WyswietlWszystkieProjekty();
        rejestrProjektow.WyswietlSzczegolyProjektow(rejestrProjektow.PobierzWszystkieProjekty());
        
        // Demonstracja funkcji kierownika projektu
        Console.WriteLine("\n=== DEMONSTRACJA FUNKCJI KIEROWNIKA PROJEKTU ===");
        kierownikProdukcji.ZarzadzajProjektem();
        kierownikProdukcji.PrzeprowadzEwaluacjeProjektu();
        
        inzynierKierownik.ZarzadzajProjektem();
        inzynierKierownik.PrzeprowadzEwaluacjeProjektu();
    }
}
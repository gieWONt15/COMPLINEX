namespace COMPLINEX;

// Klasa zarządzająca ocenami pracowników
public class SystemOcenPracowniczych
{
    private List<OcenaPracownika> oceny;
    
    public SystemOcenPracowniczych()
    {
        oceny = new List<OcenaPracownika>();
    }
    
    // Dodaj nową ocenę
    public void DodajOcene(OcenaPracownika ocena)
    {
        oceny.Add(ocena);
        Console.WriteLine($"Dodano ocenę roczną dla pracownika {ocena.Pracownik.Imie} {ocena.Pracownik.Nazwisko} za rok {ocena.Rok}");
    }
    
    // Znajdź wszystkie oceny dla danego pracownika
    public List<OcenaPracownika> ZnajdzOcenyPracownika(Pracownik pracownik)
    {
        return oceny.Where(o => o.Pracownik.NumerPracownika == pracownik.NumerPracownika).ToList();
    }
    
    // Znajdź ocenę pracownika za dany rok
    public OcenaPracownika ZnajdzOceneRoczna(Pracownik pracownik, int rok)
    {
        return oceny.FirstOrDefault(o => 
            o.Pracownik.NumerPracownika == pracownik.NumerPracownika && o.Rok == rok);
    }
    
    // Znajdź oceny pracowników według działu
    public List<OcenaPracownika> ZnajdzOcenyPracownikowDzialu(string dzial)
    {
        return oceny.Where(o => 
        {
            if (o.Pracownik is Kierownik kierownik)
            {
                return kierownik.Dzial.Equals(dzial, StringComparison.OrdinalIgnoreCase);
            }
            // Dla pozostałych typów pracowników można dodać logikę przypisania do działu
            return false;
        }).ToList();
    }
    
    // Wyświetl statystyki ocen za dany rok
    public void WyswietlStatystykiRoczne(int rok)
    {
        var ocenyRoku = oceny.Where(o => o.Rok == rok).ToList();
        
        if (ocenyRoku.Count == 0)
        {
            Console.WriteLine($"Brak ocen za rok {rok}");
            return;
        }
        
        Console.WriteLine($"\n=== STATYSTYKI OCEN ZA ROK {rok} ===");
        Console.WriteLine($"Liczba ocenionych pracowników: {ocenyRoku.Count}");
        Console.WriteLine($"Średnia ocena: {ocenyRoku.Average(o => o.OcenaOgolna):F2}");
        
        var ocenyPoTypach = ocenyRoku.GroupBy(o => o.Pracownik.GetType().Name)
            .Select(g => new { Typ = g.Key, Srednia = g.Average(o => o.OcenaOgolna) });
        
        Console.WriteLine("\nŚrednie oceny według typów pracowników:");
        foreach (var grupa in ocenyPoTypach)
        {
            Console.WriteLine($"- {grupa.Typ}: {grupa.Srednia:F2}");
        }
    }
    
    // Generuj raport z ocenami za dany rok
    public void GenerujRaportRoczny(int rok)
    {
        var ocenyRoku = oceny.Where(o => o.Rok == rok).ToList();
        
        if (ocenyRoku.Count == 0)
        {
            Console.WriteLine($"Brak ocen za rok {rok}");
            return;
        }
        
        Console.WriteLine($"\n=== RAPORT OCEN PRACOWNIKÓW ZA ROK {rok} ===");
        
        // Grupowanie ocen według typów pracowników
        var grupyPracownikow = ocenyRoku.GroupBy(o => o.Pracownik.GetType().Name);
        
        foreach (var grupa in grupyPracownikow)
        {
            Console.WriteLine($"\n== Typ pracownika: {grupa.Key} ==");
            
            foreach (var ocena in grupa.OrderByDescending(o => o.OcenaOgolna))
            {
                Console.WriteLine($"- {ocena.Pracownik.Imie} {ocena.Pracownik.Nazwisko}: {ocena.OcenaOgolna}/5");
            }
        }
    }
    
    // Wyświetl wszystkie oceny
    public void WyswietlWszystkieOceny()
    {
        if (oceny.Count == 0)
        {
            Console.WriteLine("Brak ocen w systemie");
            return;
        }
        
        foreach (var ocena in oceny.OrderBy(o => o.Rok).ThenBy(o => o.Pracownik.Nazwisko))
        {
            ocena.WyswietlOcene();
            Console.WriteLine();
        }
    }
}
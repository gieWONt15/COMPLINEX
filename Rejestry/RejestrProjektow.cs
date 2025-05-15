namespace COMPLINEX;

public class RejestrProjektow
{
    private List<Projekt> projekty;
    
    public RejestrProjektow()
    {
        projekty = new List<Projekt>();
    }
    
    public void DodajProjekt(Projekt projekt)
    {
        projekty.Add(projekt);
        Console.WriteLine($"Dodano projekt: {projekt.Nazwa}");
    }
    
    public void UsunProjekt(Projekt projekt)
    {
        if (projekty.Contains(projekt))
        {
            projekty.Remove(projekt);
            Console.WriteLine($"Usunięto projekt: {projekt.Nazwa}");
        }
        else
        {
            Console.WriteLine($"Projekt {projekt.Nazwa} nie istnieje w rejestrze.");
        }
    }
    
    public List<Projekt> PobierzWszystkieProjekty()
    {
        return projekty.ToList();
    }
    
    public List<Projekt> PobierzAktywneProjekty()
    {
        return projekty.Where(p => p.CzyAktywny).ToList();
    }
    
    public List<Projekt> PobierzZakonczonyProjekty()
    {
        return projekty.Where(p => !p.CzyAktywny).ToList();
    }
    
    public List<Projekt> WyszukajProjektyPoNazwie(string fragment)
    {
        return projekty.Where(p => p.Nazwa.Contains(fragment, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public List<Projekt> WyszukajProjektyPracownika(Pracownik pracownik)
    {
        return projekty.Where(p => p.Zespol.Contains(pracownik) || 
                                  (p.Kierownik as Pracownik)?.NumerPracownika == pracownik.NumerPracownika)
                      .ToList();
    }
    
    public void WyswietlWszystkieProjekty()
    {
        if (projekty.Count == 0)
        {
            Console.WriteLine("Brak projektów w rejestrze.");
            return;
        }
        
        Console.WriteLine("\n=== WSZYSTKIE PROJEKTY ===");
        foreach (var projekt in projekty)
        {
            Console.WriteLine($"- {projekt.Nazwa} ({(projekt.CzyAktywny ? "Aktywny" : "Zakończony")})");
        }
    }
    
    public void WyswietlSzczegolyProjektow(List<Projekt> listaProjektow)
    {
        if (listaProjektow.Count == 0)
        {
            Console.WriteLine("Brak projektów do wyświetlenia.");
            return;
        }
        
        foreach (var projekt in listaProjektow)
        {
            projekt.WyswietlInformacjeOProjekcie();
        }
    }
    
    public int LiczbaProjektow => projekty.Count;
    public int LiczbaAktywnychProjektow => projekty.Count(p => p.CzyAktywny);
}
namespace COMPLINEX;

class Program
{
    public static void Main()
    {
        // Tworzenie przykładowych obiektów
        InzynierProdukcji inzynier = new InzynierProdukcji(
            "Jan", "Kowalski", new DateTime(1985, 5, 15),
            "IP001", new DateTime(2018, 3, 1), 7000m,
            "automatyzacja linii produkcyjnych", 3
        );
            
        PrzedstawicielHandlowy handlowiec = new PrzedstawicielHandlowy(
            "Anna", "Nowak", new DateTime(1990, 8, 22),
            "PH007", new DateTime(2019, 4, 15), 5000m,
            120000m, 0.03
        );
            
        KierownikProdukcji kierownikP = new KierownikProdukcji("Marek", "Wiśniewski",
            new DateTime(1978, 11, 7), "KP002",
            new DateTime(2019, 1, 1), 12000m, 15,
            "Produkcja", 95
        );
            
        // Przykładowe wywołania metod
        Console.WriteLine("=== Inżynier Produkcji ===");
        inzynier.PrzedstawSie();
        inzynier.OpisObowiazkow();
        Console.WriteLine($"Premia: {inzynier.ObliczPremie():C}");
        Console.WriteLine();
            
        Console.WriteLine("=== Przedstawiciel Handlowy ===");
        handlowiec.PrzedstawSie();
        handlowiec.OpisObowiazkow();
        Console.WriteLine($"Premia: {handlowiec.ObliczPremie():C}");
        Console.WriteLine();
            
        Console.WriteLine("=== Kierownik Produkcji ===");
        kierownikP.PrzedstawSie();
        kierownikP.OpisObowiazkow();
        kierownikP.PrzeprowadzEwaluacjePracownikow();
        Console.WriteLine($"Premia: {kierownikP.ObliczPremie():C}");
    }
}
namespace COMPLINEX;

public class RejestrPracownikow
    {
        private List<Pracownik> pracownicy;
        
        public RejestrPracownikow()
        {
            pracownicy = new List<Pracownik>();
        }
        
        // Dodawanie pracownika do rejestru (polimorfizm - przyjmuje każdy typ dziedziczący po Pracownik)
        public void DodajPracownika(Pracownik pracownik)
        {
            pracownicy.Add(pracownik);
            Console.WriteLine($"Dodano pracownika: {pracownik.Imie} {pracownik.Nazwisko} (ID: {pracownik.NumerPracownika})");
        }
        
        // Wyświetlanie wszystkich pracowników
        public void WyswietlWszystkichPracownikow()
        {
            if (pracownicy.Count == 0)
            {
                Console.WriteLine("Rejestr pracowników jest pusty.");
                return;
            }
            
            Console.WriteLine("\n=== WSZYSCY PRACOWNICY ===");
            foreach (var pracownik in pracownicy)
            {
                Console.WriteLine(pracownik.PodajInformacje());
            }
        }
        
        // Filtrowanie po nazwisku (dokładne dopasowanie)
        public List<Pracownik> FiltrujPoNazwisku(string nazwisko)
        {
            var wynik = pracownicy.Where(p => p.Nazwisko.Equals(nazwisko, StringComparison.OrdinalIgnoreCase)).ToList();
            return wynik;
        }
        
        // Filtrowanie po nazwisku (zawieranie ciągu znaków)
        public List<Pracownik> WyszukajPoFragmencieNazwiska(string fragment)
        {
            var wynik = pracownicy.Where(p => p.Nazwisko.Contains(fragment, StringComparison.OrdinalIgnoreCase)).ToList();
            return wynik;
        }
        
        // Filtrowanie po typie pracownika (wykorzystuje polimorfizm)
        public List<T> FiltrujPoTypie<T>() where T : Pracownik
        {
            return pracownicy.OfType<T>().ToList();
        }
        
        // Filtrowanie po dziale (dla kierowników)
        public List<Kierownik> FiltrujKierownikowPoDziale(string dzial)
        {
            var wynik = pracownicy.OfType<Kierownik>()
                                 .Where(k => k.Dzial.Equals(dzial, StringComparison.OrdinalIgnoreCase))
                                 .ToList();
            return wynik;
        }
        
        // Filtrowanie inżynierów po specjalizacji
        public List<InzynierProdukcji> FiltrujInzynierowPoSpecjalizacji(string specjalizacja)
        {
            var wynik = pracownicy.OfType<InzynierProdukcji>()
                                 .Where(i => i.Specjalizacja.Contains(specjalizacja, StringComparison.OrdinalIgnoreCase))
                                 .ToList();
            return wynik;
        }
        
        // Filtrowanie specjalistów HR po obszarze specjalizacji
        public List<SpecjalistaHR> FiltrujHRPoObszarze(string obszar)
        {
            var wynik = pracownicy.OfType<SpecjalistaHR>()
                                 .Where(hr => hr.ObszarSpecjalizacji.Contains(obszar, StringComparison.OrdinalIgnoreCase))
                                 .ToList();
            return wynik;
        }
        
        // Wyszukiwanie pracowników, których wynagrodzenie mieści się w podanym zakresie
        public List<Pracownik> FiltrujPoWynagrodzeniu(decimal minWynagrodzenie, decimal maxWynagrodzenie)
        {
            var wynik = pracownicy.Where(p => p.Wynagrodzenie >= minWynagrodzenie && 
                                           p.Wynagrodzenie <= maxWynagrodzenie)
                                 .ToList();
            return wynik;
        }
        
        // Filtrowanie po stażu pracy (w latach)
        public List<Pracownik> FiltrujPoStazuPracy(int minLatStazu)
        {
            DateTime granicznaData = DateTime.Now.AddYears(-minLatStazu);
            var wynik = pracownicy.Where(p => p.DataZatrudnienia <= granicznaData).ToList();
            return wynik;
        }
        
        // Uniwersalny filtr z wykorzystaniem predykatu (najbardziej elastyczna metoda filtrowania)
        public List<Pracownik> FiltrujNiestandardowo(Func<Pracownik, bool> predykat)
        {
            return pracownicy.Where(predykat).ToList();
        }
        
        // Wyświetlanie wyników wyszukiwania
        public void WyswietlWyniki(List<Pracownik> wyniki, string tytul)
        {
            Console.WriteLine($"\n=== {tytul} ===");
            if (wyniki.Count == 0)
            {
                Console.WriteLine("Brak wyników spełniających kryteria.");
                return;
            }
            
            foreach (var pracownik in wyniki)
            {
                Console.WriteLine(pracownik.PodajInformacje());
            }
        }
        
        // Pobranie średniego wynagrodzenia dla danego typu pracownika
        public decimal ObliczSrednieWynagrodzenie<T>() where T : Pracownik
        {
            var filtrowaniPracownicy = pracownicy.OfType<T>();
            if (!filtrowaniPracownicy.Any())
                return 0;
                
            return filtrowaniPracownicy.Average(p => p.Wynagrodzenie);
        }
        
        // Pobranie liczby pracowników w rejestrze
        public int LiczbaPracownikow
        {
            get { return pracownicy.Count; }
        }
    }

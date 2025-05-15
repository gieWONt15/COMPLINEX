namespace COMPLINEX;

// Fabryka ocen pracowniczych
public class FabrykaOcen
{
    // Metoda tworząca odpowiednią ocenę na podstawie typu pracownika
    public static OcenaPracownika UtworzOcene(Pracownik pracownik, int rok, SpecjalistaHR oceniajacyHR, string komentarz, Dictionary<string, int> ocenySzczegolowe)
    {
        if (pracownik is InzynierKierownikProjektu inzynierKierownik)
        {
            return new OcenaInzynieraKierownikaProjektu(
                inzynierKierownik, 
                rok, 
                oceniajacyHR, 
                komentarz,
                ocenySzczegolowe["EfektywnoscPracy"],
                ocenySzczegolowe["ZarzadzanieProjektami"],
                ocenySzczegolowe["UmiejetnosciTechniczne"],
                ocenySzczegolowe["ZarzadzanieZespolem"]
            );
        }
        else if (pracownik is InzynierProdukcji inzynier)
        {
            return new OcenaInzynieraProdukcji(
                inzynier, 
                rok, 
                oceniajacyHR, 
                komentarz,
                ocenySzczegolowe["Efektywnosc"],
                ocenySzczegolowe["Innowacyjnosc"],
                ocenySzczegolowe["JakoscPracy"],
                ocenySzczegolowe["RealizacjaProjektow"]
            );
        }
        else if (pracownik is PrzedstawicielHandlowy handlowiec)
        {
            return new OcenaPrzedstawicielaHandlowego(
                handlowiec, 
                rok, 
                oceniajacyHR, 
                komentarz,
                ocenySzczegolowe["RealizacjaCelowSprzedazowych"],
                ocenySzczegolowe["PozyskiwanieKlientow"],
                ocenySzczegolowe["ObslugaKlienta"],
                ocenySzczegolowe["UmiejetnosciNegocjacyjne"]
            );
        }
        else if (pracownik is Kierownik kierownik)
        {
            return new OcenaKierownika(
                kierownik, 
                rok, 
                oceniajacyHR, 
                komentarz,
                ocenySzczegolowe["ZarzadzanieZespolem"],
                ocenySzczegolowe["RealizacjaCelow"],
                ocenySzczegolowe["UmiejetnosciPrzywodcze"],
                ocenySzczegolowe["ZarzadzanieKryzysowe"]
            );
        }
        else if (pracownik is SpecjalistaHR hr)
        {
            return new OcenaSpecjalistyHR(
                hr, 
                rok, 
                oceniajacyHR, 
                komentarz,
                ocenySzczegolowe["EfektywnoscRekrutacji"],
                ocenySzczegolowe["JakoscSzkolen"],
                ocenySzczegolowe["Dokumentacja"],
                ocenySzczegolowe["WspolpracaZZespolem"]
            );
        }
        
        throw new ArgumentException($"Nieobsługiwany typ pracownika: {pracownik.GetType().Name}");
    }
}
using System.Text.Json;

namespace COMPLINEX;

public static class FabrykaPracownikow
{
    public static Pracownik UtworzPracownika(string typPracownika, string imie, string nazwisko, DateTime dataUrodzenia,
        string numerPracownika, DateTime dataZatrudnienia, decimal wynagrodzenie, string daneSpecyficzne,
        decimal wartoscSprzedazy)
    {
        switch (typPracownika)
        {
            case "InzynierProdukcji":
                var daneInzyniera = JsonSerializer.Deserialize<Dictionary<string, object>>(daneSpecyficzne);
                return new InzynierProdukcji(
                    imie,
                    nazwisko,
                    dataUrodzenia,
                    numerPracownika,
                    dataZatrudnienia,
                    wynagrodzenie,
                    daneInzyniera["Specjalizacja"].ToString(),
                    int.Parse(daneInzyniera["LiczbaNadzorowychProjektow"].ToString())
                );

            case "InzynierKierownikProjektu":
                var daneKierownika = JsonSerializer.Deserialize<Dictionary<string, object>>(daneSpecyficzne);
                return new InzynierKierownikProjektu(
                    imie,
                    nazwisko,
                    dataUrodzenia,
                    numerPracownika,
                    dataZatrudnienia,
                    wynagrodzenie,
                    daneKierownika["Specjalizacja"].ToString(),
                    int.Parse(daneKierownika["LiczbaNadzorowychProjektow"].ToString()),
                    int.Parse(daneKierownika["LiczbaProjektow"].ToString())
                );

            case "KierownikProdukcji":
                var daneKierProdukcji = JsonSerializer.Deserialize<Dictionary<string, object>>(daneSpecyficzne);
                return new KierownikProdukcji(
                    imie,
                    nazwisko,
                    dataUrodzenia,
                    numerPracownika,
                    dataZatrudnienia,
                    wynagrodzenie,
                    int.Parse(daneKierProdukcji["LiczbaPodwladnych"].ToString()),
                    daneKierProdukcji["Dzial"].ToString(),
                    double.Parse(daneKierProdukcji["WskaznikEfektywnosciProdukcji"].ToString())
                );

            case "PrzedstawicielHandlowy":
                return new PrzedstawicielHandlowy(
                    imie,
                    nazwisko,
                    dataUrodzenia,
                    numerPracownika,
                    dataZatrudnienia,
                    wynagrodzenie,
                    wartoscSprzedazy
                );

            case "SpecjalistaHR":
                return new SpecjalistaHR(
                    imie,
                    nazwisko,
                    dataUrodzenia,
                    numerPracownika,
                    dataZatrudnienia,
                    wynagrodzenie
                );

            default:
                throw new ArgumentException($"Nieobsługiwany typ pracownika: {typPracownika}");
        }
    }
}
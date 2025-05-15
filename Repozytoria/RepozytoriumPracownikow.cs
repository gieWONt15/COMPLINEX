using System.Text.Json;

namespace COMPLINEX;

using System.Data;

public class RepozytoriumPracownikow
{
    private readonly BazaDanych _bazaDanych;

    public RepozytoriumPracownikow()
    {
        _bazaDanych = BazaDanych.Instancja;
    }

    /// <summary>
    /// Pobiera ocenę realizacji celów sprzedażowych dla danego pracownika
    /// </summary>
    public int OcenaRealizacjiCelowSprzedazowych(string numerPracownika)
    {
        string query = @"
            SELECT OcenySzczegolowe
            FROM OcenyPracownikow
            WHERE IdPracownika = @NumerPracownika AND TypOceny = 'PrzedstawicielHandlowy'";
        
        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        if (result.Rows.Count == 0)
            throw new Exception("Nie znaleziono oceny dla podanego pracownika.");

        var ocenySzczegolowe = result.Rows[0]["OcenySzczegolowe"].ToString();
        var oceny = JsonSerializer.Deserialize<Dictionary<string, int>>(ocenySzczegolowe);

        return oceny["RealizacjaCelowSprzedazowych"];
    }

    /// <summary>
    /// Pobiera ocenę pozyskiwania klientów dla danego pracownika
    /// </summary>
    public int OcenaPozyskiwaniaKlientow(string numerPracownika)
    {
        string query = @"
            SELECT OcenySzczegolowe
            FROM OcenyPracownikow
            WHERE IdPracownika = @NumerPracownika AND TypOceny = 'PrzedstawicielHandlowy'";
        
        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        if (result.Rows.Count == 0)
            throw new Exception("Nie znaleziono oceny dla podanego pracownika.");

        var ocenySzczegolowe = result.Rows[0]["OcenySzczegolowe"].ToString();
        var oceny = JsonSerializer.Deserialize<Dictionary<string, int>>(ocenySzczegolowe);

        return oceny["PozyskiwanieKlientow"];
    }

    /// <summary>
    /// Pobiera ocenę obsługi klienta dla danego pracownika
    /// </summary>
    public int OcenaObslugiKlienta(string numerPracownika)
    {
        string query = @"
            SELECT OcenySzczegolowe
            FROM OcenyPracownikow
            WHERE IdPracownika = @NumerPracownika AND TypOceny = 'PrzedstawicielHandlowy'";
        
        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        if (result.Rows.Count == 0)
            throw new Exception("Nie znaleziono oceny dla podanego pracownika.");

        var ocenySzczegolowe = result.Rows[0]["OcenySzczegolowe"].ToString();
        var oceny = JsonSerializer.Deserialize<Dictionary<string, int>>(ocenySzczegolowe);

        return oceny["ObslugaKlienta"];
    }

    /// <summary>
    /// Pobiera ocenę umiejętności negocjacyjnych dla danego pracownika
    /// </summary>
    public int OcenaUmiejetnosciNegocjacyjnych(string numerPracownika)
    {
        string query = @"
            SELECT OcenySzczegolowe
            FROM OcenyPracownikow
            WHERE IdPracownika = @NumerPracownika AND TypOceny = 'PrzedstawicielHandlowy'";
        
        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        if (result.Rows.Count == 0)
            throw new Exception("Nie znaleziono oceny dla podanego pracownika.");

        var ocenySzczegolowe = result.Rows[0]["OcenySzczegolowe"].ToString();
        var oceny = JsonSerializer.Deserialize<Dictionary<string, int>>(ocenySzczegolowe);

        return oceny["UmiejetnosciNegocjacyjne"];
    }

    public Pracownik PobierzPracownika(string numerPracownika)
    {
        string query = @"
        SELECT NumerPracownika, Imie, Nazwisko, DataUrodzenia, DataZatrudnienia, Wynagrodzenie, TypPracownika, DaneSpecyficzne
        FROM Pracownicy
        WHERE NumerPracownika = @NumerPracownika";

        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        if (result.Rows.Count == 0)
            throw new Exception("Nie znaleziono pracownika o podanym numerze.");

        var row = result.Rows[0];
        var typPracownika = row["TypPracownika"].ToString();
        var daneSpecyficzne = row["DaneSpecyficzne"]?.ToString() ?? "{}";

        // return FabrykaPracownikow.UtworzPracownika(
        //     typPracownika,
        //     row["Imie"].ToString(),
        //     row["Nazwisko"].ToString(),
        //     DateTime.Parse(row["DataUrodzenia"].ToString()),
        //     row["NumerPracownika"].ToString(),
        //     DateTime.Parse(row["DataZatrudnienia"].ToString()),
        //     decimal.Parse(row["Wynagrodzenie"].ToString()),
        //     daneSpecyficzne
        // );
        return null;
    }
}
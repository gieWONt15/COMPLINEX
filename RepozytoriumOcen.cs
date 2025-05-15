using System.Data;
using System.Text.Json;

namespace COMPLINEX;

public class RepozytoriumOcen
{
    private readonly RepozytoriumPracownikow _repozytoriumPracownikow;
    private readonly BazaDanych _bazaDanych;

    public RepozytoriumOcen(RepozytoriumPracownikow repozytoriumPracownikow)
    {
        _repozytoriumPracownikow = repozytoriumPracownikow;
        _bazaDanych = BazaDanych.Instancja;
    }

    public void ZapiszOcene(OcenaPracownika ocena)
    {
        string query = @"
            INSERT INTO OcenyPracownikow
            (IdPracownika, IdOceniajacegoHR, DataWystawienia, Rok, Komentarz, OcenaOgolna, Status, Kategoria, TypOceny, OcenySzczegolowe)
            VALUES
            (@IdPracownika, @IdOceniajacegoHR, @DataWystawienia, @Rok, @Komentarz, @OcenaOgolna, @Status, @Kategoria, @TypOceny, @OcenySzczegolowe)";

        var ocenySzczegolowe = JsonSerializer.Serialize(new Dictionary<string, int>
        {
            { "RealizacjaCelowSprzedazowych", (ocena as OcenaPrzedstawicielaHandlowego)?.RealizacjaCelowSprzedazowych ?? 0 },
            { "PozyskiwanieKlientow", (ocena as OcenaPrzedstawicielaHandlowego)?.PozyskiwanieKlientow ?? 0 },
            { "ObslugaKlienta", (ocena as OcenaPrzedstawicielaHandlowego)?.ObslugaKlienta ?? 0 },
            { "UmiejetnosciNegocjacyjne", (ocena as OcenaPrzedstawicielaHandlowego)?.UmiejetnosciNegocjacyjne ?? 0 }
        });

        var parameters = new Dictionary<string, object>
        {
            { "@IdPracownika", ocena.IdPracownika },
            { "@IdOceniajacegoHR", ocena.IdOceniajacegoHR },
            { "@DataWystawienia", ocena.DataWystawienia.ToString("yyyy-MM-dd") },
            { "@Rok", ocena.Rok },
            { "@Komentarz", ocena.Komentarz },
            { "@OcenaOgolna", ocena.OcenaOgolna },
            { "@Status", ocena.Status },
            { "@Kategoria", ocena.Kategoria },
            { "@TypOceny", ocena.GetType().Name },
            { "@OcenySzczegolowe", ocenySzczegolowe }
        };

        _bazaDanych.WykonajZapytanie(query, parameters);
    }

    public List<OcenaPracownika> PobierzOcenyPracownika(string numerPracownika)
    {
        string query = @"
            SELECT Id, IdPracownika, IdOceniajacegoHR, DataWystawienia, Rok, Komentarz, OcenaOgolna, Status, Kategoria, TypOceny, OcenySzczegolowe
            FROM OcenyPracownikow
            WHERE IdPracownika = @NumerPracownika";

        var parameters = new Dictionary<string, object>
        {
            { "@NumerPracownika", numerPracownika }
        };

        var result = _bazaDanych.WykonajZapytanieZwracajaceWyniki(query, parameters);

        var oceny = new List<OcenaPracownika>();

        foreach (DataRow row in result.Rows)
        {
            var typOceny = row["TypOceny"].ToString();
            var ocenySzczegolowe = JsonSerializer.Deserialize<Dictionary<string, int>>(row["OcenySzczegolowe"].ToString() ?? "{}");

            var pracownik = _repozytoriumPracownikow.PobierzPracownika(row["IdPracownika"].ToString());
            var oceniajacyHR = _repozytoriumPracownikow.PobierzPracownika(row["IdOceniajacegoHR"].ToString()) as SpecjalistaHR;

            var ocena = FabrykaOcen.UtworzOcene(
                pracownik,
                int.Parse(row["Rok"].ToString()),
                oceniajacyHR,
                row["Komentarz"].ToString(),
                ocenySzczegolowe
            );

            ocena.Id = int.Parse(row["Id"].ToString());
            ocena.DataWystawienia = DateTime.Parse(row["DataWystawienia"].ToString());
            ocena.Status = row["Status"].ToString();
            ocena.Kategoria = row["Kategoria"].ToString();
            ocena.OcenaOgolna = int.Parse(row["OcenaOgolna"].ToString());

            oceny.Add(ocena);
        }

        return oceny;
    }
}
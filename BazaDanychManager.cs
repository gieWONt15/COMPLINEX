using System.Data;

namespace COMPLINEX;

using System.Data.SQLite;

/// <summary>
/// Klasa zarządzająca połączeniem z bazą danych SQLite
/// </summary>
public class BazaDanych
{
    private readonly string _connectionString;
    private static BazaDanych _instancja;
    
    /// <summary>
    /// Singleton - dostęp do jedynej instancji klasy BazaDanych
    /// </summary>
    public static BazaDanych Instancja
    {
        get
        {
            if (_instancja == null)
                _instancja = new BazaDanych();
            return _instancja;
        }
    }
    
    /// <summary>
    /// Prywatny konstruktor - tworzy bazę danych jeśli nie istnieje
    /// </summary>
    private BazaDanych()
    {
        string dbPath = "ewaluacje.db";
        _connectionString = $"Data Source={dbPath};Version=3;";
        
        if (!File.Exists(dbPath))
        {
            Console.WriteLine("Tworzenie nowej bazy danych...");
            SQLiteConnection.CreateFile(dbPath);
            InicjalizujBazeDanych();
        }
    }
    
    /// <summary>
    /// Tworzy wymagane tabele w bazie danych
    /// </summary>
    private void InicjalizujBazeDanych()
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        
        // Tworzenie tabeli pracowników
        string createPracownicyTable = @"
            CREATE TABLE IF NOT EXISTS Pracownicy (
                NumerPracownika TEXT PRIMARY KEY,
                Imie TEXT NOT NULL,
                Nazwisko TEXT NOT NULL,
                DataUrodzenia TEXT NOT NULL,
                DataZatrudnienia TEXT NOT NULL,
                Wynagrodzenie REAL NOT NULL,
                TypPracownika TEXT NOT NULL,
                DaneSpecyficzne TEXT
            );";
        
        // Tworzenie tabeli ocen pracowników
        string createOcenyTable = @"
            CREATE TABLE IF NOT EXISTS OcenyPracownikow (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                IdPracownika TEXT NOT NULL,
                IdOceniajacegoHR TEXT NOT NULL,
                DataWystawienia TEXT NOT NULL,
                Rok INTEGER NOT NULL,
                Komentarz TEXT,
                OcenaOgolna INTEGER NOT NULL,
                Status TEXT NOT NULL,
                Kategoria TEXT NOT NULL,
                TypOceny TEXT NOT NULL,
                OcenySzczegolowe TEXT NOT NULL,
                FOREIGN KEY (IdPracownika) REFERENCES Pracownicy (NumerPracownika),
                FOREIGN KEY (IdOceniajacegoHR) REFERENCES Pracownicy (NumerPracownika)
            );";
        
        using (var command = new SQLiteCommand(createPracownicyTable, connection))
        {
            command.ExecuteNonQuery();
        }
        
        using (var command = new SQLiteCommand(createOcenyTable, connection))
        {
            command.ExecuteNonQuery();
        }
        
        Console.WriteLine("Baza danych została zainicjalizowana.");
    }
    
    /// <summary>
    /// Otwiera nowe połączenie z bazą danych
    /// </summary>
    /// <returns>Połączenie z bazą danych</returns>
    public SQLiteConnection OtworzPolaczenie()
    {
        var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        return connection;
    }
    
    /// <summary>
    /// Wykonuje zapytanie SQL i zwraca wartość skalarną
    /// </summary>
    /// <param name="sqlQuery">Zapytanie SQL</param>
    /// <param name="parameters">Parametry zapytania</param>
    /// <returns>Wynik zapytania</returns>
    public object WykonajZapytanieSkalarne(string sqlQuery, Dictionary<string, object> parameters = null)
    {
        using var connection = OtworzPolaczenie();
        using var command = new SQLiteCommand(sqlQuery, connection);
        
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }
        
        return command.ExecuteScalar();
    }
    
    /// <summary>
    /// Wykonuje zapytanie SQL bez zwracania wyniku
    /// </summary>
    /// <param name="sqlQuery">Zapytanie SQL</param>
    /// <param name="parameters">Parametry zapytania</param>
    /// <returns>Liczba zmodyfikowanych wierszy</returns>
    public int WykonajZapytanie(string sqlQuery, Dictionary<string, object> parameters = null)
    {
        using var connection = OtworzPolaczenie();
        using var command = new SQLiteCommand(sqlQuery, connection);
        
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }
        
        return command.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Wykonuje zapytanie SELECT i zwraca DataTable z wynikami
    /// </summary>
    /// <param name="sqlQuery">Zapytanie SQL</param>
    /// <param name="parameters">Parametry zapytania</param>
    /// <returns>Tabela z wynikami</returns>
    public DataTable WykonajZapytanieZwracajaceWyniki(string sqlQuery, Dictionary<string, object> parameters = null)
    {
        using var connection = OtworzPolaczenie();
        using var command = new SQLiteCommand(sqlQuery, connection);
        
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }
        
        var dataTable = new DataTable();
        using var adapter = new SQLiteDataAdapter(command);
        adapter.Fill(dataTable);
        
        return dataTable;
    }
}
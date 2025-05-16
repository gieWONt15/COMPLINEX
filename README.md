# COMPLINEX

**COMPLINEX** to system zarządzania ocenami pracowników, który umożliwia tworzenie, przechowywanie i wyświetlanie szczegółowych ocen dla różnych typów pracowników w organizacji.

## Funkcjonalności

- **Tworzenie ocen pracowników**: System umożliwia tworzenie ocen dla różnych typów pracowników, takich jak inżynierowie, handlowcy, kierownicy czy specjaliści HR. Każda ocena jest dostosowana do specyfiki stanowiska.

- **Szczegółowe oceny**: Każda ocena zawiera szczegółowe kryteria, takie jak:
    - Efektywność pracy
    - Jakość realizowanych zadań
    - Umiejętności techniczne
    - Współpraca z zespołem
    - Zarządzanie projektami
    - Umiejętności przywódcze

- **System zarządzania ocenami**: Wszystkie oceny są przechowywane w jednym miejscu, co umożliwia łatwe zarządzanie i przeglądanie wyników.

- **Generowanie raportów**: Możliwość generowania raportów ocen dla poszczególnych pracowników lub całych zespołów, co ułatwia analizę wyników.

- **Filtrowanie ocen**: Funkcja filtrowania ocen według roku, działu lub stanowiska, co pozwala na szybkie wyszukiwanie interesujących danych.

- **Edycja ocen**: System umożliwia edytowanie istniejących ocen, co pozwala na aktualizację danych w przypadku zmiany sytuacji.

- **Eksport danych**: Oceny mogą być eksportowane do pliku CSV, co ułatwia ich dalsze przetwarzanie lub archiwizację.

- **Interfejs użytkownika**: Prosty interfejs konsolowy umożliwia użytkownikowi łatwe korzystanie z funkcji systemu, takich jak dodawanie, edytowanie, filtrowanie i eksportowanie ocen.

## Przykład użycia

W pliku `Program.cs` znajduje się przykład użycia systemu:

### 1. Tworzenie pracowników.
System umożliwia tworzenie różnych typów pracowników, takich jak inżynierowie, handlowcy, kierownicy czy specjaliści HR. Każdy pracownik posiada unikalne dane, takie jak imię, nazwisko, stanowisko, data zatrudnienia, wynagrodzenie oraz dodatkowe informacje specyficzne dla danego stanowiska.

Przykład:
```csharp
  var inzynier = new InzynierProdukcji(
      "Jan", "Kowalski", new DateTime(1980, 5, 15),
      "INZ001", new DateTime(2010, 6, 1),
      8000m, "automatyzacja procesów", 3)
```
### 2. Tworzenie ocen dla każdego pracownika.
Oceny są tworzone na podstawie szczegółowych kryteriów, które różnią się w zależności od stanowiska. Każda ocena zawiera rok, komentarz oraz szczegółowe oceny w formie słownika.

Przykład:
```csharp
var ocenaSzczegolowaInzyniera = new Dictionary<string, int>
{
    {"Efektywnosc", 4},
    {"Innowacyjnosc", 5},
    {"JakoscPracy", 4},
    {"RealizacjaProjektow", 3}
};

var ocenaInzyniera = FabrykaOcen.UtworzOcene(
    inzynier, 2023, specjalistaHr, 
    "Wybitny specjalista, wprowadził kilka innowacyjnych rozwiązań w procesie produkcji.",
    ocenaSzczegolowaInzyniera);
```
### 3. Dodawanie ocen do systemu.
Utworzone oceny są dodawane do systemu ocen, co umożliwia ich przechowywanie i dalsze przetwarzanie.

Przykład:
```csharp
systemOcen.DodajOcene(ocenaInzyniera);
```
### 4. Wyświetlanie wszystkich ocen.
System umożliwia wyświetlenie wszystkich ocen w konsoli, co pozwala na szybki przegląd wyników.

Przykład:
```csharp
systemOcen.WyswietlWszystkieOceny();
```
## Struktura projektu
```
COMPLINEX/
│
├── BazaDanych/
│   └── BazaDanychManager.cs
│
├── Fabryki/
│   ├── FabrykaOcen.cs
│   └── FabrykaPracownikow.cs
│
├── Modele/
│   ├── InzynierKierownikProjektu.cs
│   ├── InzynierProdukcji.cs
│   ├── Kierownik.cs
│   ├── KierownikProdukcji.cs
│   ├── KierownikProdukcjiProjektu.cs
│   ├── KierownikSprzedazy.cs
│   ├── Osoba.cs
│   ├── Pracownik.cs
│   ├── ProjektManager.cs
│   ├── PrzedstawicielHandlowy.cs
│   └── SpecjalistaHR.cs
│
├── Oceny/
│   ├── OcenaInzynieraKierownikaProjektu.cs
│   ├── OcenaInzynieraProdukcji.cs
│   ├── OcenaKierownika.cs
│   ├── OcenaPracownika.cs
│   ├── OcenaPrzedstawicielaHandlowego.cs
│   └── OcenaSpecjalistyHR.cs
│
├── Rejestry/
│   ├── RejestrPracownikow.cs
│   └── RejestrProjektow.cs
│
├── Repozytoria/
│   ├── RepozytoriumOcen.cs
│   └── RepozytoriumPracownikow.cs
│
├── Utils/
│   └── SystemOcenPracowniczych.cs
│
├── Program.cs
├── .gitignore
└── README.md
```
- **Język**: C#
- **Framework**: .NET 6.0 lub nowszy

## Jak uruchomić projekt?

### 1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/gieWONt15/complinex.git
   ```
   ```bash
   cd complinex
   ```
### 2. Upewnij się, że masz zainstalowane środowisko .NET 6.0 lub nowsze.
Możesz to sprawdzić, wpisując:
```bash
dotnet --version
```
### 3. Przygotuj projekt do uruchomienia:
```bash
dotnet restore
```
### 4. Uruchom projekt
```bash
dotnet run
```
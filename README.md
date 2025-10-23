# Projekt CRUD - Product Manager

To jest projekt w ramach kursu "Projekt zespołowy", który implementuje pełną aplikację CRUD (Create, Read, Update, Delete) dla encji "Produkt". Aplikacja składa się z backendu (.NET Web API) oraz prostego frontendu (HTML/JS/CSS).

## Użyte Technologie
-   **Backend**: C# z ASP.NET Core Web API
-   **Baza Danych**: SQLite z użyciem Entity Framework Core
-   **Frontend**: Podstawowy HTML, CSS i JavaScript

## Struktura encji (Model)
Encja `Product` zawiera następujące pola:
* `Id` (int) - Klucz główny
* `Name` (string) - Nazwa produktu
* `Price` (decimal) - Cena
* `Category` (string) - Kategoria
* `CreatedAt` (DateTime) - Data utworzenia
* `Description` (string) - Opis produktu (dodane w ramach zadania B)
* `InStock` (bool) - Czy dostępny (dodane w ramach zadania B)

## Jak uruchomić lokalnie
1.  Sklonuj repozytorium.
2.  Otwórz terminal w głównym folderze projektu.
3.  Uruchom polecenie: `dotnet run`
4.  Otwórz przeglądarkę i przejdź pod adres `http://localhost:5262` (lub inny port wskazany w konsoli).

## 🚀 Wdrożenie Online (Live Demo)
Aplikacja została wdrożona i jest dostępna publicznie pod adresem:

-   **Aplikacja (Frontend + Backend):**https://projekt-crud-kyryl-movchan.onrender.com

## 🚀 Rozszerzenie Modułu Produktów (Nowe Funkcjonalności)

Wprowadzono rozszerzenie funkcjonalności poprzez dodanie dwóch nowych atrybutów do głównej encji `Product`, co stanowi **ulepszenie** i **rozbudowę** istniejącego modułu zarządzania produktami. Zmiany te zostały w pełni zintegrowane na wszystkich poziomach aplikacji (model, API, frontend).

### Nowe Atrybuty Produktu:

1.  **`Description`** (`string`): Pełny opis produktu.
2.  **`InStock`** (`bool`): Flaga wskazująca, czy produkt jest aktualnie dostępny na magazynie.

### Zmiany Architektoniczne:

| Warstwa | Szczegóły implementacji |
| :--- | :--- |
| **Model Danych** | Dodano właściwości `Description` i `InStock` do klasy `Product.cs`. Wygenerowano i zastosowano migrację bazy danych. |
| **API REST** | Zaktualizowano kontroler `ProductsController.cs`. W metodzie `PostProduct` dodano walidację sprawdzającą, czy pole `Description` nie jest puste. Endpointy API poprawnie obsługują przesyłanie i pobieranie nowych pól. |
| **Frontend** | Zaktualizowano formularz (dodano pole tekstowe dla `Description` i checkbox dla `InStock`). Zaktualizowano tabelę produktów oraz logikę edycji (`editProduct`) do pełnej obsługi nowych atrybutów. |

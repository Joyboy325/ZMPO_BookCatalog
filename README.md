## BookCatalog

Aplikacja, którą stworzyłem to katalog książek pokazujący podstawowe funkcjonalności operacji na bazie danych (CRUD).

**C** - Create - możliwość dodania książki do katalogu.

**R** - Read - wyświetlanie listy wszystkich książek, wyświetlanie szczegółów konkretnej pozycji.

**U** - Update - Możliwość edycji wszystkich/pojedynczych pól modelu danej książki.

**D** - Delete - możliwość usuwania pozycji z katalogu.


## Jak odpalić projekt lokalnie

1. Sklonować kod z repozytorium
2. Zbudować
3. Z wykorzystaniem konsoli Packet Managera wykonać komendę `Update-Database`. Pozwoli to na utworzenie bazy danych i odpowiedniej tabeli `Books` przechowującej książki.

Serwer, na którym zostanie utworzona baza danych to: `(localdb)\\mssqllocaldb`.
Nazwa utworzonej bazy:	`BooksDatabase`

*ConnectionString do bazy danych można w dowolnej chwili zmienić poprzez edycję pliku `appsettings.json`

4. Odpalić projekt (F5)
5. Przy pierwszym uruchomieniu (oraz **każdorazowo** w sytuacji, w której podczas odpalenia projektu tabela `Books` będzie pusta) tabela `Books` zostanie zasilona trzema testowymi pozycjami katalogowymi.

[!] Wymagany zainstalowany SQL Server [!] 

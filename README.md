<h1>Aplikacja Sklepu Internetowego</h1>

<h2>Opis projektu</h2>
<p>Ten projekt jest aplikacją sklepu internetowego napisaną w ASP.NET Core z wykorzystaniem Entity Framework oraz bazy danych SQL. Aplikacja została stworzona w ramach zajęć na <strong>Akademii Górniczo-Hutniczej</strong> na przedmiot <strong>"Bazy Danych"</strong>.</p>

<h2>Funkcjonalności</h2>
<ul>
    <li>Przeglądanie produktów z możliwością filtrowania i wyszukiwania.</li>
    <li>Koszyk, w którym użytkownicy mogą dodawać i usuwać produkty.</li>
    <li>Proces składania zamówień.</li>
    <li>Panel administracyjny do zarządzania produktami (dodawanie, edytowanie, usuwanie).</li>
    <li>Rejestracja i logowanie użytkowników.</li>
</ul>

<h2>Technologie</h2>
<ul>
    <li><strong>ASP.NET Core MVC</strong> – framework do budowy aplikacji webowych.</li>
    <li><strong>Entity Framework Core</strong> – ORM do zarządzania bazą danych SQL.</li>
    <li><strong>SQL Server</strong> – system zarządzania relacyjną bazą danych.</li>
    <li><strong>Bootstrap</strong> – biblioteka CSS do budowy responsywnego interfejsu użytkownika.</li>
    <li><strong>C#</strong> – język programowania użyty w aplikacji.</li>
</ul>

<h2>Wymagania systemowe</h2>
<ul>
    <li>.NET SDK 6.0 lub nowszy</li>
    <li>SQL Server (lub SQL Server Express)</li>
    <li>Visual Studio 2022 lub inne kompatybilne IDE</li>
</ul>

<h2>Instalacja i uruchomienie</h2>
<ol>
    <li><strong>Sklonuj repozytorium:</strong>
        <pre><code>git clone https://github.com/username/sklep-internetowy.git
cd sklep-internetowy</code></pre>
    </li>

    <li><strong>Przygotowanie bazy danych:</strong>
        <p>Skonfiguruj połączenie z bazą danych SQL w pliku <code>appsettings.json</code>:</p>
        <pre><code>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SklepDB;Trusted_Connection=True;"
  }
}</code>
</pre>
    <li>
        <p>Wykonaj migracje, aby utworzyć bazę danych:</p>
        <pre><code>dotnet ef database update</code></pre>
    </li>
<li><strong>Uruchomienie aplikacji:</strong>
        <pre><code>dotnet run</code></pre>
        <p>Otwórz przeglądarkę i przejdź pod adres <code>https://localhost:5001</code>, aby korzystać z aplikacji.</p>
    </li>
    
</ol>

<h2>Struktura projektu</h2>
<ul>
    <li><strong>Controllers/</strong> – kontrolery obsługujące logikę biznesową aplikacji.</li>
    <li><strong>Models/</strong> – modele danych, w tym encje dla Entity Framework.</li>
    <li><strong>Views/</strong> – widoki aplikacji, odpowiedzialne za interfejs użytkownika.</li>
    <li><strong>Migrations/</strong> – migracje Entity Framework do zarządzania schematem bazy danych.</li>
</ul>

<h2>Migracje bazy danych</h2>
<p>Aby dodać nową migrację, użyj polecenia:</p>
<pre><code>dotnet ef migrations add NazwaMigracji</code></pre>

<h2>Autorzy</h2>
<ul>
    <li><strong>Kacper Goncerz</strong> – student AGH,<strong>Inżynieria Obliczeniowa</strong> 2023</li>
</ul>

📚 SmartBookApp

SmartBookApp är en enkel konsolapplikation i C# för att hantera ett digitalt bibliotek. Användaren kan:

Lägga till, ta bort, söka och visa böcker

Låna och återlämna böcker (genom att ändra deras lånestatus)

Spara biblioteket till en fil för framtida användning

🚀 Funktioner

➕ Lägga till nya böcker

❌ Ta bort böcker (via titel eller ISBN)

🔍 Söka efter böcker (titel, författare, kategori eller ISBN)

📄 Visa alla böcker, sorterade efter titel

🔁 Låna och återlämna böcker

📀 Spara biblioteket till en fil (library.json)

📂 Ladda biblioteket från fil vid uppstart

⚒️ Hur kör man programmet?

Öppna projektet i Visual Studio eller valfri IDE som stödjer .NET.

Alternativt, använd .NET CLI:

dotnet run --project SmartBookApp

🗂️ Projektstruktur

SmartBookApp/
├── Models/        - Klasser för böcker och bibliotek
├── Services/      - Applikationens logik och menyhantering
├── Utils/         - Hjälpfunktioner för validering och JSON-hantering
├── Program.cs     - Startpunkt för applikationen

SmartBookApp.Tests/
└──                - Separat testprojekt med enhetstester (xUnit)

✅ Testning

Testerna är implementerade med xUnit och täcker:

🔢 Bok (Book)

Generering av ISBN när inget anges

Användarinmatat ISBN hanteras korrekt

🔢 Bibliotek (Library)

Lägga till böcker

Ta bort böcker via titel eller ISBN

📋 Övrigt

Programmet är helt konsolbaserat

Fokus på tydlig kodstruktur, testbarhet och separation av ansvar

JSON används för att spara och ladda biblioteket


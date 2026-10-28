# Full-Stack-WPF-Trader

A WPF stock trading desktop app built with the MVVM pattern. The home screen shows the Dow Jones, Nasdaq and S&P 500 major indexes fetched from the Financial Modeling Prep API, and a SQL Server database (EF Core) holds users, accounts and asset transactions.

## Tech Stack

- .NET 8 (`net8.0`, `net8.0-windows` for the WPF app)
- WPF (MVVM: view models, `ICommand`, navigator, value converter, data templates)
- Entity Framework Core 8 with SQL Server
- Newtonsoft.Json and `HttpClient` for the Financial Modeling Prep REST API

## Project Structure

| Project | Description |
| --- | --- |
| `Trader.Domain` | Domain models (`User`, `Account`, `AssetTransactions`, `Stock`, `MajorIndex`) and service interfaces (`IDataService<T>`, `IMajorIndex`). |
| `Trader.EF` | `TraderDbContext`, a design-time DbContext factory, a generic CRUD data service and EF Core migrations. |
| `Trader.API` | `MajorIndexService`, which calls the Financial Modeling Prep API to get major index data. |
| `TraderWpf` | WPF desktop client: main window, navigation bar, home view with major index cards, portfolio view. |

## Features

- Navigation bar (Home, Portfolio, Buy) that switches the current view model.
- Home view with cards for the Dow Jones, Nasdaq and S&P 500 indexes, loaded asynchronously from the Financial Modeling Prep API.
- Database schema for users, accounts and asset transactions (stock symbol, price per share, share amount, buy/sell), created through EF Core migrations.
- Generic async CRUD data service (`GetAll`, `Get`, `Create`, `Update`, `Delete`) over the DbContext.

The Portfolio and Buy views are placeholders, and the WPF client does not use the database yet.

## Getting Started

### Prerequisites

- Windows
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, Express or full edition)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

### Database

The connection string is in `Trader.EF/DesignTimeDbContext.cs`:

```
Server=.;Database=TraderDb;Trusted_Connection=True;TrustServerCertificate=True;
```

Change `Server=` if your SQL Server instance has a different name, then create the database:

```bash
cd Trader.EF
dotnet ef database update
```

### Run

```bash
dotnet run --project TraderWpf
```

or open `Trader.sln` in Visual Studio and set `TraderWpf` as the startup project.

The major index data comes from `https://financialmodelingprep.com`; the API key is set in `Trader.API/Services/MajorIndexService.cs`.

## License

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt).

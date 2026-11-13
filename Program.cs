using wt_lab6_minimalapi_besman.Models;
using wt_lab6_minimalapi_besman.Data;

var builder = WebApplication.CreateBuilder(args);

// --- Настройка Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// -------------------------

var app = builder.Build();

// --- Включение Swagger UI ---
app.UseSwagger();
app.UseSwaggerUI();
// ----------------------------

// ---------- Блок 1. Проверка работы и информация ----------
app.MapGet("/", () => "Minimal API (Bank) by Besman is running");

app.MapGet("/api/info", () => new
{
    Name        = "Bank Accounts API",
    Version     = "1.2",
    Author      = "Besman",
    Description = "REST API для управления банковскими счетами",
    DateTime    = DateTime.UtcNow
});

// ---------- Блок 3. GET ----------
app.MapGet("/api/accounts", (string? search, string? currency) =>
{
    var query = AccountStore.Accounts.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
        query = query.Where(a => a.OwnerName.Contains(search, StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(currency))
        query = query.Where(a => a.Currency.Equals(currency, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(query.ToList());
});

app.MapGet("/api/accounts/{id:int}", (int id) =>
{
    var account = AccountStore.Accounts.FirstOrDefault(a => a.Id == id);
    return account is null
        ? Results.NotFound(new { message = $"Account {id} not found" })
        : Results.Ok(account);
});

// ---------- Блок 4. POST ----------
app.MapPost("/api/accounts", (Account account) =>
{
    if (string.IsNullOrWhiteSpace(account.OwnerName) || string.IsNullOrWhiteSpace(account.AccountNumber))
        return Results.BadRequest(new { message = "OwnerName and AccountNumber are required" });

    account.Id = AccountStore.Accounts.Count == 0
        ? 1
        : AccountStore.Accounts.Max(a => a.Id) + 1;

    AccountStore.Accounts.Add(account);

    return Results.Created($"/api/accounts/{account.Id}", account);
});

// ---------- Блок 5. PUT и DELETE ----------
app.MapPut("/api/accounts/{id:int}", (int id, Account updated) =>
{
    var account = AccountStore.Accounts.FirstOrDefault(a => a.Id == id);
    if (account is null)
        return Results.NotFound(new { message = $"Account {id} not found" });

    if (string.IsNullOrWhiteSpace(updated.OwnerName) || string.IsNullOrWhiteSpace(updated.AccountNumber))
        return Results.BadRequest(new { message = "OwnerName and AccountNumber are required" });

    account.OwnerName     = updated.OwnerName;
    account.AccountNumber = updated.AccountNumber;
    account.Currency      = updated.Currency;
    account.Balance       = updated.Balance;
    account.IsBlocked     = updated.IsBlocked;

    return Results.Ok(account);
});

app.MapDelete("/api/accounts/{id:int}", (int id) =>
{
    var account = AccountStore.Accounts.FirstOrDefault(a => a.Id == id);
    if (account is null)
        return Results.NotFound(new { message = $"Account {id} not found" });

    AccountStore.Accounts.Remove(account);
    return Results.NoContent();
});

app.Run();
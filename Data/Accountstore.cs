using wt_lab6_minimalapi_besman.Models;

namespace wt_lab6_minimalapi_besman.Data;

public static class AccountStore
{
    public static List<Account> Accounts { get; } = new()
    {
        new Account { Id = 1, OwnerName = "Besman Ivan Ivanovich",     AccountNumber = "BY01 BESM 1111 1111", Currency = "BYN", Balance = 1500.50m, IsBlocked = false },
        new Account { Id = 2, OwnerName = "Besman Anna Sergeevna",     AccountNumber = "BY02 BESM 2222 2222", Currency = "USD", Balance = 250.00m,  IsBlocked = false },
        new Account { Id = 3, OwnerName = "Petrov Petr Petrovich",     AccountNumber = "BY03 PETR 3333 3333", Currency = "BYN", Balance = 75.20m,   IsBlocked = true },
        new Account { Id = 4, OwnerName = "Kuznetsova Olga Andreevna", AccountNumber = "BY04 KUZN 4444 4444", Currency = "EUR", Balance = 890.00m,  IsBlocked = false },
        new Account { Id = 5, OwnerName = "Besman Dmitry Olegovich",   AccountNumber = "BY05 BESM 5555 5555", Currency = "BYN", Balance = 0.00m,    IsBlocked = true }
    };
}
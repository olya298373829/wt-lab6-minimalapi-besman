namespace wt_lab6_minimalapi_besman.Models;

public class Account
{
    public int Id { get; set; }
    public string OwnerName { get; set; } = ""; // Владелец счёта
    public string AccountNumber { get; set; } = ""; // Номер счёта
    public string Currency { get; set; } = "BYN"; // Валюта
    public decimal Balance { get; set; } // Баланс
    public bool IsBlocked { get; set; } // Заблокирован ли счёт
}
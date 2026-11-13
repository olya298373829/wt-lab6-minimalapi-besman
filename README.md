# WT Lab 6 — Minimal API (Bank) — Besman

REST API на ASP.NET Core Minimal API для управления банковскими счетами.

## Автор
**Besman**

## Модель
`Account`: Id, OwnerName, AccountNumber, Currency, Balance, IsBlocked.

## Таблица API

| Метод  | Endpoint                 | Назначение                        | Успех           |
|--------|--------------------------|-----------------------------------|-----------------|
| GET    | `/`                      | Проверка работы                   | 200 OK          |
| GET    | `/api/info`              | Информация о приложении           | 200 OK          |
| GET    | `/api/accounts`          | Список (+ `?search=&currency=`)   | 200 OK          |
| GET    | `/api/accounts/{id}`     | Счёт по ID                        | 200 / 404       |
| POST   | `/api/accounts`          | Создать счёт                      | 201 / 400       |
| PUT    | `/api/accounts/{id}`     | Обновить счёт                     | 200 / 400 / 404 |
| DELETE | `/api/accounts/{id}`     | Удалить счёт                      | 204 / 404       |

## Пример POST-запроса
```json
{
  "ownerName": "Besman Artem Novikov",
  "accountNumber": "BY06 BESM 6666 6666",
  "currency": "BYN",
  "balance": 500.00,
  "isBlocked": false
}
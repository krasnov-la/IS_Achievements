# Развертка API

## В контейнере:

1. Добавить файл `backend/back.env` вида:
~~~
    JwtIssuer="Some issuer"
    JwtAudience="Some audience"
    JwtKey="At least 32 characters long string"
    DbConnection="Server=postgres;Port=5432;Database=postgres;Userid=postgres;Password=SomePassword"
~~~
2. Добавить файл `database/db.env` вида (Пароль здесь должен совпадать с указанным в DbConnection):
~~~
    POSTGRES_PASSWORD="SomePassword"
~~~ 
3. Убедится, что существует файл `database/db_init_script.sql`, если его нет то выполнить `dotnet ef migrations script --project backend -o database/db_init_script.sql` 
4. Выполнить `docker compose up`, по умолчанию api будет работать на 5001 порте.

## Вне контейнера

1. Иметь работающую Postgres с пользователем `SomeUser`, пусть его пароль: `SomeUserPassword`
2. Добавить файл backend/super_secret.json вида:
~~~
{

    "JwtIssuer":"Some issuer",
    "JwtAudience":"Some audience",
    "JwtKey":"At least 32 characters long string",
    "DbConnection": "Server=localhost;Port=5432;Database=postgres;Userid=SomeUser;Password=SomeUserPassword"
}
~~~
3. Выполнить `dotnet ef database update`
4. Выполнить `dotnet run`, api будет работать на 5114 порте

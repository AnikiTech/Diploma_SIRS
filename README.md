Проект базируется на настольной версии СИРС-1.0 Быстрое чтение, память, мышление.
Проект придерживается DDD стиля.
Используемые технологии и библиотеки:
- asp .net core (3.1.301)
- EF Core 3.1
- automapper 9.x
- serilog 3.x
- Npgsql.EntityFrameworkCore.PostgreSQL 3.1
- NUnit (for tests)
- vue js 2.6.11
- PostgreSQL

Для работы с проектом потребуется:
- noda.js >= 12
- .net core sdk 3.1.301
- VS code/webstorm (frontend)
- VS community edition/IntelliJ IDEA (backend)
- pgAdmin и PostgreSQL выше 10 версии

В проекте есть общие настройки appsettings.json. В них указывается коннект к БД. Чтобы указать свой коннект и не закомитить его в гит нужно создать appsettings.Development.json.
Такое же правило и для настроек приложения appsettings.reading-memory-thinking.json.
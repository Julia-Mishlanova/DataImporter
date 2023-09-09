# Краткое описание
DataImporter - утилита импорта данных из файлов в БД.

Для создания консольного приложения использовались технологии:

- Code-First: Подход в Entity Framework Core для определения структуры БД через код C# и автоматического создания/обновления БД на основе этого кода.
- Entity Framework Core: Для работы с базой данных и миграциями, ORM для взаимодействия с базой данных.
- SQL (Structured Query Language)
- PostgreSQL: Реляционная СУБД, рассмотренная для создания БД.
- LINQ (Language Integrated Query): для выполнения запросов и манипулирования данными.

# Краткая Инструция
Как запускать (что доустановить, как скомпилировать, как настроить).

Пример данных в каталоге data.
Чтобы импортировать .tsv файл в базу данных необходимо перетащить его в .exe
Строка подключения к бд в .NET 5 содержится в appsettings.json. Используется postgreSQL 14 https://www.postgresql.org/download/

Строка подключения к бд "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1"

Чтобы вывести текущую структуру данных необходимо запустить .exe файл и ввести в консоль ID подразделения. Если необходимо вывести все подразделения (иерархия учитывается) необходимо ввести 0.
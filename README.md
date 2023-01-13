# natural-mix-server

## Get Started
### База данных PostgreSQL
В PGAdmin создайте пустую базу данных с именем natural_mix. В случае, если база данных будет называться иначе, 
вам потребуется заменить имя бд в строке подключения в файле NaturalMixDbContext следующим образом  
`protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=database_name;Username=postgres;Password=postgres");
        }`  
где __database_name__ - имя базы данных.

Далее, при клике ПКМ по базе данных, выбираем пункт Restor/Восстановление. В поле filename/имя файла указываем путь к бэкапу БД.

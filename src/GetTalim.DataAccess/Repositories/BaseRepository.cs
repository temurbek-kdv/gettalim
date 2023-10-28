using Npgsql;

namespace GetTalim.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        //_connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=gettalim-db; User Id=postgres; Password=ll;");
        //_connection = new NpgsqlConnection("Host=gettalim-database-host; Port=5432; Database=gettalim-db; User Id=postgres_admin; Password=QQ!!qq11;");

        _connection = new NpgsqlConnection("Host=db-postgresql-nyc3-62486-do-user-14993247-0.c.db.ondigitalocean.com; Port=25060; Database=gettalim-db; User Id=doadmin; Password=AVNS_6X-S9VpP5KFVSzOvFXt;");
    }
}

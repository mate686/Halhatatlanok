using Halhatatlanok.Data;
using Microsoft.EntityFrameworkCore;


namespace Halhatalanok.Test;


public static class TestDbFactory

{

    public static HalhatatlanContext CreateContext(string dbName)
    {

        var options = new DbContextOptionsBuilder<HalhatatlanContext>()

        .UseInMemoryDatabase(dbName)

        .Options;


        return new HalhatatlanContext(options);

    }

}
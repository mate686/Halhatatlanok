using Halhatatlanok.Models;
using Halhatatlanok.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halhatalanok.Test.Queries
{
    public class Feladat5Test
    {
        [Fact]
        public void Feladat5_Teszt()
        {
            var context = TestDbFactory.CreateContext(nameof(Feladat5_Teszt));

            var szinesz = new Kategoriak { Nev = "színész" };
            var iro = new Kategoriak { Nev = "író" };

            context.Tagok.AddRange(
                new Tagok { Nev = "A", Kategoria = szinesz },
                new Tagok { Nev = "B", Kategoria = szinesz },
                new Tagok { Nev = "C", Kategoria = iro }
            );

            context.SaveChanges();

            var service = new LekerdezesiFeladatok(context);

            var result = service.Feladat5();

            var szineszSor = result.First(x => x.FoglalkozasNeve == "színész");
            var iroSor = result.First(x => x.FoglalkozasNeve == "író");

            Assert.Equal(2, szineszSor.DB);
            Assert.Equal(1, iroSor.DB);
        }
    }
}

using Halhatatlanok.Models;
using Halhatatlanok.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halhatalanok.Test.Queries
{
    public class Feladat3Test
    {
        [Fact]
        public void Feladat3_Teszt()
        {
            var context = TestDbFactory.CreateContext(nameof(Feladat3_Teszt));

            var szinesz = new Kategoriak { Nev = "színész" };
            var iro = new Kategoriak { Nev = "író" };

            context.Tagok.AddRange(
                new Tagok { Nev = "Bodrogi Gyula", Kategoria = szinesz },
                new Tagok { Nev = "Zenthe Ferenc", Kategoria = szinesz },
                new Tagok { Nev = "Gárdonyi Géza", Kategoria = iro }
            );
            context.SaveChanges();

            var service = new LekerdezesiFeladatok(context);

            var result = service.Feladat3();

            Assert.Equal(2, result.Count);
            Assert.All(result, x => Assert.Contains("színész", x.FoglalkozasMeg));
        }
    }
}

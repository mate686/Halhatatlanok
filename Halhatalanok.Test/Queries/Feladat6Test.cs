using Halhatatlanok.Models;
using Halhatatlanok.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halhatalanok.Test.Queries
{
    public class Feladat6Test
    {
        [Fact]
        public void Feladat6_Teszt()
        {
            var context = TestDbFactory.CreateContext(nameof(Feladat6_Teszt));

            var szinesz = new Kategoria { Nev = "színész" };

            context.Tagok.AddRange(
                new Tag { Nev = "Zenthe Ferenc", Ev = 1960, Kategoria = szinesz },
                new Tag { Nev = "Bodrogi Gyula", Ev = 1960, Kategoria = szinesz },
                new Tag { Nev = "Latinovits Zoltán", Ev = 1970, Kategoria = szinesz }
            );

            context.SaveChanges();

            var service = new LekerdezesiFeladatok(context);

            var result = service.Feladat6();

            Assert.Equal(2, result.Count);
            Assert.All(result, x => Assert.Equal(1960, x.Ev));
            Assert.Contains(result, x => x.Nev == "Zenthe Ferenc");
        }
    }
}

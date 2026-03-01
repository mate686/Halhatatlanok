using Halhatatlanok.Models;
using Halhatatlanok.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halhatalanok.Test.Queries
{
    public class Feladat4Test
    {
        [Fact]
        public void Feladat4_Teszt()
        {
            var context = TestDbFactory.CreateContext(nameof(Feladat4_Teszt));
            var kat = new Kategoria { Nev = "színész" };

     
            for (int i = 1; i <= 9; i++)
                context.Tagok.Add(new Tag { Nev = "Színész" + i, Ev = 2000, Kategoria = kat });

      
            for (int i = 1; i <= 3; i++)
                context.Tagok.Add(new Tag { Nev = "X" + i, Ev = 1990, Kategoria = kat });

            context.SaveChanges();

            var service = new LekerdezesiFeladatok(context);

            var result = service.Feladat4();

            Assert.Single(result);            
            Assert.True(result.ContainsKey(2000));
            Assert.Equal(9, result[2000]);
        }
    }
}

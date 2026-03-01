using Halhatatlanok.Controllers;
using Halhatatlanok.Models;
using Halhatatlanok.Services;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halhatalanok.Test.Queries
{
    public class Feladat2Tests  
    {
        [Fact]
        public void Feladat2_Teszt()
        {
        
            var context = TestDbFactory.CreateContext(nameof(Feladat2_Teszt));

            context.Tagok.AddRange(
                new Tag { Id = 1, Nev = "Béla", Ev = 2022 },
                new Tag { Id = 2, Nev = "Anna", Ev = 2022 },
                new Tag { Id = 3, Nev = "Cecil", Ev = 2021 }
            );

            context.SaveChanges();
            
            var service = new LekerdezesiFeladatok(context);



            //var controller = new FeladatController(context);

         
            /*var result = service.Feladat2() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var model = Assert.IsType<List<Tag>>(result.Model);

            Assert.Equal(2, model.Count);

            Assert.Equal("Anna", model[0].Nev);
            Assert.Equal("Béla", model[1].Nev);

            Assert.All(model, t => Assert.Equal(2022, t.Ev));*/
            var result = service.Feladat2().ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("Anna", result[0].Nev);
            Assert.Equal("Béla", result[1].Nev);


        }
    }
}

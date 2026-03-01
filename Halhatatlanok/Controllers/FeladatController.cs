using Halhatatlanok.Data;
using Halhatatlanok.Models;
using Halhatatlanok.Services;
using Halhatatlanok.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Halhatatlanok.Controllers
{
    public class FeladatController : Controller
    {
        private HalhatatlanContext _conn;
        private ILekerdezesiFeladatok _queries;

        public FeladatController(HalhatatlanContext conn, ILekerdezesiFeladatok queries)
        {
            _conn = conn;
            _queries = queries;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Feladat2()
        {
            //List<Tag> tagok = new List<Tag>(_conn.Tagok.Where(x => x.Ev == 2022).OrderBy(x => x.Nev).ToList());

           var result = _queries.Feladat2();

            return View(result);
        }

        public IActionResult Feladat3()
        {
            /*List<Foglalkozas> szineszek = _conn.Tagok
            .Where(t => t.Kategoria.Nev.Contains("színész"))
            .Select(t => new Foglalkozas
            {
                Nev = t.Nev,
                FoglalkozasMeg = t.Kategoria.Nev
            })
            .ToList();*/

            var result = _queries.Feladat3();

            return View(result);
        }

        public IActionResult Feladat4()
        {
           /*Dictionary<int, int> szotar = new Dictionary<int, int>(_conn.Tagok.GroupBy(k => k.Ev).ToDictionary(
               t => t.Key,
               t => t.Count()
               ));

            foreach(KeyValuePair<int,int> k in szotar)
            {
                if (!(k.Value > 8))
                {
                    szotar.Remove(k.Key);
                }
            }*/
             var szotar = _queries.Feladat4();



            return View(szotar);
        }

        public IActionResult Feladat5()
        {
            //List<Feladat5Model> lista = _conn.Tagok.G

            /*List<Feladat5Model> szineszek = _conn.Tagok
            .Select(t => new Feladat5Model
            {
                FoglalkozasNeve = t.Kategoria.Nev,
                DB = t.Ev
            })
            .ToList();*/


            /*var szotar = _conn.Tagok.GroupBy(k => k.Kategoria.Id).ToDictionary(
                t => t.Key,
                t => t.Count()
                );*/

            /*List<Feladat5Model> lista = new List<Feladat5Model> (_conn.Tagok.GroupBy(k => k.Kategoria.Nev).Select(t => new Feladat5Model
            {
                FoglalkozasNeve = t.Key,
                DB = t.Count()
            }));*/

            var lista = _queries.Feladat5();

            return View(lista);
        }

        public IActionResult Feladat6()
        {

<<<<<<< HEAD
            /*int ev = _conn.Tagok.Where(t => t.Nev == "Zenthe Ferenc").Select(t => t.Ev).FirstOrDefault();


            List<Feladat6Model> lista = new List<Feladat6Model>(_conn.Tagok.Where(t => t.Ev == ev).Select(t => 
=======
            int ev = _conn.Tagok.Where(t => t.Nev == "Zenthe Ferenc").Select(t=> t.Ev).FirstOrDefault();

            List<Feladat6Model> lista = new List<Feladat6Model>(_conn.Tagok.Where(t => t.Ev == ev).Select(t => 

>>>>>>> 648099a5d7cef17714c5b531255a43e27b42c3da
            new Feladat6Model
            {
                Foglalkozas = t.Kategoria.Nev,
                Nev = t.Nev,
                Ev = t.Ev
            }));*/
             var lista = _queries.Feladat6();

            return View(lista);
        }
    }
}

using Halhatatlanok.Data;
using Halhatatlanok.Models;
using Halhatatlanok.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Halhatatlanok.Controllers
{
    public class FeladatController : Controller
    {
        private HalhatatlanContext _conn;

        public FeladatController(HalhatatlanContext conn)
        {
            _conn = conn;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Feladat2()
        {
            List<Tag> tagok = new List<Tag>(_conn.Tagok.Where(x => x.Ev == 2022).OrderBy(x => x.Nev).ToList());

           

            return View(tagok);
        }

        public IActionResult Feladat3()
        {
            List<Foglalkozas> szineszek = _conn.Tagok
            .Where(t => t.Kategoria.Nev.Contains("színész"))
            .Select(t => new Foglalkozas
            {
                Nev = t.Nev,
                FoglalkozasMeg = t.Kategoria.Nev
            })
            .ToList();


            return View(szineszek);
        }

        public IActionResult Feladat4()
        {
           Dictionary<int, int> szotar = new Dictionary<int, int>(_conn.Tagok.GroupBy(k => k.Ev).ToDictionary(
               t => t.Key,
               t => t.Count()
               ));

            foreach(KeyValuePair<int,int> k in szotar)
            {
                if (!(k.Value > 8))
                {
                    szotar.Remove(k.Key);
                }
            }

           

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

            List<Feladat5Model> lista = new List<Feladat5Model> (_conn.Tagok.GroupBy(k => k.Kategoria.Nev).Select(t => new Feladat5Model
            {
                FoglalkozasNeve = t.Key,
                DB = t.Count()
            }));

            return View(lista);
        }

        public IActionResult Feladat6()
        {
            int ev = _conn.Tagok.Where(t => t.Nev == "Zenthe Ferenc").Select(t => t.Ev).FirstOrDefault();

            List<Feladat6Model> lista = new List<Feladat6Model>(_conn.Tagok.Where(t => t.Ev == ev).Select(t =>
            new Feladat6Model
            {
                Foglalkozas = t.Kategoria.Nev,
                Nev = t.Nev,
                Ev = t.Ev
            }));

            return View(lista);
        }
    }
}

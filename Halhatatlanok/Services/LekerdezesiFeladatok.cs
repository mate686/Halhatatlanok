using Halhatatlanok.Data;
using Halhatatlanok.Models;
using Halhatatlanok.ViewModels;

namespace Halhatatlanok.Services
{
    public class LekerdezesiFeladatok : ILekerdezesiFeladatok
    {
        private readonly HalhatatlanContext _context;

        public LekerdezesiFeladatok(HalhatatlanContext context) => _context = context;


        /*public IQueryable<string> SomogyTelepulesNevek()

            => _context.Telepulesek

            .Where(t => t.Varmegye == "Somogy")

            .OrderBy(t => t.Nev)

            .Select(t => t.Nev);*/

        public List<Tag> Feladat2()
        {

            List<Tag> tagok = new List<Tag>(_context.Tagok.Where(x => x.Ev == 2022).OrderBy(x => x.Nev).ToList());


            return tagok;
        }

        public List<Foglalkozas> Feladat3()
        {
            List<Foglalkozas> szineszek = _context.Tagok
            .Where(t => t.Kategoria.Nev.Contains("színész"))
            .Select(t => new Foglalkozas
            {
                Nev = t.Nev,
                FoglalkozasMeg = t.Kategoria.Nev
            })
            .ToList();

            return szineszek;
        }

        public Dictionary<int, int> Feladat4()
        {
            /*Dictionary<int, int> szotar = new Dictionary<int, int>(_context.Tagok.GroupBy(k => k.Ev).ToDictionary(
               t => t.Key,
               t => t.Count()
               ));

            foreach (KeyValuePair<int, int> k in szotar)
            {
                if (!(k.Value > 8))
                {
                    szotar.Remove(k.Key);
                }
            }

            return szotar;*/

            return _context.Tagok
           .ToList()                
           .GroupBy(t => t.Ev)
           .Where(g => g.Count() > 8)
           .ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Feladat5Model> Feladat5()
        {
            List<Feladat5Model> lista = new List<Feladat5Model>(_context.Tagok.GroupBy(k => k.Kategoria.Nev).Select(t => new Feladat5Model
            {
                FoglalkozasNeve = t.Key,
                DB = t.Count()
            }));

            return lista;
        }

        public List<Feladat6Model> Feladat6()
        {
            int ev = _context.Tagok.Where(t => t.Nev == "Zenthe Ferenc").Select(t => t.Ev).FirstOrDefault();


            List<Feladat6Model> lista = new List<Feladat6Model>(_context.Tagok.Where(t => t.Ev == ev).Select(t =>
            new Feladat6Model
            {
                Foglalkozas = t.Kategoria.Nev,
                Nev = t.Nev,
                Ev = t.Ev
            }));

            return lista;
        }
    }

}

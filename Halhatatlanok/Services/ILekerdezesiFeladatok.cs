using Halhatatlanok.Models;
using Halhatatlanok.ViewModels;

namespace Halhatatlanok.Services
{
    public interface ILekerdezesiFeladatok
    {
        List<Tag> Feladat2();

        List<Foglalkozas> Feladat3();

        Dictionary<int, int> Feladat4();

        List<Feladat5Model> Feladat5();

        List<Feladat6Model> Feladat6();


    }
}

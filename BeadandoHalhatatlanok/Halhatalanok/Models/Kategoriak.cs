using System.ComponentModel.DataAnnotations.Schema;

namespace Halhatatlanok.Models
{
    [Table("kategoriak")]
    public class Kategoriak
    {
        public int Id { get; set; }
        public string Nev { get; set; }
    }
}

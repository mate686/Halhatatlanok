using System.ComponentModel.DataAnnotations.Schema;

namespace Halhatatlanok.Models
{
    [Table("kategoria")]
    public class Kategoria
    {
        public int Id { get; set; }
        public string Nev { get; set; }
    }
}

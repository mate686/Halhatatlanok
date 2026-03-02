using System.ComponentModel.DataAnnotations.Schema;

namespace Halhatatlanok.Models
{
    [Table("tagok")]
    public class Tagok
    {
        public int Id { get; set; }

        public int Ev { get; set; }


        [Column("KategoriaId")]
        public int KategoriaId { get; set; }
        public Kategoriak Kategoria { get; set; }
        public string Nev { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Halhatatlanok.Models
{
    [Table("tag")]
    public class Tag
    {
        public int Id { get; set; }

        public int Ev { get; set; }


        [Column("katid")]
        public int KategoriaId { get; set; }
        public Kategoria Kategoria { get; set; }
        public string Nev { get; set; }
    }
}

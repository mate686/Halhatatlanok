namespace Halhatatlanok.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public int Ev { get; set; }
        public int KategoriaId { get; set; }
        public Kategoria Kategoria { get; set; }
        public string Nev { get; set; }
    }
}

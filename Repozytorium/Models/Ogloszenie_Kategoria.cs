namespace Repozytorium.Models
{
    public class Ogloszenie_Kategoria
    {
        public Ogloszenie_Kategoria()
        {

        }
        public int Id { get; set; }
        public int KategoriaId { get; set; }
        public int OgloszenieId { get; set; }
        public virtual Kategoria Kategoria { get; set; }
        public virtual Ogloszenie Ogloszenie { get; set; }
    }
}
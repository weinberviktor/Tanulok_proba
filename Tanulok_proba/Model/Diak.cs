using System.ComponentModel.DataAnnotations;

namespace Tanulok_proba.Model
{
    public class Diak
    {
        public int Id { get; set; }
        [Required]
        public string Nev { get; set; }
        public ICollection<TanarDiak> TanarDiak { get; set; }
    }
}

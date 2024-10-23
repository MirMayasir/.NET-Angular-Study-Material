using System.ComponentModel.DataAnnotations;

namespace CodeFirstApporach.Models
{
    public class Supplierscs
    {
        [Key]
        public int Sid {  get; set; }
        public string Sname { get; set; }

        public string Location { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}

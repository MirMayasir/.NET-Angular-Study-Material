using System.ComponentModel.DataAnnotations;

namespace CodeFirstApporach.Models
{
    public class Product
    {
        [Key]

        public int Pid {  get; set; }
        public string Pname { get; set; }

        public string Desc { get; set; }

        public int Priced { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Security.Cryptography;

namespace CodeFirstApporach.Models
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage ="name is mendotery")]
        public string Ename { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="enter valit number", MinimumLength =10)]
        public string Enumber { get; set; }

        [Range(0, 40000, ErrorMessage ="salary should be between 0 to 40000")]
        public string Esalary {  get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }


        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        private string _password;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }

        /*[Compare("Password", ErrorMessage = "password did not match")]*/
        [NotMapped]
        public string confirmPassword { get; set; }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace UCAKBİLETİ.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }

        [StringLength(50)]
        public string? CustomerSurname { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }

        // Şifreyi hash'lemek için bir metod
        public void SetPassword(string password)
        {
            // Şifreyi bcrypt ile şifreliyoruz
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Şifrenin doğruluğunu kontrol etmek için bir metod
        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}

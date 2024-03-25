using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPrpject1.Models
{
    public class Jsregister
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public string Country { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    [NotMapped]
    public string ImageData { get; set; }
        public string Address { get; set; }
    }
}


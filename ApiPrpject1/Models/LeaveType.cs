
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ApiPrpject1.Models
{
    public class LeaveType
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int DefaultDays { get; set; }
    }
}

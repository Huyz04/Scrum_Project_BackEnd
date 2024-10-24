using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScrumBackEnd.Model
{
    [Table("Userr")]
    public class Userr
    {
        [Key]
        public string UserName { get; set; } 
        public string Password { get; set; } = "1";
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Class { get; set; }
        public  string Role { get; set; }
    }
}

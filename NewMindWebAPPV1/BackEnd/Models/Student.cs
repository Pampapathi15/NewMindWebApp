using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Student
    {

        [Key]

        public Guid id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int age { get; set; }


        [Required]
        public long PhoneNumber { get; set; }

        [Required]
        public string? Addres { get; set; }
    }
}

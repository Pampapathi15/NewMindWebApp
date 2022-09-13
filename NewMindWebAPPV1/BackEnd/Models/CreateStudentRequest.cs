namespace BackEnd.Models
{
    public class CreateStudentRequest
    {
        public Guid id { get; set; }


        public string Name { get; set; }


        public int age { get; set; }


        public long PhoneNumber { get; set; }


        public string? Addres { get; set; }
    }
}

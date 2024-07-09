namespace Student_registration_mvc_with_entity.Models
{
    public class AddStudentViewModel
    {
        public Guid ID { get; set; }

        public string Name { get; set; } = "";

        public string Surname { get; set; } = "";

        public string Email { get; set; } = "";

        public int PhoneNumber { get; set; }

        public Guid StudentId { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}

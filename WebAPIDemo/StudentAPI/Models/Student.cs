using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int age{ get; set; }
        [Range(1,5)]
        public int TotalMarks { get; set; }
    }
}

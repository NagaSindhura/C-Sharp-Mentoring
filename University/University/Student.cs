using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        [ForeignKey("Semister")]
        public int SemisterId { get; set; }


        [ForeignKey("University")]
        public int UniversityId { get; set; }

        public virtual Semister Semister { get; set; }

        public virtual University University { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Mark
    {
        [Key]
        public int MarksId { get; set; }

        public int Score { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }


        [ForeignKey("Semister")]
        public int SemisterId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }


        public virtual Student Student { get; set; }

        public virtual Semister Semister { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        [ForeignKey("Semister")]
        public int SemisterId { get; set; }

        public virtual Semister Semister { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        public string UniversityName { get; set; }
    }
}
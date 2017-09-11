using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Semister
    {
        [Key]
        public int SemisterId { get; set; }

        public string SemisterName { get; set; }
    }
}
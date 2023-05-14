using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonAPI.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("Persons")]
        public int? FK_PersonId { get; set; } = null;
        public Person Persons { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}

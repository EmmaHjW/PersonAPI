using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        [Required]
        public string LinkName { get; set; }
        public string URL { get; set; }
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        public Interest Interests { get; set; }
    }
}

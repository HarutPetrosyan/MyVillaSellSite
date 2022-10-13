using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaApi.Models
{
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int VillaNo { get; set; }
        [Required]
        
        [ForeignKey("Villa")]
        public int VillaId { get; set; }

        public Villa Villa { get; set; }
        public string  SpetialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaApi.Models.DTO
{
    public class VillaNumberCreatedDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpetialDetails { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace AtlasApis.Models
{
    public class AtlasPhoto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        public string Title { get; set; }

        public string Photographer { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        public string ImageUrl { get; set; }
    }
}

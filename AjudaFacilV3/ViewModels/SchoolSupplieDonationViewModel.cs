using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.ViewModels;

public class SchoolSupplieDonationViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "school supplie donation";

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Descreva a sua doação")]
    public string Description { get; set; }

    [DisplayName("Peso")]
    [Required(ErrorMessage = "Informe o peso estimado.")]
    public int Weight { get; set; }

    [DisplayName("Imagem")]
    [Required(ErrorMessage = "Envie uma foto da doação")]
    public IFormFile Base64Image { get; set; } 
    
}

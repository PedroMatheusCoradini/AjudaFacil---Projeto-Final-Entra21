using Microsoft.AspNetCore.Mvc.Rendering;
using System.Buffers.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AjudaFacilV3.ViewModels;

public class SchoolSupplieDonationViewModel
{
    public int Id { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Descreva a sua doação")]
    public string Description { get; set; }

    [DisplayName("Peso")]
    [Required(ErrorMessage = "Informe o peso estimado.")]
    public int Weight { get; set; }

    [DisplayName("Imagem")]
    [Required(ErrorMessage = "Envie uma foto da doação")]
    public string Base64Image { get; set; } 
    
}

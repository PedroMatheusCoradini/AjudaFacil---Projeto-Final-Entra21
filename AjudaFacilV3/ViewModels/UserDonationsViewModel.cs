using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.ViewModels;

public class UserDonationsViewModel
{
    public int Id { get; set; }

    [DisplayName("Tipo de doação.")]
    public string Name { get; set; }

    [DisplayName("Data da doação")]
    public DateTime CreateAt { get; set; }

    [Required(ErrorMessage = "Informe a quantidade estimada de peças de roupa.")]
    public int QuantityOfClothes { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Descreva um pouco sua doação.")]
    public string Description { get; set; }

    [DisplayName("Peso em KG")]
    [Required(ErrorMessage = "Informe o peso estimado da sua doação.")]
    public int Weight { get; set; }

    [DisplayName("Imagem")]
    [Required(ErrorMessage = "Adicione uma imagem da sua doação")]
    public string Image { get; set; }

    [DisplayName("E-mail do Doador")]
    public string User { get; set; } = string.Empty;
}

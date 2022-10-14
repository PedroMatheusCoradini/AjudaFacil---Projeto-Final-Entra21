using AjudaFacilV3.Models;
using System.ComponentModel;

namespace AjudaFacilV3.ViewModels;

public class UserDonationsViewModel
{
    public int Id { get; set; }
    [DisplayName("Data da doação")]
    public DateTime CreateAt { get; set; }
    public int QuantityOfClothes { get; set; }

    [DisplayName("Descrição")]
    public string Description { get; set; }

    [DisplayName("Peso")]
    public int Weight { get; set; }

    [DisplayName("Imagem")]
    public string Image { get; set; }

    [DisplayName("Doador")]
    public string User { get; set; } = string.Empty;
}

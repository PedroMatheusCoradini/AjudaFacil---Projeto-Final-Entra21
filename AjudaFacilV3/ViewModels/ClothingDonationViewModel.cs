using AjudaFacilV3.Models;

namespace AjudaFacilV3.ViewModels;

public class ClothingDonationViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "clothing donation";
    public int QuantityOfClothes { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public IFormFile Base64Image { get; set; }
}

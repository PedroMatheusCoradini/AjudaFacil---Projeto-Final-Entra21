﻿namespace AjudaFacil.Models;

public class ClothingDonation
{
    public int Id { get; set; }
    public int QuantityOfClothes { get; set; }
    public string DescriptionOfClothes { get; set; }
    public int Weight { get; set; }
    public string Image { get; set; }
    public Donation Donations { get; set; }
}

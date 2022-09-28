using AjudaFacil.Data;
using AjudaFacil.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjudaFacil.Services;

public class SchoolSupplieDonationService
{
    public async Task InsertAsync([FromServices] DataContext context,SchoolSupplieDonation donation)
    {
        context.Add(donation);
        await context.SaveChangesAsync();
    }
}

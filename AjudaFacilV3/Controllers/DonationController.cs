using AjudaFacilV3.Data;
using AjudaFacilV3.Models;
using AjudaFacilV3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System;

namespace AjudaFacilV3.Controllers;

[Authorize]
public class DonationController : Controller
{
    private readonly ApplicationDbContext _context;

	public DonationController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult CreateClothingDonation()
	{
		return View();
	}

	public IActionResult CreateSchoolSupplieDonation()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSchoolSupplieDonation([Bind("Id,Description,Weight,Base64Image,User")] SchoolSupplieDonationViewModel donation)
    {
        /*// salvar a imagen da doação do usuario para poder acessar depois
        var fileName = $"{Guid.NewGuid().ToString()}.jpg";
        //var data = donation.Base64Image.Substring(donation.Base64Image.LastIndexOf(',') + 1);
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(donation.Base64Image, "");
        byte[] bytes = Convert.FromBase64String(data);

        try
        {
            await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }*/

        /*try
        {
            await System.IO.File.WriteAllLinesAsync($"wwwroot/img/{donation.Base64Image}");
        }
        catch (Exception)
        {
            return StatusCode(500);
        }*/

        if (ModelState.IsValid)
		{
            var schoolSupplieDonation = new SchoolSupplieDonation
            {
                Id = donation.Id,
                Description = donation.Description,
                Weight = donation.Weight,
                Image = donation.Base64Image,
                Donations = new Donation
                {
                    Id = donation.Id,
                    CreateAt = DateTime.Now,
                    User = User.Identity.Name
                }
            };
            _context.Add(schoolSupplieDonation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CreateSchoolSupplieDonation));
        }

        return View(donation);
    }

    
    public async Task<IActionResult> DetailsDonation()
    {
        return _context.SchoolSupplieDonations != null ?
            View(await _context.SchoolSupplieDonations
            .AsNoTracking()
            .Include(x => x.Donations)
            .Where(x => x.Donations.User == User.Identity.Name)
            .Select(x => new UserDonationsViewModel
            {
                Id = x.Id,
                CreateAt = x.Donations.CreateAt,
                Description = x.Description,
                Weight = x.Weight,
                Image = x.Image,
                User = x.Donations.User
            })
            .ToListAsync()) :
            Problem("Não encontramos nenhuma doação!");
    }
}

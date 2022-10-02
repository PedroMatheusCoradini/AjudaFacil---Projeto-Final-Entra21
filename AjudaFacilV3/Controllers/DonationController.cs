using AjudaFacilV3.Data;
using AjudaFacilV3.Models;
using AjudaFacilV3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> CreateSchoolSupplieDonation([Bind("Id,Description,Weight,Image,User")] SchoolSupplieDonationViewModel donation)
    {
        SchoolSupplieDonation schoolSupplieDonation;

        if (ModelState.IsValid)
		{
            schoolSupplieDonation = new SchoolSupplieDonation
            {
                Id = donation.Id,
                Description = donation.Description,
                Weight = donation.Weight,
                Image = donation.Image,
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
}

using AjudaFacil.Data;
using AjudaFacil.Models;
using AjudaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace AjudaFacil.Controllers
{
    public class DonationsController : Controller
    {
        // retorna a primeira doacao de material escolar que encontrar
        [HttpGet, ActionName("GetAllSchoolSupplieDonation")]
        public IActionResult GetAllSchoolSupplieDonation([FromServices] DataContext context)
        {
            var result = context.SchoolSupplieDonation.FirstOrDefault();
            return View(result);
        }

        public IActionResult CreateSchoolSupplieDonation()
        {
            return View();
        }

        [HttpPost, ActionName("CreateSchoolSupplieDonation")]
        public IActionResult CreateSchoolSupplieDonation([FromServices] DataContext context, SchoolSupplieDonation schoolSupplieDonation)
        {
            var donation = context.Donation.FirstOrDefault(x => x.Id == 2);
            schoolSupplieDonation.Donations = donation;

            SchoolSupplieDonationService donationService = new SchoolSupplieDonationService();
            donationService.InsertAsync(context, schoolSupplieDonation);


            return RedirectToAction(nameof(CreateSchoolSupplieDonation));
        }
    }
}

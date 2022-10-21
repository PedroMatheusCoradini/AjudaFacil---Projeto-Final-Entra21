using Microsoft.AspNetCore.Mvc;
using AjudaFacilV3.Data;
using AjudaFacilV3.Models;

namespace AjudaFacilV3.Controllers;

public class InstitutionController : Controller
{
    private readonly ApplicationDbContext _context;

	public InstitutionController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult RegisterInstitution()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> RegisterInstitution(Institution model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		try
		{
			var createInstitution = new Institution
			{
				Id = model.Id,
				Name = model.Name,
				Email = model.Email,
				Address = model.Address,
				City = model.City,
				Site = model.Site,
				CNPJ = model.CNPJ,
				District = model.District,
				Phone = model.Phone,
			};

			_context.Institutions.Add(createInstitution);
			_context.SaveChanges();
            return RedirectToAction(nameof(RegisterInstitution));
        }
		catch (Exception)
		{
			return NotFound();
		}
	}
}

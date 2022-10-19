using AjudaFacilV3.Data;
using AjudaFacilV3.Models;
using AjudaFacilV3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AjudaFacilV3.Services;

namespace AjudaFacilV3.Controllers;

[Authorize]
public class UserProfileController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserProfileController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> UpdateProfile()
    {
        var userProfile = await _context.Profiles.AsNoTracking().FirstOrDefaultAsync(x => x.User == User.Identity.Name);

        if (userProfile == null)
        {
            return View(userProfile);
        }

        var userTotalDonationsResult = UserService.CountTotalDonations(_context, User.Identity.Name);

        userProfile.TotalDonation = userTotalDonationsResult;

        return View(userProfile);

        //=====================

        /*var userTotalDonationsResult = UserService.CountTotalDonations(_context, User.Identity.Name);

        return _context.Profiles != null ?
            View(await _context.Profiles
            .AsNoTracking()
            .Where(x => x.TotalDonation == userTotalDonationsResult)
            .FirstOrDefaultAsync(x => x.User == User.Identity.Name)) :
            Problem("Você ainda não atualizou o seu perfil.");*/
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProfile(UserProfile userProfile)
    {
        try
        {
            UserProfile informacoesDoUser = await _context.Profiles.FirstOrDefaultAsync(x => x.User == User.Identity.Name);
            if (informacoesDoUser == null)
            {
                UserProfile firstProfile = new UserProfile
                {
                    Id = userProfile.Id,
                    Name = userProfile.Name,
                    BirthDate = userProfile.BirthDate,
                    CPF = userProfile.CPF,
                    Adress = userProfile.Adress,
                    City = userProfile.City,
                    CEP = userProfile.CEP,
                    PhoneNumber = userProfile.PhoneNumber,
                    Sex = userProfile.Sex,
                    TotalDonation = UserService.CountTotalDonations(_context, User.Identity.Name),
                    User = User.Identity.Name
                };

                _context.Profiles.Add(firstProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DetailsProfile));
            }

            informacoesDoUser.Id = informacoesDoUser.Id;
            informacoesDoUser.Name = userProfile.Name;
            informacoesDoUser.BirthDate = userProfile.BirthDate;
            informacoesDoUser.CPF = userProfile.CPF;
            informacoesDoUser.Adress = userProfile.Adress;
            informacoesDoUser.City = userProfile.City;
            informacoesDoUser.CEP = userProfile.CEP;
            informacoesDoUser.PhoneNumber = userProfile.PhoneNumber;
            informacoesDoUser.Sex = userProfile.Sex;
            informacoesDoUser.TotalDonation = UserService.CountTotalDonations(_context, User.Identity.Name);
            informacoesDoUser.User = User.Identity.Name;

            _context.Update(informacoesDoUser);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return RedirectToAction(nameof(DetailsProfile));
    }


    [HttpGet]
    public async Task<IActionResult> DetailsProfile(int? id)
    {
        return _context.Profiles != null ?
            View(await _context.Profiles
            .AsNoTracking()
            .Select(x => new UserProfileViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Adress = x.Adress,
                City = x.City,
                BirthDate = x.BirthDate,
                CEP = x.CEP,
                CPF = x.CPF,
                PhoneNumber = x.PhoneNumber,
                Sex = x.Sex,
                TotalDonation = UserService.CountTotalDonations(_context, User.Identity.Name),
                User = x.User
            })
            .FirstOrDefaultAsync(x => x.User == User.Identity.Name)) :
            Problem("Você ainda não atualizou o seu perfil.");
    }


    private bool ProfileExists(int id)
    {
        return (_context.Profiles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

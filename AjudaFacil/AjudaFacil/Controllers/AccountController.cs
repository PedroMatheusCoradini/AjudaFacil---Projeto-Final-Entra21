using AjudaFacil.Data;
using AjudaFacil.Models;
using AjudaFacil.ViewModels.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace AjudaFacil.Controllers;

public class AccountController : Controller
{
    public IActionResult RegisterAccount()
    {
        return View();
    }

    [HttpPost, ActionName("RegisterAccount")]
    public async Task<IActionResult> RegisterAccount(RegisterViewModel model, [FromServices] DataContext context)
    {
        User user = new User
        {
            Name = model.Name,
            LastName = model.LastName,
            Email = model.Email,
            CPF = model.CPF,
            BirthDate = model.BirthDate,
            Adress = model.Adress,
            City = model.City,
            Password = model.Password
        };

        try
        {
            await context.User.AddAsync(user);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(RegisterAccount));
        }
        catch (Exception)
        {
            throw;
        }
    }
}

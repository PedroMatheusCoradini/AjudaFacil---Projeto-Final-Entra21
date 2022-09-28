using AjudaFacil.Data;
using AjudaFacil.Models;
using AjudaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace AjudaFacil.Controllers;

public class UserController : Controller
{
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost, ActionName("CreateUser")]
    public IActionResult CreateUser([FromServices] DataContext context, User user)
    {
        /*var usuario = new User
        {
            Name = user.Name,
            LastName = "coradini",
            Email = user.Email,
            Password = user.Password,
            BirthDate = DateTime.UtcNow,
            CPF = user.CPF,
            Adress = user.Adress,
            City = user.City,
            CNPJ = "n ha cnpj",
            Cep = 33222112,
            PhoneNumber = user.PhoneNumber,
            ResidentialPhone = "sem telefone residencial",
            Sex = "masculino",
            TotalDonations = 2
        };*/

        context.User.Add(user);
        context.SaveChanges();

        return RedirectToAction(nameof(CreateUser));
    }
}

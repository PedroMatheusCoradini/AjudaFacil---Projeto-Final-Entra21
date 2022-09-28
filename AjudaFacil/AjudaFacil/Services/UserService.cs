using AjudaFacil.Data;
using AjudaFacil.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjudaFacil.Services;

public class UserService
{
    public async Task InsertAsync([FromServices] DataContext context, User user)
    {
        context.User.Add(user);
        await context.SaveChangesAsync();
    }
}

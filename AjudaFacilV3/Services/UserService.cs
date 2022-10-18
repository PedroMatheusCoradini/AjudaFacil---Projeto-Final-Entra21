using Microsoft.AspNetCore.Mvc;
using AjudaFacilV3.Data;
using Microsoft.EntityFrameworkCore;

namespace AjudaFacilV3.Services;

public class UserService
{
    public static int CountTotalDonations([FromServices] ApplicationDbContext context, string user)
    {
        int totalDonations = context.Donations
            .AsNoTracking()
            .Where(x => x.User == user)
            .Count();

        return totalDonations;
    }
}

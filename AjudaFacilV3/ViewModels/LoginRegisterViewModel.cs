using AjudaFacilV3.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AjudaFacilV3.ViewModels
{
    public class LoginRegisterViewModel : PageModel
    {
        public LoginModel loginModel { get; set; }
        public RegisterModel registerModel { get; set; } = null;

        public LoginRegisterViewModel(LoginModel loginModel)
        {
            this.loginModel = loginModel;
        }

        public LoginRegisterViewModel(RegisterModel registerModel)
        {
            this.registerModel = registerModel;
        }
    }
}

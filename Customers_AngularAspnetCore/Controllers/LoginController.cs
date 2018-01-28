using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Customers_AngularAspnetCore.Services;

namespace Customers_AngularAspnetCore.Controllers
{
    [Route("api/[controller]")]
	public class LoginController : Controller {

		public LoginController() {
		}

        [HttpGet("[action]")]
        public string Get(string email, string password)
        {
            var service = new LoginService();
            var login = service.VerifyLoginUser(email, password);

            return JsonConvert.SerializeObject(login);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Customers_AngularAspnetCore.Services;
using Customers_AngularAspnetCore.ViewModel;

namespace Customers_AngularAspnetCore.Controllers
{
    [Route("api/[controller]")]
	public class CustomerController : Controller {

		public CustomerController() {
		}

        [HttpGet("[action]")]
        public string Get(LoginVM loginVM, CustomerVM model)
        {
            var service = new Service();
            var customers = service.GetCustomers(loginVM);

            if (model.HasFilter())
            {
                customers = service.ApplyFilters(model, customers);
            }

            return JsonConvert.SerializeObject(customers);
        }

        [HttpGet("[action]")]
        public string GetFilters()
        {
            var service = new Service();
            var genders = service.GetGenders();
            var cities = service.GetCities();
            var regions = service.GetRegions();
            var classifications = service.GetClassifications();
            var sellers = service.GetSellers();

            return JsonConvert.SerializeObject(new
            {
                genders,
                cities,
                regions,
                classifications,
                sellers
            });
        }

        //[HttpPost("[action]")]
        //public string Post([FromBody] Customer model) {
        //	int id = 0;
        //	if (model.Id == 0) {
        //		id = Util.NextId(sGKContex, "Customer");
        //		sGKContex.Customers.Add(new Customer() { Id = id, Name = model.Name });
        //	} else {
        //		id = model.Id;
        //		Customer cust = sGKContex.Customers.Where(x => x.Id == id).First();
        //		cust.Name = model.Name;
        //	}
        //	sGKContex.SaveChanges();
        //	model.Id = id;
        //	return JsonConvert.SerializeObject(model);
        //}

        //[HttpDelete]
        //public string Delete(int id) {
        //	Customer cust = sGKContex.Customers.Where(x => x.Id == Convert.ToInt32(id)).First();
        //	sGKContex.Customers.Remove(cust);
        //	sGKContex.SaveChanges();
        //	return "";
        //}

    }
}

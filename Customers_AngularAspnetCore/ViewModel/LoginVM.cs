using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_AngularAspnetCore.ViewModel
{
    public class LoginVM
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
    }
}

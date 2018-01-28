using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_AngularAspnetCore.ViewModel
{
    public class CustomerVM
    {
        public string Classification { get; set; }
        public int ClassificationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int GenderId { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }
        public string LastPurchase { get; set; }
        public string Seller { get; set; }
        public int SellerId { get; set; }

        public bool HasFilter()
        {
            if (!string.IsNullOrEmpty(Classification)) return true;
            if (!string.IsNullOrEmpty(Name)) return true;
            if (!string.IsNullOrEmpty(Gender)) return true;
            if (!string.IsNullOrEmpty(City)) return true;
            if (!string.IsNullOrEmpty(Region)) return true;
            if (!string.IsNullOrEmpty(Seller)) return true;

            return false;
        }
    }
}

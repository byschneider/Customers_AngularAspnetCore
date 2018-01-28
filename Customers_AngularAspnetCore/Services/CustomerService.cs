using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Customers_AngularAspnetCore.DataModel;
using Customers_AngularAspnetCore.ViewModel;

namespace Customers_AngularAspnetCore.Services
{
    public class Service
    {
        public List<CustomerVM> GetCustomers(LoginVM login)
        {
            var customers = new List<CustomerVM>();

            try
            {
                using (var db = new ContextDB())
                {
                    customers = (from c   in db.Customer
                                 join cla in db.Classification on c.ClassificationId equals cla.Id
                                 join g   in db.Gender         on c.GenderId         equals g.Id
                                 join ci  in db.City           on c.CityId           equals ci.Id
                                 join r   in db.Region         on c.RegionId         equals r.Id
                                 join u   in db.UserSys        on c.UserId           equals u.Id
                                 where (login.IsAdmin || c.UserId == login.Id)
                                 select new CustomerVM
                                 {
                                     Classification = cla.Name,
                                     ClassificationId = cla.Id,
                                     Name = c.Name,
                                     Phone = c.Phone,
                                     Gender = g.Name,
                                     GenderId = g.Id,
                                     City = ci.Name,
                                     CityId = ci.Id,
                                     Region = r.Name,
                                     RegionId = r.Id,
                                     LastPurchase = c.LastPurchase.HasValue ? c.LastPurchase.Value.ToShortDateString() : "",
                                     Seller = u.Login,
                                     SellerId = u.Id
                                 }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public List<CustomerVM> ApplyFilters(CustomerVM model, List<CustomerVM> listCustomers)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    listCustomers = listCustomers.Where(x => x.Name.ToLower().Contains(model.Name.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(model.Gender))
                {
                    listCustomers = listCustomers.Where(x => x.GenderId == Convert.ToInt32(model.Gender)).ToList();
                }
                if (!string.IsNullOrEmpty(model.City))
                {
                    listCustomers = listCustomers.Where(x => x.CityId == Convert.ToInt32(model.City)).ToList();
                }
                if (!string.IsNullOrEmpty(model.Region))
                {
                    listCustomers = listCustomers.Where(x => x.RegionId == Convert.ToInt32(model.Region)).ToList();
                }
                if (!string.IsNullOrEmpty(model.Classification))
                {
                    listCustomers = listCustomers.Where(x => x.ClassificationId == Convert.ToInt32(model.Classification)).ToList();
                }
                if (!string.IsNullOrEmpty(model.Seller))
                {
                    listCustomers = listCustomers.Where(x => x.SellerId == Convert.ToInt32(model.Seller)).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return listCustomers;
        }

        public List<SelectListItem> GetGenders()
        {
            var list = new List<SelectListItem>();

            try
            {
                using (var db = new ContextDB())
                {
                    list = db.Gender.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public List<SelectListItem> GetCities()
        {
            var list = new List<SelectListItem>();

            try
            {
                using (var db = new ContextDB())
                {
                    list = db.City.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public List<SelectListItem> GetRegions()
        {
            var list = new List<SelectListItem>();

            try
            {
                using (var db = new ContextDB())
                {
                    list = db.Region.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public List<SelectListItem> GetClassifications()
        {
            var list = new List<SelectListItem>();

            try
            {
                using (var db = new ContextDB())
                {
                    list = db.Classification.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public List<SelectListItem> GetSellers()
        {
            var list = new List<SelectListItem>();

            try
            {
                using (var db = new ContextDB())
                {
                    list = (from u in db.UserSys
                            join ur in db.UserRole on u.UserRoleId equals ur.Id
                            where !ur.IsAdmin
                            select new SelectListItem
                            {
                                Text = u.Login,
                                Value = u.Id.ToString()
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi03_01_NorthWind.Models;

namespace WebApi03_01_NorthWind.Controllers
{
    public class CustomerController : ApiController
    {
        //public IEnumerable<CustomerModel> Get()
        //{
        //    //list customerID
        //    CustomerModels lesCustomers = new CustomerModels();
        //    return lesCustomers.LesCustomers;
        //}
        public IEnumerable<object> Get()
        {
            //list customerID
            CustomerModels lesCustomers = new CustomerModels();
            return lesCustomers.LesCustomers
                .Select(c=> new {id = c.IdM, nom = c.NomM, compagny =c.CompagnyM })
                .ToList();
        }
        [HttpGet]
        public string Get(string id)
        {
            //list customerID
            CustomerModels lesCustomers = new CustomerModels();
            return lesCustomers.LesCustomers
                .Select(c=>c.IdM)
                .Where(d => d == id)
                .ToList()
                .FirstOrDefault() ;
        }
    }
}

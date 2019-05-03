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
        public HttpResponseMessage Post(CustomerModel model)
        {
            //list customerID
            try
            {
                if (model == null || string.IsNullOrEmpty(model.IdM) || string.IsNullOrEmpty(model.CompagnyM))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "probleme de donnees");
                }
                model.CreateCustomer();
                return Request.CreateResponse(model);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
        }
        public HttpResponseMessage Delete(string id)
        {
            //list customerID
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "probleme de donnees");
                }
                new CustomerModel().DeleteCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }
    }
}

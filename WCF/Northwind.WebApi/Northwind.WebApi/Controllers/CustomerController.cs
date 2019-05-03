using Northwind.Data;
using Northwind.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        public IList<CustomerModel> Get()
        {
            using (var context = new NorthWindDbContext())
            {
                return context.Customers    
                    .Select(c => new CustomerModel
                    {
                        CustomerID = c.CustomerID,
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName
                    }).ToList();
            }

            //var c = new CustomerModel();
            //c.ContactName = "fff";

            //var d = new CustomerModel { ContactName = "rurur" };

        }
        public HttpResponseMessage Get(string customerId)
        {
            using (var context = new NorthWindDbContext())
            {
                var entity =  context.Customers.Where(c => c.CustomerID == customerId);
                if(entity.Any())
                {
                    var res = entity.Select(c => new CustomerModel
                    {
                        CompanyName = c.CompanyName,
                        ContactName = c.ContactName
                    }).FirstOrDefault();

                    return Request.CreateResponse(HttpStatusCode.Found, res);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Customer pas trouvé");
            }
           
        }


        public HttpResponseMessage Post([FromBody]CustomerModel customerModel)
        {
            try
            {
                if (customerModel == null || String.IsNullOrEmpty(customerModel.CustomerID) || String.IsNullOrEmpty(customerModel.CompanyName))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Les valeurs passées dans le modèles sont invalides");

                using (var context = new NorthWindDbContext())
                {
                    var customer = new Customers();
                    customer.CustomerID = customerModel.CustomerID;
                    customer.CompanyName = customerModel.CompanyName;
                    customer.ContactName = customerModel.ContactName;
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return Request.CreateResponse(customerModel);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(string customerId)
        {
            using (var context = new NorthWindDbContext())
            {
                var entity = context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
                if (entity != null)
                {
                    context.Customers.Remove(entity);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Found,"Customer supprimé avec succès");
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Customer pas trouvé");
            }

        }

    }
}

using ClassDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi03_01_Data;

namespace WebApi03_01_NorthWind.Models
{
    public class CustomerModel
    {
        public string IdM { get; set; }
        public string NomM { get; set; }
        public string CompagnyM { get; set; }
        private RepoData repo = new RepoData();

        public void CreateCustomer()
        {
            CustomerDTO cusDto = new CustomerDTO
            {
                IdDto = IdM,
                NomDto = NomM,
                CompagnyDto = CompagnyM
            };
            repo.CreateCustomer(cusDto);
        }

        public void DeleteCustomer(string id)
        {
            CustomerDTO cusDto = new CustomerDTO
            {
                IdDto = id
            };
            repo.DeleteCustomer(cusDto);
        }
    }
    public class CustomerModels
    {
        public List<CustomerModel> LesCustomers { get; set; }
        private RepoData repo = new RepoData();

        public CustomerModels()
        {
            LesCustomers = new List<CustomerModel>();
                foreach (var item in repo.GetAllCustomers())
                {
                    LesCustomers.Add(new CustomerModel
                    {
                        IdM = item.IdDto,
                        NomM = item.NomDto,
                        CompagnyM = item.CompagnyDto
                    });
                }
        }
    }
}
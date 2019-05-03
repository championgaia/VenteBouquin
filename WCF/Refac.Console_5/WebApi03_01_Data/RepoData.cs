using ClassDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi03_01_Data.ClassData;

namespace WebApi03_01_Data
{
    public class RepoData
    {
        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> myList = new List<CustomerDTO>();
            CustomerDatas cus = new CustomerDatas();
                foreach (var item in cus.LesCustomers)
                {
                    myList.Add(new CustomerDTO
                    {
                        IdDto =  item.Id,
                        NomDto = item.Nom,
                        CompagnyDto = item.Compagny
                    });
                }
                return myList;
        }

        public void CreateCustomer(CustomerDTO cusDto)
        {
            CustomerData cus = new CustomerData
            {
                Id = cusDto.IdDto,
                Nom = cusDto.NomDto,
                Compagny = cusDto.CompagnyDto
            };
            cus.CreateCustomer();
        }

        public void DeleteCustomer(CustomerDTO cusDto)
        {
            new CustomerData().DeleteCustomer(cusDto.IdDto);
        }
    }
}

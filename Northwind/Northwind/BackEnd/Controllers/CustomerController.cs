using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDAL customerDAL;
        private CustomerModel Convertir(Customer customer)
        {
            return new CustomerModel
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };
        }

        private Customer Convertir(CustomerModel customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            };
        }

        public CustomerController()
        {
            customerDAL = new CustomerDALImpl();

        }

        #region Consultas
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<Customer> customers = await customerDAL.GetAll();
            List<CustomerModel> models = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                models.Add(Convertir(customer));
            }
            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Customer customer = await customerDAL.Get(id);
            return new JsonResult(Convertir(customer));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] CustomerModel customer)
        {
            customerDAL.Add(Convertir(customer));
            return new JsonResult(customer);
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CustomerModel customer)
        {
            customerDAL.Update(Convertir(customer));
            return new JsonResult(customer);
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Customer customer = new Customer
            {
                CustomerId = id
            };
            customerDAL.Remove(customer);
        }

        #endregion
    }
}

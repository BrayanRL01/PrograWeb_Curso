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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeDAL employeeDAL;
        private EmployeeModel Convertir(Employee employee)
        {
            return new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Notes = employee.Notes,
                Photo = employee.Photo,
                PhotoPath = employee.PhotoPath,
                ReportsTo = employee.ReportsTo
            };
        }

        private Employee Convertir(EmployeeModel employee)
        {
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Notes = employee.Notes,
                Photo = employee.Photo,
                PhotoPath = employee.PhotoPath,
                ReportsTo = employee.ReportsTo
            };
        }

        public EmployeeController()
        {
            employeeDAL = new EmployeeDALImpl();

        }

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<Employee> employees = await employeeDAL.GetAll();
            List<EmployeeModel> models = new List<EmployeeModel>();

            foreach (var employee in employees)
            {
                models.Add(Convertir(employee));
            }
            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Employee employee = await employeeDAL.Get(id);
            return new JsonResult(Convertir(employee));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] EmployeeModel employee)
        {
            employeeDAL.Add(Convertir(employee));
            return new JsonResult(employee);
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EmployeeModel employee)
        {
            employeeDAL.Update(Convertir(employee));
            return new JsonResult(employee);
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee employee = new Employee
            {
                EmployeeId = id
            };
            employeeDAL.Remove(employee);
        }
        #endregion
    }
}

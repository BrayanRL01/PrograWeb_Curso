using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class EmployeeHelper
    {
        ServiceRepository repository;

        public EmployeeHelper()
        {
            repository = new ServiceRepository();
        }

        #region GetAll
        public List<EmployeeViewModel> GetAll()
        {
            List<EmployeeViewModel> lista = new List<EmployeeViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Employee/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(content);

            }
            return lista;
        }
        #endregion

        #region GetByID
        public EmployeeViewModel GetByID(int id)
        {
            EmployeeViewModel Employee = new EmployeeViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Employee/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            Employee = JsonConvert.DeserializeObject<EmployeeViewModel>(content);

            return Employee;
        }
        #endregion

        #region Update
        public EmployeeViewModel Edit(EmployeeViewModel Employee)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Employee/", Employee);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmployeeViewModel EmployeeAPI = JsonConvert.DeserializeObject<EmployeeViewModel>(content);
            return EmployeeAPI;
        }
        #endregion

        #region Add
        public EmployeeViewModel Add(EmployeeViewModel Employee)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Employee/", Employee);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            EmployeeViewModel EmployeeAPI = JsonConvert.DeserializeObject<EmployeeViewModel>(content);
            return EmployeeAPI;
        }
        #endregion

        #region Delete
        public EmployeeViewModel Delete(int id)
        {
            EmployeeViewModel Employee = new EmployeeViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Employee/" + id);
            return Employee;
        }
        #endregion

    }
}


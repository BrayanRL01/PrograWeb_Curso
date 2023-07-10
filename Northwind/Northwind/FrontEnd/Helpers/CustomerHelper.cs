using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class CustomerHelper
    {
        ServiceRepository repository;

        public CustomerHelper()
        {
            repository = new ServiceRepository();
        }

        #region GetAll
        public List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> lista = new List<CustomerViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Customer/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CustomerViewModel>>(content);

            }
            return lista;
        }
        #endregion

        #region GetByID
        public CustomerViewModel GetByID(int id)
        {
            CustomerViewModel Customer = new CustomerViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Customer/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            Customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);

            return Customer;
        }
        #endregion

        #region Update
        public CustomerViewModel Edit(CustomerViewModel Customer)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Customer/", Customer);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CustomerViewModel CustomerAPI = JsonConvert.DeserializeObject<CustomerViewModel>(content);
            return CustomerAPI;
        }
        #endregion

        #region Add
        public CustomerViewModel Add(CustomerViewModel Customer)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Customer/", Customer);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CustomerViewModel CustomerAPI = JsonConvert.DeserializeObject<CustomerViewModel>(content);
            return CustomerAPI;
        }
        #endregion

        #region Delete
        public CustomerViewModel Delete(int id)
        {
            CustomerViewModel Customer = new CustomerViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Customer/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            return Customer;
        }
        #endregion

    }
}


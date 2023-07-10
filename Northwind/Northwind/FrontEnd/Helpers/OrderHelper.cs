using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class OrderHelper
    {
        ServiceRepository repository;

        public OrderHelper()
        {
            repository = new ServiceRepository();
        }

        #region GetAll
        public List<OrderViewModel> GetAll()
        {
            List<OrderViewModel> lista = new List<OrderViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Order/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<OrderViewModel>>(content);

            }
            return lista;
        }
        #endregion

        #region GetByID
        public OrderViewModel GetByID(int id)
        {
            OrderViewModel Order = new OrderViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Order/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            Order = JsonConvert.DeserializeObject<OrderViewModel>(content);

            return Order;
        }
        #endregion

        #region Update
        public OrderViewModel Edit(OrderViewModel Order)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Order/", Order);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            OrderViewModel OrderAPI = JsonConvert.DeserializeObject<OrderViewModel>(content);
            return OrderAPI;
        }
        #endregion

        #region Add
        public OrderViewModel Add(OrderViewModel Order)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Order/", Order);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            OrderViewModel OrderAPI = JsonConvert.DeserializeObject<OrderViewModel>(content);
            return OrderAPI;
        }
        #endregion

        #region Delete
        public OrderViewModel Delete(int id)
        {
            OrderViewModel Order = new OrderViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Order/" + id);
            return Order;
        }
        #endregion

    }
}


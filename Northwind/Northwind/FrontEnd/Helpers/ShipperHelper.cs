using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository repository;

        public ShipperHelper()
        {
            repository = new ServiceRepository();
        }

        #region GetAll
        public List<ShipperViewModel> GetAll()
        {
            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);

            }
            return lista;
        }
        #endregion

        #region GetByID
        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperViewModel GetByID(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/shipper/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }
        #endregion

        #region Update
        public ShipperViewModel Edit(ShipperViewModel shipper)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;
        }
        #endregion

        #region Add
        public ShipperViewModel Add(ShipperViewModel shipper)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;
        }
        #endregion

        #region Delete

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperViewModel Delete(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/shipper/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            return shipper;
        }
        #endregion

    }
}


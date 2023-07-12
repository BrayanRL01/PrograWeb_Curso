using DAL.Implementations;
using BackEnd.Models;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperDAL shipperDAL;
        private ShipperModel Convertir(Shipper shipper)
        {
            return new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
                Picture = shipper.Picture
            };
        }

        private Shipper Convertir(ShipperModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
                Picture = shipper.Picture
            };
        }

        public ShipperController()
        {
            shipperDAL = new ShipperDALImpl();

        }

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<Shipper> shippers = await shipperDAL.GetAll();
            List<ShipperModel> models = new List<ShipperModel>();

            foreach (var shipper in shippers)
            {
                models.Add(Convertir(shipper));
            }
            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Shipper shipper = await shipperDAL.Get(id);
            return new JsonResult(Convertir(shipper));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShipperModel shipper)
        {
            shipperDAL.Add(Convertir(shipper));
            return new JsonResult(shipper);
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShipperModel shipper)
        {
            shipperDAL.Update(Convertir(shipper));
            return new JsonResult(shipper);
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Shipper shipper = new Shipper
            {
                ShipperId = id
            };
            shipperDAL.Remove(shipper);
        }
        #endregion
    }
}

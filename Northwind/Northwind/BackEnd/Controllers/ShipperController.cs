using DAL.Implementations;
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

        public ShipperController()
        {
            shipperDAL = new ShipperDALImpl();

        }
        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDAL.GetAll();
            return new JsonResult(shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);
            return new JsonResult(shipper);
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion
    }
}

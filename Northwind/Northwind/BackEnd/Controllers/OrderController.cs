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
    public class OrderController : ControllerBase
    {
        private IOrderDAL orderDAL;
        private OrderModel Convertir(Order order)
        {
            return new OrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                Freight = order.Freight,
                RequiredDate = order.RequiredDate,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                ShipName = order.ShipName,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia
            };
        }

        private Order Convertir(OrderModel order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                Freight = order.Freight,
                RequiredDate = order.RequiredDate,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                ShipName = order.ShipName,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia
            };
        }

        public OrderController()
        {
            orderDAL = new OrderDALImpl();

        }

        #region Consultas
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<Order> orders = await orderDAL.GetAll();
            List<OrderModel> models = new List<OrderModel>();

            foreach (var order in orders)
            {
                models.Add(Convertir(order));
            }
            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Order order = await orderDAL.Get(id);
            return new JsonResult(Convertir(order));
        }

        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] OrderModel order)
        {
            orderDAL.Add(Convertir(order));
            return new JsonResult(order);
        }

        #endregion

        #region Modificar

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] OrderModel order)
        {
            orderDAL.Update(Convertir(order));
            return new JsonResult(order);
        }

        #endregion

        #region Eliminar 
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Order order = new Order
            {
                OrderId = id
            };
            orderDAL.Remove(order);
        }

        #endregion
    }
}

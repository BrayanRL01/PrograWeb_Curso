using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class OrderDALImpl : IOrderDAL
    {
        private NorthwindContext northWindContext;
        private UnidadDeTrabajo<Order> unidad;

        public bool Add(Order entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Order>(new NorthwindContext()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Get(int id)
        {
            Order order = null;
            using (unidad = new UnidadDeTrabajo<Order>(new NorthwindContext()))
            {
                order = await unidad.genericDAL.Get(id);
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            IEnumerable<Order> orders = null;
            using (unidad = new UnidadDeTrabajo<Order>(new NorthwindContext()))
            {
                orders = await unidad.genericDAL.GetAll();
            }
            return orders;
        }

        public bool Remove(Order entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Order>(new NorthwindContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public Order SingleOrDefault(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Order>(new NorthwindContext()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

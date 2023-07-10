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
    public class CustomerDALImpl : ICustomerDAL
    {
        private NorthwindContext northWindContext;
        private UnidadDeTrabajo<Customer> unidad;

        public bool Add(Customer entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Customer>(new NorthwindContext()))
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

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Get(int id)
        {
            Customer customer = null;
            using (unidad = new UnidadDeTrabajo<Customer>(new NorthwindContext()))
            {
                customer = await unidad.genericDAL.Get(id);
            }
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            IEnumerable<Customer> customers = null;
            using (unidad = new UnidadDeTrabajo<Customer>(new NorthwindContext()))
            {
                customers = await unidad.genericDAL.GetAll();
            }
            return customers;
        }

        public bool Remove(Customer entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Customer>(new NorthwindContext()))
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

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Customer>(new NorthwindContext()))
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

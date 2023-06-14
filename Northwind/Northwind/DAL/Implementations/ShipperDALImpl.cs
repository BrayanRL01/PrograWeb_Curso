using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : IShipperDAL
    {
        private NorthwindContext northWindContext;
        private UnidadDeTrabajo<Shipper> unidad;

        NorthwindContext northwindContext = new NorthwindContext();

        public bool Add(Shipper entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Shipper>(new NorthwindContext()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Shipper> Get(int id)
        {
            Shipper shipper = null;
            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthwindContext()))
            {
                shipper = await unidad.genericDAL.Get(id);
            }
            return shipper;
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            IEnumerable<Shipper> shippers = null;
            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthwindContext()))
            {
                shippers = await unidad.genericDAL.GetAll();
            }
            return shippers;
        }

        public bool Remove(Shipper entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Shipper>(new NorthwindContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Shipper>(new NorthwindContext()))
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

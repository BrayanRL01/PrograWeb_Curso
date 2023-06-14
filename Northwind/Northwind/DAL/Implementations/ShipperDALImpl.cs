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
    public class ShipperDALImpl : IShipperDAL
    {
        private NorthwindContext northWindContext;
        private UnidadDeTrabajo<Shipper> unidad;

        public bool Add(Shipper entity)
        {
            NorthwindContext northWindContext = new NorthwindContext();
            try
            {
                string Query = "EXEC [dbo].[SP_AddShipper] @Nombre, @Telefono";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value= entity.CompanyName
                    },
                     new SqlParameter()
                    {
                        ParameterName = "@Telefono",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value= entity.Phone
                    }

                };
                int resultado = northWindContext.Database.ExecuteSqlRaw(Query, param);
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
            List<Shipper> shippers = new List<Shipper>();
            List<SP_GetAllShippers_Result> resultado;

            string Query = "[dbo].[SP_GetAllShippers]";
            NorthwindContext northwindContext = new NorthwindContext();
            resultado = await northwindContext.SP_GetAllShippers_Results
                        .FromSqlRaw(Query)
                        .ToListAsync();
            foreach (var item in resultado)
            {
                shippers.Add(
                    new Shipper
                    {
                        ShipperId = item.ShipperId,
                        CompanyName = item.CompanyName,
                        Phone = item.Phone
                    });
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

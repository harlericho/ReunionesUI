using Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio.Implementacion
{
    public class BaseRepositorioImpl<TEntity> : IDisposable, IBaseRepositorio<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    return context.Set<TEntity>().ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    return context.Set<TEntity>().Find(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Modify(TEntity entity)
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

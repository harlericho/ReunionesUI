using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo.Abstracciones
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        void Add(TEntity entidad); // Insertar
        void Modify(TEntity entidad); // Modificar
        void Delete(int id); //Eliminar por id
        TEntity GetById(int id); // Buscar por id
        IEnumerable<TEntity> GetAll(); // Listar todos
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TModel, TKey> : IDisposable
                where TModel : class
                where TKey : struct
    {
        void Add(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        List<TModel> GetAll();
        List<TModel> GetAll(Func<TModel, bool> where);
        TModel Get(Func<TModel, bool> where);
        TModel GetById(TKey id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Models;
using UsuarioApp.Infra.Data.Contexts;

namespace UsuarioApp.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {
        private readonly DataContext? _dataContext;

        public UsuarioRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}




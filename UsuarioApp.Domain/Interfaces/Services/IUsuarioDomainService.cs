using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Models;

namespace UsuarioApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        void CriarConta(Usuario conta);
    }
}

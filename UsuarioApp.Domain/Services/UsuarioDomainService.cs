using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Repositories;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Models;

namespace UsuarioApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public UsuarioDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CriarConta(Usuario usuario)
        {
            _unitOfWork?.UsuarioRepository?.Add(usuario);
            _unitOfWork?.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}




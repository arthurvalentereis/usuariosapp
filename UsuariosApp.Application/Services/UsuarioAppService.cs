using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Models;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Request;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                DataHoraCriacao = DateTime.Now
            };

            _usuarioDomainService?.CriarConta(usuario);

            return new CriarContaResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCriacao = usuario.DataHoraCriacao
            };
        }

        public void Dispose()
        {
            _usuarioDomainService?.Dispose();
        }
    }
}
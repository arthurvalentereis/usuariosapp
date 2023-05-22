using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Services;
using UsuarioApp.Domain.Models;
using UsuariosApp.Application.Helpers;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Request;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Response;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;
        private readonly IMapper? _mapper;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService, IMapper? mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            var usuario = _usuarioDomainService?.Autenticar(dto.Email, Sha1Helper.Encrypt(dto.Senha));
            return _mapper.Map<AutenticarResponseDTO>(usuario);
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = _mapper?.Map<Usuario>(dto);
            _usuarioDomainService?.CriarConta(usuario);

            return _mapper.Map<CriarContaResponseDTO>(usuario);
        }

        public RecuperarSenhaResponseDTO RecuperarSenha(RecuperarSenhaRequestDTO dto)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(dto.Email);
            return _mapper.Map<RecuperarSenhaResponseDTO>(usuario);
        }

        public void Dispose()
        {
            _usuarioDomainService?.Dispose();
        }
    }
}
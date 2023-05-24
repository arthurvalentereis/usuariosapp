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
using UsuariosApp.Application.Interfaces.Identities;
using UsuariosApp.Application.Interfaces.Producers;
using UsuariosApp.Application.Interfaces.Services;
using UsuariosApp.Application.Models.Producers;
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
        private readonly IUsuarioMessageProducer? _messageProducer;
        private readonly ITokenCreator? _tokenCreator;

        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService, IMapper? mapper, IUsuarioMessageProducer? messageProducer, ITokenCreator? tokenCreator)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
            _messageProducer = messageProducer;
            _tokenCreator = tokenCreator;
        }

        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            var usuario = _usuarioDomainService?.Autenticar(dto.Email, Sha1Helper.Encrypt(dto.Senha));
            var response = _mapper.Map<AutenticarResponseDTO>(usuario);

            response.AccessToken = _tokenCreator.Create(usuario.Email, "USER_ROLE");
            response.DataHoraExpiracao = DateTime.UtcNow.AddHours(1);
            return response;
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = _mapper?.Map<Usuario>(dto);
            _usuarioDomainService?.CriarConta(usuario);
            var usuarioMessageDTO = new UsuarioMessageDTO
            {
                Tipo = TipoMensagem.CriacaoDeConta,
                DataHora = DateTime.UtcNow,
                IdUsuario = usuario.Id,
                NomeUsuario = usuario.Nome,
                EmailUsuario = usuario.Email,
            };
            _messageProducer.Send(usuarioMessageDTO);

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
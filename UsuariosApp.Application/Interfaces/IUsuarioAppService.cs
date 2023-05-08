﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Models.Request;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        public AutenticarResponseDTO autenticar(AutenticarRequestDTO dto);
        public CriarContaResponseDTO criarConta(CriarContaRequestDTO dto);
    }
}

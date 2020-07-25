using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Listar todos os tipos de usuario
        /// </summary>
        /// <returns>Uma lista com os tipos de usuario</returns>
        List<TiposUsuario> Listar();

    }
}

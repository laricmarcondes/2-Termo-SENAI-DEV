﻿using Senai.InLocl.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IJogoRepository
    {
        List<Jogos> Listar();

        Jogos BuscarPorId(int id);

        void Cadastrar(Jogos novoJogo);

        void Atualizar(int id, Jogos jogoAtualizado);

        void Deletar(int id);

        List<Jogos> ListarComEstudio();

        List<Jogos> ListarPorEstudio(int id);
    }
}

using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Uma lista das especialidades</returns>
        public List<Especialidades> Listar()
        {
            // Retorna uma lista com todas as informações das especialidades
            return ctx.Especialidades.ToList();
        }

        /// <summary>
        /// Busca uma especialidade através do ID
        /// </summary>
        /// <param name="id">ID da especialidade que será buscada</param>
        /// <returns>Uma especialidade buscada</returns>
        public Especialidades BuscarPorId(int id)
        {
            // Retorna a primeira especialidade encontrada para o ID informado
            return ctx.Especialidades.FirstOrDefault(c => c.IdEspecialidade == id);
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto com as informações de especialidade</param>
        public void Cadastrar(Especialidades novaEspecialidade)
        {
            // Adiciona novaEspecialidade
            ctx.Especialidades.Add(novaEspecialidade);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Especialidades especialidadeAtualizada)
        {
            // Busca uma especialidade através do id
            Especialidades especialidadeBuscada = ctx.Especialidades.Find(id);

            // Atribui os novos valores ao campos existentes
            especialidadeBuscada.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;

            // Atualiza a especialidade que foi buscada
            ctx.Especialidades.Update(especialidadeBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="id">ID da especialidade que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a especialidade através do id
            ctx.Especialidades.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}

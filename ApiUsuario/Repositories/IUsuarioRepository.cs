using ApiUsuario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Task<List<Usuario>> Obter();
        Task<Usuario> Obter(int id);
        Task Inserir(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(int id);
    }
}

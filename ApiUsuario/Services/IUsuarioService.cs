using ApiUsuario.InputModel;
using ApiUsuario.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<List<UsuarioViewModel>> Obter();
        Task<UsuarioViewModel> Obter(int id);
        Task<UsuarioViewModel> Inserir(UsuarioInputModel jogo);
        Task Atualizar(int id, UsuarioInputModel jogo);
        Task Remover(int id);
    }
}

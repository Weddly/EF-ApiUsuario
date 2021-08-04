using ApiUsuario.Entities;
using ApiUsuario.InputModel;
using ApiUsuario.Repositories;
using ApiUsuario.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioViewModel>> Obter()
        {
            var usuarios = await _usuarioRepository.Obter();

            return usuarios.Select(usuario => new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DtNascimento = usuario.DtNascimento,
                Escolaridade = usuario.Escolaridade
            }).ToList();
        }

        public async Task<UsuarioViewModel> Obter(int id)
        {
            var usuario = await _usuarioRepository.Obter(id);

            if (usuario == null)
                return null;

            return new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DtNascimento = usuario.DtNascimento,
                Escolaridade = usuario.Escolaridade
            };
        }

        public async Task<UsuarioViewModel> Inserir(UsuarioInputModel usuario)
        {
            var usuarioInsert = new Usuario
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                DtNascimento = usuario.DtNascimento,
                Escolaridade = usuario.Escolaridade
            };

            await _usuarioRepository.Inserir(usuarioInsert);


            return new UsuarioViewModel
            {
                UsuarioId = usuarioInsert.UsuarioId,
                Nome = usuarioInsert.Nome,
                Sobrenome = usuarioInsert.Sobrenome,
                Email = usuarioInsert.Email,
                DtNascimento = usuarioInsert.DtNascimento,
                Escolaridade = usuarioInsert.Escolaridade
            };
        }

        public async Task Atualizar(int id, UsuarioInputModel usuario)
        {
            var entidadeUsuario = await _usuarioRepository.Obter(id);
            entidadeUsuario.Nome = usuario.Nome;
            entidadeUsuario.Sobrenome = usuario.Sobrenome;
            entidadeUsuario.Email = usuario.Email;
            entidadeUsuario.DtNascimento = usuario.DtNascimento;
            entidadeUsuario.Escolaridade = usuario.Escolaridade;


            await _usuarioRepository.Atualizar(entidadeUsuario);
        }

        public async Task Remover(int id)
        { 
            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}

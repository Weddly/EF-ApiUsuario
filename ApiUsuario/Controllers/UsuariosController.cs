using ApiUsuario.Exceptions;
using ApiUsuario.InputModel;
using ApiUsuario.Services;
using ApiUsuario.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> Obter()
        {
            var usuarios = await _usuarioService.Obter();

            if (usuarios.Count() == 0)
                return NoContent();
            return Ok(usuarios);
        }

        [HttpGet("{usuarioId:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Obter([FromRoute] int usuarioId)
        {
            var usuario = await _usuarioService.Obter(usuarioId);

            if (usuario == null)
                return NoContent();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> InserirUsuario([FromBody] UsuarioInputModel usuarioInputModel)
        { 
            var usuario = await _usuarioService.Inserir(usuarioInputModel);
            return Ok(new
            {
                status = "Usuário criado com sucesso"
            });
        }

        [HttpPut("{usuarioId:int}")]
        public async Task<ActionResult> AtualizarUsuario([FromRoute] int usuarioId, [FromBody] UsuarioInputModel usuarioInputModel)
        {
            try
            {
                await _usuarioService.Atualizar(usuarioId, usuarioInputModel);
                return Ok(new
                {
                    status = "Usuário atualizado com sucesso"
                });
            }
            catch (UsuarioNaoCadastradoException ex)
            {
                return NotFound("Não existe este usuário.");
            }
        }

        [HttpDelete("{usuarioId:int}")]
        public async Task<ActionResult> ApagarUsuario([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioService.Remover(usuarioId);
                return Ok(new
                {
                    status = "Usuário excluído com sucesso"
                });
            }
            catch (UsuarioNaoCadastradoException ex)
            {
                return NotFound("Não existe este usuário.");
            }
        }


    }
}

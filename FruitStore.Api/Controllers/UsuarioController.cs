using FruitStore.Application.Models.Usuario;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using FruitStore.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FruitStore.Service.Services;

namespace FruitStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IBaseService<Usuario> _baseUsuarioService;
        private IUsuarioService _usuarioService;

        public UsuarioController(IBaseService<Usuario> baseUsuarioService, IUsuarioService usuarioService)
        {
            _baseUsuarioService = baseUsuarioService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get() 
            => Execute(() => _baseUsuarioService.Obter<UsuarioModel>());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUsuarioService.ObterPorId<UsuarioModel>(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CreateUsuarioModel usuario)
        {
            if (usuario == null)
                return NotFound();

            return Execute(() => _baseUsuarioService.Inserir<CreateUsuarioModel, UsuarioModel, UsuarioValidator>(usuario));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUsuarioModel usuario)
        {
            if (usuario == null)
                return NotFound();

            return Execute(() => _baseUsuarioService.Atualizar<UpdateUsuarioModel, UsuarioModel, UsuarioValidator>(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUsuarioService.Excluir(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] UsuarioLoginModel usuarioLogin)
        {
            // Recupera o usuário
            var usuario = _usuarioService.Login(usuarioLogin.Email, usuarioLogin.Senha);

            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(usuario);


            // Retorna os dados
            return new
            {
                usuario = usuario,
                token = token
            };
        }
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }
    }
}

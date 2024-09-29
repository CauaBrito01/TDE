using Microsoft.AspNetCore.Mvc;
using TDE___Kawan.Models;
using TDE___Kawan.Repositories;
using TDE___Kawan.Services;

namespace TDE___Kawan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioService usuarioService, IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }


        [HttpGet("ListaUsuario")]
        public ActionResult<List<UsuarioModel>> ListaUsuario()
        {
            var usuarios = _usuarioService.ListaUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("ListaUsuario/{id}")]
        public ActionResult<ResultadoUsuarioModel> ListaUsuario(int id)
        {
            try
            {
                var resultado = _usuarioService.ListaUsuario(id);

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound(resultado);
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, new ResultadoUsuarioModel
                {
                    Sucesso = false,
                    Mensagem = "Ocorreu um erro ao processar a solicitação."
                });
            }
        }

        [HttpPost("AdicionaUsuario")]
        public ActionResult<UsuarioModel> AdicionaUsuario(UsuarioModel usuario)
        {
            _usuarioService.AdicionaUsuario(usuario);
            return Ok(new UsuarioModel { });
        }

        [HttpPut("EditaUsuario/{id}")]
        public IActionResult EditaUsuario(UsuarioModel usuario, int id)
        {
            try
            {
                var resultado = _usuarioService.EditaUsuario(usuario, id);

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultadoUsuarioModel
                {
                    Sucesso = false,
                    Mensagem = "Ocorreu um erro ao processar a solicitação."
                });
            }
        }

        [HttpDelete("DeletaUsuario/{id}")]
        public IActionResult DeletaUsuario(int id)
        {
            _usuarioService.DeletaUsuario(id);
            return NoContent();
        }

    }
}

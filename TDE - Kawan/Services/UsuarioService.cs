using TDE___Kawan.Models;
using TDE___Kawan.Repositories;

namespace TDE___Kawan.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioModel> ListaUsuarios()
        {
            return _usuarioRepository.ListaUsuarios();
        }

        public ResultadoUsuarioModel ListaUsuario(int id)
        {
            var usuario = _usuarioRepository.ListaUsuario(id);

            if (usuario != null)
            {
                return new ResultadoUsuarioModel
                {
                    Sucesso = true,
                    Mensagem = "Usuario listado com sucesso.",
                    Usuario = usuario
                };
            }
            else
            {
                return new ResultadoUsuarioModel
                {
                    Sucesso = false,
                    Mensagem = "Nenhum usuario encontrado."
                };
            };
        }


        public void AdicionaUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.AdicionaUsuario(usuario);
        }

        public ResultadoUsuarioModel EditaUsuario(UsuarioModel usuario, int id)
        {
            _usuarioRepository.EditaUsuario(usuario, id);

            return new ResultadoUsuarioModel
            {
                Sucesso = true,
                Mensagem = "Usuario editado com sucesso."
            };
        }


        public void DeletaUsuario(int id)
        {
            _usuarioRepository.DeletaUsuario(id);
        }


    }
}

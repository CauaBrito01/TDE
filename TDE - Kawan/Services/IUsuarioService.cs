using TDE___Kawan.Models;

namespace TDE___Kawan.Services
{
    public interface IUsuarioService
    {
        public List<UsuarioModel> ListaUsuarios();
        public ResultadoUsuarioModel ListaUsuario(int id);
        public void AdicionaUsuario(UsuarioModel usuario);
        public ResultadoUsuarioModel EditaUsuario(UsuarioModel usuario, int id);
        public void DeletaUsuario(int id);
    }
}

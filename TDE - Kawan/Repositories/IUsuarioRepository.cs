using TDE___Kawan.Models;

namespace TDE___Kawan.Repositories
{
    public interface IUsuarioRepository
    {
        public List<UsuarioModel> ListaUsuarios();
        public UsuarioModel ListaUsuario(int id);
        public void AdicionaUsuario(UsuarioModel usuario);
        public void EditaUsuario(UsuarioModel usuario, int id);
        public void DeletaUsuario(int id);
    }
}

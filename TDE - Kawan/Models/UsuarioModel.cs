namespace TDE___Kawan.Models
{
    public class UsuarioModel
    {
        public long IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime DataNascimentoUsuario { get; set; }
        public bool IndAtivo { get; set; }
        public string ImgPerfilUsuario { get; set; }
    }
}

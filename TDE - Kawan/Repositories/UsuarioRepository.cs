using MySql.Data.MySqlClient;
using System.Data;
using TDE___Kawan.Models;

namespace TDE___Kawan.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        #region conexão
        private readonly string _connectionString;

        // Construtor da classe UsuarioRepository que recebe IConfiguration
        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentException("Connection string is null or empty");
            }
        }

        // Método privado para obter a conexão com o banco de dados
        private IDbConnection GetConnection()
        {
            // Retorna uma nova conexão MySqlConnection utilizando a _connectionString definida no construtor
            return new MySqlConnection(_connectionString);
        }
        #endregion

        #region metodos

        public List<UsuarioModel> ListaUsuarios()
        {
            List<UsuarioModel> Usuarios = new List<UsuarioModel>();

            using (var connection = GetConnection())
            {
                string query = @"SELECT U.ID_USUARIO,
                                        U.NOME_USUARIO,
                                        U.EMAIL_USUARIO,
                                        U.SENHA_USUARIO,
                                        U.DATA_NASCIMENTO_USUARIO,
                                        U.IMG_PERFIL_USUARIO
                                   FROM USUARIO U
                                  WHERE U.IND_ATIVO = 1"
                ;
                using (var reader = connection.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        UsuarioModel usuario = new UsuarioModel
                        {
                            IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_USUARIO")),
                            NomeUsuario = reader["NOME_USUARIO"].ToString(),
                            EmailUsuario = reader["EMAIL_USUARIO"].ToString(),
                            SenhaUsuario = reader["SENHA_USUARIO"].ToString(),
                            DataNascimentoUsuario = reader.GetDateTime(reader.GetOrdinal("DATA_NASCIMENTO_USUARIO"))
                        };
                        Usuarios.Add(usuario);
                    }
                }

                return Usuarios;
            }
        }

        public UsuarioModel ListaUsuario(int id)
        {
            UsuarioModel usuario = null;

            using (var connection = GetConnection())
            {
                string query = @"SELECT U.ID_USUARIO,
                                U.NOME_USUARIO,
                                U.EMAIL_USUARIO,
                                U.SENHA_USUARIO,
                                U.DATA_NASCIMENTO_USUARIO,
                                U.IMG_PERFIL_USUARIO
                           FROM USUARIO U
                          WHERE U.ID_USUARIO = @Id";

                //passei o paramentro como um objeto
                using (var reader = connection.ExecuteReader(query, new { Id = id }))
                {
                    while (reader.Read())
                    {
                        usuario = new UsuarioModel
                        {
                            IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_USUARIO")),
                            NomeUsuario = reader["NOME_USUARIO"].ToString(),
                            EmailUsuario = reader["EMAIL_USUARIO"].ToString(),
                            SenhaUsuario = reader["SENHA_USUARIO"].ToString(),
                            DataNascimentoUsuario = reader.GetDateTime(reader.GetOrdinal("DATA_NASCIMENTO_USUARIO"))
                        };
                    }
                }
            }

            return usuario;
        }


        public void AdicionaUsuario(UsuarioModel usuario)
        {
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO USUARIO (
                            NOME_USUARIO, 
                            EMAIL_USUARIO, 
                            SENHA_USUARIO, 
                            DATA_NASCIMENTO_USUARIO, 
                            IMG_PERFIL_USUARIO) 
                         VALUES (
                            @NomeUsuario, 
                            @EmailUsuario, 
                            @SenhaUsuario, 
                            @DataNascimentoUsuario, 
                            @ImgPerfilUsuario)";

                connection.Execute(query, new
                {
                    NomeUsuario = usuario.NomeUsuario,
                    EmailUsuario = usuario.EmailUsuario,
                    SenhaUsuario = usuario.SenhaUsuario,
                    DataNascimentoUsuario = usuario.DataNascimentoUsuario,
                    ImgPerfilUsuario = usuario.ImgPerfilUsuario
                });
            }
        }

        public void EditaUsuario(UsuarioModel usuario, int id)
        {
            using (var connection = GetConnection())
            {
                string query = @"
                    UPDATE USUARIO 
                    SET NOME_USUARIO = @NomeUsuario, 
                        EMAIL_USUARIO = @EmailUsuario, 
                        SENHA_USUARIO = @SenhaUsuario,
                        DATA_NASCIMENTO_USUARIO = @DataNascimentoUsuario
                    WHERE ID_USUARIO = @IdUsuario";

                connection.Execute(query, new
                {
                    NomeUsuario = usuario.NomeUsuario,
                    EmailUsuario = usuario.EmailUsuario,
                    SenhaUsuario = usuario.SenhaUsuario,
                    DataNascimentoUsuario = usuario.DataNascimentoUsuario,
                    IdUsuario = id
                });
            }
        }

        public void DeletaUsuario(int id)
        {
            using (var connection = GetConnection())
            {
                string query = "UPDATE USUARIO SET IND_ATIVO = 0 WHERE ID_USUARIO = @Id";

                connection.Execute(query, new { Id = id });
            }
        }

        #endregion

    }
}

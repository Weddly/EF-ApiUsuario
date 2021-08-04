using ApiUsuario.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection sqlConnection;

        public UsuarioRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }
        public async Task<List<Usuario>> Obter()
        {
            var usuarios = new List<Usuario>();

            var comando = $"select * from Usuario order by UsuarioId";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                usuarios.Add(new Usuario
                {
                    UsuarioId = (int)sqlDataReader["UsuarioId"],
                    Nome = (string)sqlDataReader["Nome"],
                    Sobrenome = (string)sqlDataReader["Sobrenome"],
                    Email = (string)sqlDataReader["Email"],
                    DtNascimento = (DateTime)sqlDataReader["DtNascimento"],
                    Escolaridade = (int)sqlDataReader["Escolaridade"]

                });
            }
            await sqlConnection.CloseAsync();
            return usuarios;

        }

        public async Task<Usuario> Obter(int id)
        {
            Usuario usuario = null;

            var comando = $"select * from Usuario where UsuarioId = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                usuario = new Usuario
                {
                    UsuarioId = (int)sqlDataReader["UsuarioId"],
                    Nome = (string)sqlDataReader["Nome"],
                    Sobrenome = (string)sqlDataReader["Sobrenome"],
                    Email = (string)sqlDataReader["Email"],
                    DtNascimento = (DateTime)sqlDataReader["DtNascimento"],
                    Escolaridade = (int)sqlDataReader["Escolaridade"]

                };
            }
            await sqlConnection.CloseAsync();
            return usuario;
        }

        public async Task Inserir(Usuario usuario)
        {
            var comando = $"insert Usuario (Nome, Sobrenome, Email, DtNascimento, Escolaridade) values ('{usuario.Nome}', '{usuario.Sobrenome}', '{usuario.Email}', '{usuario.DtNascimento}', '{usuario.Escolaridade}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Usuario usuario)
        {
            var comando = $"update Usuario set Nome = '{usuario.Nome}', Sobrenome = '{usuario.Sobrenome}', Email = '{usuario.Email}', DtNascimento = '{usuario.DtNascimento}', Escolaridade = '{usuario.Escolaridade}' where UsuarioId = '{usuario.UsuarioId}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }
        public async Task Remover(int id)
        {
            var comando = $"delete from Usuario where UsuarioId = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();

        }
    }
}

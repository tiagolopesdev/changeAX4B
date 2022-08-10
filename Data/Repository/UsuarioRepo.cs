using Dapper;
using Domain.Interface;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Repository.Repository
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("DefaultConnection"); } }
        public UsuarioRepo(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }
        public async Task<List<Usuario>> GetUsuario()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                IEnumerable<Usuario> response = await conexao.QueryAsync<Usuario>("select * from usuarios");
                return response.ToList();
            }

        }
        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                await conexao.ExecuteAsync($"insert into usuarios (nomeUsuario, codigoUsuario) values ('{usuario.NomeUsuario}', {usuario.CodigoUsuario})");
            }
            return new Usuario();
        }
    }
}

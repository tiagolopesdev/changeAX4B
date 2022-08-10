using Dapper;
using Domain.Interface;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Repository.Repository
{
    public class RestauranteRepo : IRestauranteRepo
    {
        private IConfiguration _configuracoes;
        private string _conexao { get{ return _configuracoes.GetConnectionString("DefaultConnection"); } }
        public RestauranteRepo(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }
        public async Task<List<Restaurante>> GetRestaurante()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                IEnumerable<Restaurante> response = await conexao.QueryAsync<Restaurante>("select * from restaurantes");
                return response.ToList();                
            }
            
        }
        public async Task<string> CreateRestaurante(Restaurante restaurante)
        {                        
            Message message = new Message();
            try
            {
                using (var conexao = new MySqlConnection(_conexao))
                {
                    await conexao.ExecuteAsync($"insert into restaurantes (nomeRestaurante, codigoRestaurante) values ('{restaurante.nomeRestaurante}', {restaurante.codigoRestaurante})");
                }
                message.menssageSuccess = "Restaurante salvo com sucesso";
                return message.menssageSuccess;
            }
            catch
            {
                message.menssageFailure = "Restaurante não salvo com sucesso";
                return message.menssageFailure;
            }
        }
    }
}

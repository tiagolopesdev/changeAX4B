using Dapper;
using Domain.Interface;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;
using System.Globalization;
using static Dapper.SqlMapper;

namespace Repository.Repository
{
    public class VotoRepo : IVotoRepo
    {
        private readonly string _insertData = "insert into votos (idUsuario, idRestaurante, horaVoto) values";

        private IConfiguration _configuracoes;
        private string _conexao { get{ return _configuracoes.GetConnectionString("DefaultConnection"); } }
        public VotoRepo(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }
        public async Task<List<Votos>> GetVoto()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                IEnumerable<Votos> response = await conexao.QueryAsync<Votos>("select * from votos");                
                return response.ToList();                
            }
            
        }
        public async Task<string> CreateVoto(Votos votos)
        {    
            Message message = new Message();
            try
            {
                using (var conexao = new MySqlConnection(_conexao))
                {
                    await conexao.ExecuteAsync(_insertData + $"({votos.idUsuario}, {votos.idRestaurante}, current_timestamp())");
                }
                message.menssageSuccess = "Voto salvo com sucesso";
                return message.menssageSuccess;
            } catch
            {
                message.menssageFailure = "Voto não salvo com sucesso";
                return message.menssageFailure;
            }            
        }        
        public async Task<IEnumerable<Ranking>> GetRanking()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                string sql = "SELECT r.nomeRestaurante, COUNT(v.idRestaurante) as QntVotos FROM votos v" +
                    " INNER JOIN restaurantes r WHERE v.idRestaurante = r.codigoRestaurante" +
                    " GROUP BY v.idRestaurante";
                IEnumerable<Ranking> result = await conexao.QueryAsync<Ranking>(sql);
                List<Ranking> rankings = result.ToList();
                return rankings;               
            }            
        }
        public async Task<Ranking> GetOneRanking()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                string sql = "SELECT r.nomeRestaurante, COUNT(v.idRestaurante) as QntVotos FROM votos v" +
                    " INNER JOIN restaurantes r WHERE v.idRestaurante = r.codigoRestaurante" +
                    " GROUP BY v.idRestaurante";
                IEnumerable<Ranking> result = await conexao.QueryAsync<Ranking>(sql);
                List<Ranking> rankings = result.ToList();
                Ranking getFirstElement = rankings.First();
                return getFirstElement;
            }
        }
    }
}

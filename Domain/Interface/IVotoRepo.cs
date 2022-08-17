using Domain.Models;

namespace Domain.Interface
{
    public interface IVotoRepo
    {
        public Task<List<Votos>> GetVotosDay();
        public Task<string> CreateVoto(Votos votos);
        public Task<IEnumerable<Ranking>> GetRanking();
        public Task<Ranking> GetOneRanking();
        public Task<List<Votos>> GetAllVotos();
    }
}

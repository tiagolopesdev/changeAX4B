using Domain.Interface;
using Domain.Models;
using System.Data;

namespace Domain.BAC
{
    public class VotosBAC : IVotoBAC
    {
        private IVotoRepo _repo;
        
 
        public VotosBAC(IVotoRepo votoRepo, IUsuarioRepo usuarioRepo)
        {
            _repo = votoRepo;           
        }
        /*public async Task<List<Votos>> GetAllVotosFilter()
        {
             List<>
        }*/
        public async Task<List<Votos>> GetAllVotos()
        {
            List<Votos> votos = await _repo.GetAllVotos();
            return votos;
        }
        public async Task<List<Votos>> GetVoto()
        {                
            List<Votos> votos = await _repo.GetVotosDay();
            return votos;
        }
        public async Task<string> CreateVoto(Votos votos)
        {
            List<Votos> findVoto = await GetVoto();
            bool containsVoto = findVoto.Select(find =>
                find.idUsuario).Contains(votos.idUsuario);

            string onlyHrs = DateTime.Now.ToShortTimeString();
            TimeOnly horaInicio = new TimeOnly(9, 0, 0);
            TimeOnly horaFim = new TimeOnly(20, 50, 0);
            int resultMin = horaInicio.ToShortTimeString().CompareTo(onlyHrs);
            int resultMax = horaFim.ToShortTimeString().CompareTo(onlyHrs);
            
            if (resultMin < 0 && resultMax < 0)
            {
                throw new Exception("Fora do horario de votação!");                
            }
            if(containsVoto)
            {                
                throw new Exception("Usuário já votou!");
            }

            return await _repo.CreateVoto(votos);
        }
        public async Task<IEnumerable<Ranking>> GetRanking()
        {
            return await _repo.GetRanking(); 
        }
        public async Task<Ranking> GetOneRanking()
        {
            return await _repo.GetOneRanking();
        }
    }
}

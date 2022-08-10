using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IVotoBAC
    {
        public Task<List<Votos>> GetVoto();

        public Task<string> CreateVoto(Votos votos);

        public Task<IEnumerable<Ranking>> GetRanking();
        public Task<Ranking> GetOneRanking();
    }
}

using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BAC
{
    public class RestauranteBAC : IRestauranteBAC
    {
        private IRestauranteRepo _repo;

        public RestauranteBAC(IRestauranteRepo restauranteRepo)
        {
            _repo = restauranteRepo;
        }

        public async Task<List<Restaurante>> GetRestaurante()
        {            
            return await _repo.GetRestaurante();
        }

        public async Task<string> CreateRestaurante(Restaurante restaurante)
        {
            Random random = new Random();
            int valueInsert = random.Next(1000, 9999);
            List<Restaurante> findRestaurante = await GetRestaurante();

            bool containsRestaurante = findRestaurante.Select(find =>
                find.codigoRestaurante).Contains(valueInsert);
            while (containsRestaurante)
            {
                valueInsert = random.Next(1000, 9999);
                containsRestaurante = findRestaurante.Select(find =>
                find.codigoRestaurante).Contains(valueInsert);
            }
            restaurante.codigoRestaurante = valueInsert;
            if (!containsRestaurante) return await _repo.CreateRestaurante(restaurante);
            throw new Exception("Restaurante já existe ou é nulo!");                
        }
    }
}

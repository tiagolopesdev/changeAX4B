using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRestauranteRepo
    {
        public Task<List<Restaurante>> GetRestaurante();

        public Task<string> CreateRestaurante(Restaurante restaurante);
    }
}

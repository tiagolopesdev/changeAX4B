using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRestauranteBAC 
    {
        public Task<List<Restaurante>> GetRestaurante();

        public Task<string> CreateRestaurante(Restaurante restaurante);
    }
}

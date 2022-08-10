using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUsuarioRepo
    {
        public Task<List<Usuario>> GetUsuario();

        public Task<Usuario> CreateUsuario(Usuario usuario);
    }
}

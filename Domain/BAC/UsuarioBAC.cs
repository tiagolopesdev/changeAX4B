using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BAC
{
    public class UsuarioBAC : IUsuarioBAC
    {
        private IUsuarioRepo _repo;

        public UsuarioBAC(IUsuarioRepo usuarioRepo)
        {
            _repo = usuarioRepo;
        }

        public async Task<List<Usuario>> GetUsuario()
        {
            return await _repo.GetUsuario();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            List<Usuario> findUsuario = await GetUsuario();
            bool containsUsuario = findUsuario.Select(find =>
                find.CodigoUsuario).Contains(usuario.CodigoUsuario);
            if (!containsUsuario) return await _repo.CreateUsuario(usuario);
            throw new Exception("Usuário já existe ou é nulo!");
            return await _repo.CreateUsuario(usuario);
        }
    }
}

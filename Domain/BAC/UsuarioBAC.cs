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
        private IVotoRepo _votoRepo;

        public UsuarioBAC(IUsuarioRepo usuarioRepo, IVotoRepo votoRepo)
        {
            _repo = usuarioRepo;
            _votoRepo = votoRepo;
        }
        public async Task<List<Usuario>> GetUsuarioFilter()
        {                        
            return await _repo.GetUsuarioFilter();
        }
        public async Task<List<Usuario>> GetUsuario()
        {
            return await _repo.GetUsuario();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            Random random = new Random();
            int valueInsert = random.Next(1000, 9999);
            List<Usuario> findUsuario = await GetUsuario();
            bool containsUsuario = findUsuario.Select(find =>
                find.CodigoUsuario).Contains(valueInsert);            
            while (containsUsuario)
            {
                valueInsert = random.Next(1000, 9999);
                containsUsuario = findUsuario.Select(find =>
                find.CodigoUsuario).Contains(valueInsert);
            }
            usuario.CodigoUsuario = valueInsert;
            if (!containsUsuario) return await _repo.CreateUsuario(usuario);
            throw new Exception("Usuário já existe ou é nulo!");
            return await _repo.CreateUsuario(usuario);
        }        
    }
}

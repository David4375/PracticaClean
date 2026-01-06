using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> All()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }

        public async Task Crear(Usuario usuario)
        {
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Usuario?> ObtenerId(Guid id)
        {
            return await _appDbContext.Usuarios.FindAsync(id);
        }
    }
}
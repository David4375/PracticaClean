using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuario
    {
        Task Crear(Usuario usuario);
        Task<IEnumerable<Usuario>> All();
        Task<Usuario?> ObtenerId(Guid id);
        Task Actualizar(Usuario usuario);
    }
}
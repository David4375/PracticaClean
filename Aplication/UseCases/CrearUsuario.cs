using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearUsuario
    {
        private readonly IUsuario _usuarioRepo;

        public CrearUsuario(IUsuario usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task EjecutarAsync(Usuario usuario)
        {
            ValidarUsuario(usuario);
            await _usuarioRepo.Crear(usuario);
        }

        public void ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("El email es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Password))
                throw new ArgumentException("La contraseña es obligatoria");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                throw new ArgumentException("El rol es obligatorio");
        }
    }
}
using System;

namespace Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // Ej: Admin, Veterinario
        public bool Estado { get; set; } = true; // true: Activo, false: Inactivo
    }
}
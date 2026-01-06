using System;

namespace Domain.Entities
{
    public class Medicamento
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // Ej: Antibiótico, Analgésico
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Precio { get; set; }
    }
}
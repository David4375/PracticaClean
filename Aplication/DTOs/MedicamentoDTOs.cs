using System;

namespace Aplication.DTOs
{
    public class MedicamentoDTOs
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Precio { get; set; }
    }
}
using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearMedicamento
    {
        private readonly IMedicamento _medicamentoRepo;

        public CrearMedicamento(IMedicamento medicamentoRepo)
        {
            _medicamentoRepo = medicamentoRepo;
        }

        public async Task EjecutarAsync(Medicamento medicamento)
        {
            ValidarMedicamento(medicamento);
            await _medicamentoRepo.Crear(medicamento);
        }

        private void ValidarMedicamento(Medicamento medicamento)
        {
            if (string.IsNullOrWhiteSpace(medicamento.Nombre))
                throw new ArgumentException("El nombre del medicamento es obligatorio");

            if (string.IsNullOrWhiteSpace(medicamento.Tipo))
                throw new ArgumentException("El tipo de medicamento es obligatorio");

            if (medicamento.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");

            if (medicamento.Precio < 0)
                throw new ArgumentException("El precio no puede ser negativo");

            if (medicamento.FechaVencimiento < DateTime.Now)
                throw new ArgumentException("El medicamento ya está vencido");
        }
    }
}
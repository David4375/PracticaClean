using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class ObtenerMedicamentosVencidos
    {
        private readonly IMedicamento _medicamentoRepo;
        public ObtenerMedicamentosVencidos(IMedicamento medicamentoRepo) => _medicamentoRepo = medicamentoRepo;

        public async Task<IEnumerable<Medicamento>> EjecutarAsync()
        {
            // Compara contra la fecha y hora actual
            return await _medicamentoRepo.ObtenerVencidos(DateTime.Now);
        }
    }
}

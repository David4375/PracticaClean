using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class ObtenerBajoStock
    {
        private readonly IMedicamento _medicamentoRepo;
        public ObtenerBajoStock(IMedicamento medicamentoRepo) => _medicamentoRepo = medicamentoRepo;

        public async Task<IEnumerable<Medicamento>> EjecutarAsync(int limite = 5)
        {
            return await _medicamentoRepo.ObtenerStockBajo(limite);
        }
    }
}

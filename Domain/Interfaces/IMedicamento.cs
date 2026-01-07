using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedicamento
    {
        Task<Medicamento> Crear(Medicamento medicamento);
        Task<IEnumerable<Medicamento>> All();
        Task<Medicamento?> ObtenerId(Guid id);
        // NUEVOS MÉTODOS
        Task<IEnumerable<Medicamento>> ObtenerVencidos(DateTime fechaReferencia);
        Task<IEnumerable<Medicamento>> ObtenerStockBajo(int limite);
    }
}

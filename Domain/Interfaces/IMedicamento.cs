using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedicamento
    {
        Task<Medicamento> Crear(Medicamento medicamento);
        Task<IEnumerable<Medicamento>> All();
        Task<Medicamento?> ObtenerId(Guid id);
    }
}
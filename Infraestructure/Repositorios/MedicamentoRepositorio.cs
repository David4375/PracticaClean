using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositorios
{
    public class MedicamentoRepositorio : IMedicamento
    {
        private readonly AppDbContext _context;
        public MedicamentoRepositorio(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Medicamento>> All()
        {
            // ELIMINADO el .Include(m => m.Usuario)
            return await _context.Medicamentos.ToListAsync();
        }

        public async Task<Medicamento> Crear(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task<Medicamento?> ObtenerId(Guid id)
        {
            return await _context.Medicamentos.FindAsync(id);
        }
    }
}
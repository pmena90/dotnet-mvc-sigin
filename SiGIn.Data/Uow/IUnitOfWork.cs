using SiGIn.Data.Repositories;
using SiGIn.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SiGIn.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Trabajador> TrabajadorRepository { get; set; }
        IGenericRepository<TipoDescuento> TipoDescuentoRepository { get; set; }
        Task<int> CommitAsync();
    }
}

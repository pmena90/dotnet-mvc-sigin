using SiGIn.Data.Repositories;
using SiGIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiGIn.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiGInContext _context;

        private bool disposed = false;

        public UnitOfWork(SiGInContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            TrabajadorRepository = TrabajadorRepository ?? new GenericRepository<Trabajador>(_context);
            TipoDescuentoRepository = TipoDescuentoRepository ?? new GenericRepository<TipoDescuento>(_context);
        }

        public IGenericRepository<Trabajador> TrabajadorRepository { get; set; }
        public IGenericRepository<TipoDescuento> TipoDescuentoRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

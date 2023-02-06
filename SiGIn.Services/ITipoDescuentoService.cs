using Service.Utils;
using SiGIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiGIn.Services
{
    public interface ITipoDescuentoService
    {
        Task<PaginatedList<TipoDescuento>> IndexAsync(string sortOrder, string nameContains, int page, int perPage);

        Task<ITipoDescuentoService> FindByNameAsync(string name);
        
        Task<TipoDescuento> AddAsync(TipoDescuento tipoDescuento);

        Task<TipoDescuento> UpdateAsync(TipoDescuento tipoDescuentoRequest, int tipoDescuentoId);

        Task<int> DeleteAsync(TipoDescuento t);

        IQueryable<TipoDescuento> GetAllIncluding();

        Task<TipoDescuento> GetIncludingAsync(int id);
        
        Task CommitAsync();
    }
}

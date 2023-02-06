using Service.Utils;
using SiGIn.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiGIn.Services
{
    public interface ITrabajadorService
    {
        Task<PaginatedList<Trabajador>> IndexAsync(string sortOrder, string nameContains, int page, int perPage);

        Task<Trabajador> AddAsync(Trabajador trabajador);

        Task<Trabajador> UpdateAsync(Trabajador trabajadorRequest, int trabajadorId);

        Task<int> DeleteAsync(Trabajador t);

        IQueryable<Trabajador> GetAllIncluding();

        Task<Trabajador> GetIncludingAsync(int id);

        Task CommitAsync();
    }
}
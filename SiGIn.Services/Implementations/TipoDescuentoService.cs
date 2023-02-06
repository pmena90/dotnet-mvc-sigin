using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Utils;
using SiGIn.Data.Uow;
using SiGIn.Models.Entities;

namespace SiGIn.Services.Implementations
{
    public class TipoDescuentoService : ITipoDescuentoService
    {
        private readonly IUnitOfWork _uow;

        public TipoDescuentoService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<PaginatedList<TipoDescuento>> IndexAsync(string sortOrder, string nameContains, int page, int perPage)
        {
            var result = GetAllIncluding();

            // filters section
            if (!String.IsNullOrEmpty(nameContains))
                result = result.Where(u => u.Name.Contains(nameContains) || u.Name.Contains(nameContains));

            // end filters section

            // sort order section
            switch (sortOrder)
            {
                case "Name_desc":
                    result = result.OrderByDescending(u => u.Name);
                    break;

                case "Name_asc":
                    result = result.OrderBy(u => u.Name);
                    break;

                case "DateCreated_desc":
                    result = result.OrderByDescending(u => u.DateCreated);
                    break;

                case "DateCreated_asc":
                    result = result.OrderBy(u => u.DateCreated);
                    break;

                case "Description_desc":
                    result = result.OrderByDescending(u => u.Description);
                    break;

                case "Description_asc":
                    result = result.OrderBy(u => u.Description);
                    break;

                default:
                    result = result.OrderBy(u => u.Id);
                    break;
            }
            // end sort order section

            return await PaginatedList<TipoDescuento>.CreateAsync(result, page, perPage);
        }

        public async Task<TipoDescuento> AddAsync(TipoDescuento tipoDescuento)
        {
            tipoDescuento.DateCreated = DateTime.UtcNow;
            tipoDescuento.DateUpdated = DateTime.UtcNow;

            await _uow.TipoDescuentoRepository.AddAsync(tipoDescuento);

            return tipoDescuento;
        }

        public async Task<int> DeleteAsync(TipoDescuento t)
        {
            return await _uow.TipoDescuentoRepository.DeleteAsync(t);
        }

        public Task<ITipoDescuentoService> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoDescuento> GetIncludingAsync(int id)
        {
            var tipoDescuento = await GetAllIncluding().Where(e => e.Id == id).FirstOrDefaultAsync();

            return tipoDescuento ?? throw new Exception();
        }

        public async Task<TipoDescuento> UpdateAsync(TipoDescuento tipoDescuentoRequest, int tipoDescuentoId)
        {
            var tipoDescuento = await GetIncludingAsync(tipoDescuentoId);

            tipoDescuento.Name = tipoDescuentoRequest.Name;
            tipoDescuento.Description = tipoDescuentoRequest.Description;
            tipoDescuento.DateUpdated = DateTime.UtcNow;

            await _uow.TipoDescuentoRepository.UpdateAsync(tipoDescuento, tipoDescuentoId);

            return tipoDescuento;
        }

        public IQueryable<TipoDescuento> GetAllIncluding()
        {
            return _uow.TipoDescuentoRepository.GetAllIncluding();
        }

        public async Task CommitAsync()
        {
            await _uow.CommitAsync();
        }
    }
}
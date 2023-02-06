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
    public class TrabajadorService : ITrabajadorService
    {
        private readonly IUnitOfWork _uow;

        public TrabajadorService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<PaginatedList<Trabajador>> IndexAsync(string sortOrder, string nameContains, int page, int perPage)
        {
            var result = GetAllIncluding();

            // filters section
            if (!String.IsNullOrEmpty(nameContains))
                result = result.Where(u => u.Nombre.Contains(nameContains) || u.Nombre.Contains(nameContains));

            // end filters section

            // sort order section
            switch (sortOrder)
            {
                case "Name_desc":
                    result = result.OrderByDescending(u => u.Nombre);
                    break;

                case "Name_asc":
                    result = result.OrderBy(u => u.Nombre);
                    break;

                case "DateCreated_desc":
                    result = result.OrderByDescending(u => u.DateCreated);
                    break;

                case "DateCreated_asc":
                    result = result.OrderBy(u => u.DateCreated);
                    break;

                case "Apellidos_desc":
                    result = result.OrderByDescending(u => u.Apellidos);
                    break;

                case "Apellidos_asc":
                    result = result.OrderBy(u => u.Apellidos);
                    break;

                default:
                    result = result.OrderBy(u => u.Id);
                    break;
            }
            // end sort order section

            return await PaginatedList<Trabajador>.CreateAsync(result, page, perPage);
        }

        public async Task<Trabajador> AddAsync(Trabajador trabajador)
        {
            trabajador.DateCreated = DateTime.UtcNow;
            trabajador.DateUpdated = DateTime.UtcNow;

            await _uow.TrabajadorRepository.AddAsync(trabajador);

            return trabajador;
        }

        public async Task<int> DeleteAsync(Trabajador t)
        {
            return await _uow.TrabajadorRepository.DeleteAsync(t);
        }

        public async Task<Trabajador> GetIncludingAsync(int id)
        {
            var trabajador = await GetAllIncluding().Where(e => e.Id == id).FirstOrDefaultAsync();

            return trabajador ?? throw new Exception();
        }

        public async Task<Trabajador> UpdateAsync(Trabajador trabajadorRequest, int trabajadorId)
        {
            var trabajador = await GetIncludingAsync(trabajadorId);

            trabajador.Nombre = trabajadorRequest.Nombre;
            trabajador.Apellidos = trabajadorRequest.Apellidos;
            trabajador.ActividadDesempeña = trabajadorRequest.ActividadDesempeña;
            trabajador.Contratado = trabajadorRequest.Contratado;
            trabajador.ContratadoPor = trabajadorRequest.ContratadoPor;
            trabajador.FehaExpedicionTcp = trabajadorRequest.FehaExpedicionTcp;
            trabajador.Ni = trabajadorRequest.Ni;
            trabajador.NoRegistroCreador = trabajadorRequest.NoRegistroCreador;
            trabajador.DateUpdated = DateTime.UtcNow;

            await _uow.TrabajadorRepository.UpdateAsync(trabajador, trabajadorId);

            return trabajador;
        }

        public IQueryable<Trabajador> GetAllIncluding()
        {
            return _uow.TrabajadorRepository.GetAllIncluding();
        }

        public async Task CommitAsync()
        {
            await _uow.CommitAsync();
        }
    }
}
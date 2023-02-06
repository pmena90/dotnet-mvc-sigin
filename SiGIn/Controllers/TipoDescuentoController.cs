using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiGIn.Models.Entities;
using SiGIn.Models.TipoDescuento;
using SiGIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiGIn.Controllers
{
    public class TipoDescuentoController : Controller
    {
        private readonly ITipoDescuentoService _tipoDescuentoService;
        private readonly IMapper _mapper;

        public TipoDescuentoController(ITipoDescuentoService tipoDescuentoService, IMapper mapper)
        {
            _tipoDescuentoService = tipoDescuentoService ?? throw new ArgumentNullException(nameof(tipoDescuentoService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTipoDescuento()
        {
            var model = new TipoDescuentoRequestVM();

            return PartialView("_CreateModalPartial", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(TipoDescuentoRequestVM tipoDescuentoRequest)
        {
            var tipoDescuento = _mapper.Map<TipoDescuento>(tipoDescuentoRequest);

            tipoDescuento = await _tipoDescuentoService.AddAsync(tipoDescuento);
            await _tipoDescuentoService.CommitAsync();

            tipoDescuentoRequest = _mapper.Map<TipoDescuentoRequestVM>(tipoDescuento);

            return PartialView("_CreateModalPartial", tipoDescuentoRequest);
        }

        public async Task<IActionResult> EditTipoDescuentoAsync(int id)
        {
            var tipoDescuento = await _tipoDescuentoService.GetIncludingAsync(id);
            var model = _mapper.Map<TipoDescuentoUpdateVM>(tipoDescuento);

            return PartialView("_UpdateModalPartial", model);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(TipoDescuentoUpdateVM tipoDescuentoRequest)
        {
            var tipoDescuento = _mapper.Map<TipoDescuento>(tipoDescuentoRequest);

            tipoDescuento = await _tipoDescuentoService.UpdateAsync(tipoDescuento, tipoDescuento.Id);
            await _tipoDescuentoService.CommitAsync();

            tipoDescuentoRequest = _mapper.Map<TipoDescuentoUpdateVM>(tipoDescuento);

            return PartialView("_UpdateModalPartial", tipoDescuentoRequest);
        }

        [HttpPost]
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var tipoDescuento = await _tipoDescuentoService.GetIncludingAsync(id);
                await _tipoDescuentoService.DeleteAsync(tipoDescuento);
                await _tipoDescuentoService.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ActionResult Update(int id)
        {
            return View(id);
        }

        public async Task<ActionResult> IndexJsonAsync()
        {
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var draw = Request.Form["draw"].FirstOrDefault();

            var sortOrder = sortColumn + "_" + sortColumnDir;
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();

            var pageSize = length != null ? Convert.ToInt32(length) : 10;
            var page = start != null ? Convert.ToInt32(start) : 0;
            page = page / pageSize;

            try
            {
                var tipoDescuentos = await _tipoDescuentoService
                    .IndexAsync(sortOrder, searchValue, page, pageSize);

                //total number of rows count
                var recordsTotal = tipoDescuentos.TotalItems;
                var data = _mapper.Map<ICollection<TipoDescuentoVM>>(tipoDescuentos);

                //Returning Json Data
                return Json(new
                {
                    draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal,
                    data
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
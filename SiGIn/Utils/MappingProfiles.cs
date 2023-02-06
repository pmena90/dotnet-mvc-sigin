using AutoMapper;
using SiGIn.Models;
using SiGIn.Models.Entities;
using SiGIn.Models.TipoDescuento;
using System;

namespace SiGIn.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BaseEntity, BaseVM>()
                .ForMember(d => d.DateCreated, opts => opts.MapFrom(source => FormatDate(source.DateCreated)))
                .ForMember(d => d.DateUpdated, opts => opts.MapFrom(source => FormatDate(source.DateUpdated)))
                .Include<TipoDescuento, TipoDescuentoVM>();

            CreateMap<TipoDescuentoRequestVM, TipoDescuento>();
            CreateMap<TipoDescuentoUpdateVM, TipoDescuento>();
            CreateMap<TipoDescuento, TipoDescuentoVM>();
            CreateMap<TipoDescuento, TipoDescuentoUpdateVM>();
        }

        private string FormatDate(DateTime dateTime)
        {
            return dateTime.ToLocalTime().ToShortDateString() + " " + dateTime.ToLocalTime().ToShortTimeString();
        }
    }
}
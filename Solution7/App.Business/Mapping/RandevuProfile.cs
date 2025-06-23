using App.Domain.Dtos.Randevu;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Mapping
{
    public class RandevuProfile : Profile
    {
        public RandevuProfile()
        {
            CreateMap<Randevu, RandevuDto>().ReverseMap();
            CreateMap<Randevu, RandevuCreateDto>().ReverseMap();
            CreateMap<Randevu, RandevuUpdateDto>().ReverseMap();
            CreateMap<Randevu, RandevuDeleteDto>().ReverseMap();
        }
    }
}

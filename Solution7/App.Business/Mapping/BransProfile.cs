using App.Domain.Dtos.Brans;
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
    public class BransProfile : Profile
    {
        public BransProfile()
        {
            CreateMap<Bran, BransDto>().ReverseMap();
            CreateMap<Bran, BransCreateDto>().ReverseMap();
            CreateMap<Bran, BransUpdateDto>().ReverseMap();
        }
    }
}

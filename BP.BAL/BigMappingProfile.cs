using AutoMapper;
using BigProject.BP.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.BAL
{
    public class BigMappingProfile : Profile
    {
        public BigMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o=>o.OrderId,ex=>ex.MapFrom(o=>o.Id))
                .ReverseMap();
        }
    }
}

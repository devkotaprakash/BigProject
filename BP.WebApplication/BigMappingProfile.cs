using AutoMapper;
using BigProject.BP.DAL.Entites;
using BP.WebApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.WebApplication
{
    public class BigMappingProfile : Profile
    {
        public BigMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ForMember(o=>o.OrderId,ex=>ex.MapFrom(o=>o.Id)).ReverseMap();
        }
    }
}

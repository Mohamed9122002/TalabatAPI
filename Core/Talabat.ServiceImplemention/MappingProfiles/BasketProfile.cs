﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.BasketModel;
using Talabat.Shared.DataTransferObject.BaskeDTos;

namespace Talabat.ServiceImplemention.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket,BasketDTo>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTo>().ReverseMap();

        }
    }
}

using AutoMapper;
using MVCMovieDB.DTOs;
using MVCMovieDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMovieDB.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Helpers.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<GetCategoryDto, Category>().ReverseMap();
            CreateMap<GetAllCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, GetCategoryDto>().ReverseMap();
        }
    }
}

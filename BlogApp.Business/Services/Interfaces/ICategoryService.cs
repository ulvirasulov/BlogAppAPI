using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs.Category;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> CreateAsync(CreateCategoryDto categoryDto);
        Task<GetCategoryDto> GetById(int id);
        List<GetCategoryDto> GetAll();
        Task Update(UpdateCategoryDto categoryDto);
    }
}

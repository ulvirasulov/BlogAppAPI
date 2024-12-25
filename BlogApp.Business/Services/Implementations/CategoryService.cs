using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helpers.Exceptions.CategoryExceptions;
using BlogApp.Business.Helpers.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _rep;
        readonly IMapper _mapper;
        public CategoryService(ICategoryRepository rep, IMapper mapper)
        {
            _rep = rep;
            this._mapper = mapper;
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            if (await _rep.IsExsist(c => c.Name == categoryDto.Name))
            {
                throw new CategoryNameExsistException();
            }

            var category = _mapper.Map<Category>(categoryDto);

            var newCategory = await _rep.Create(category);
            await _rep.SaveChangesAsync();

            return _mapper.Map<GetCategoryDto>(newCategory);
        }

        public List<GetCategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new NegativeIdException();
            }

            GetCategoryDto dto = _mapper.Map<GetCategoryDto>(await _rep.GetById(id));

            return dto != null ? dto : throw new CategoryNullException();
        }

        public async Task Update(UpdateCategoryDto categoryDto)
        {
            var oldCategory = await GetById(categoryDto.Id);

            if (await _rep.IsExsist(c=>c.Name==categoryDto.Name))
            {
                throw new CategoryNameExsistException();
            }

            oldCategory = _mapper.Map<GetCategoryDto>(categoryDto);

            _rep.Update(_mapper.Map<Category>(oldCategory));
            await _rep.SaveChangesAsync();
        }
    }
}

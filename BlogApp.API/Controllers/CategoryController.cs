using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helpers.Exceptions.CategoryExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(categoryService.GetById(id));
            }
            catch (CategoryNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            try
            {
                return Ok(await categoryService.CreateAsync(categoryDto));
            }
            catch (CategoryNameExsistException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateCategoryDto dto)
        {
            try
            {
                await categoryService.Update(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Business.DTOs.Category
{
    public record UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }

    }
}

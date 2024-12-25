using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BlogApp.Business.DTOs.Category
{
    public record CreateCategoryDto
    {
        public string Name { get; set; }
    }
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name bos olmamalidir!!!")
                .NotNull()
                .WithMessage("Name bos ola bilmez")
                .MaximumLength(20)
                .WithMessage("Uzunluq max 20 ola biler");
        }
    }
}

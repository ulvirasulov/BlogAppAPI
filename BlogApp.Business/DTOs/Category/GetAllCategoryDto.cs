using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class GetAllCategoryDto
    {
        public IQueryable<GetCategoryDto> Categories { get; set; }
    }
}

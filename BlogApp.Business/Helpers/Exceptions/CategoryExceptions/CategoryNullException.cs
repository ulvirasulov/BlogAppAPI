using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Helpers.Exceptions.CategoryExceptions
{
    public class CategoryNullException : Exception
    {
        public CategoryNullException() : base("category tapilmadi.") { }

        public CategoryNullException(string? message) : base(message) { }
    }
}

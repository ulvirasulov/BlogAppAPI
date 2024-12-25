using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Helpers.Exceptions.CategoryExceptions
{
    public class CategoryNameExsistException : Exception
    {
        public CategoryNameExsistException():base("Bele adda category var!"){}

        public CategoryNameExsistException(string? message) : base(message) { }                
    }
}

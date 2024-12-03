using HepsiBuradaApi.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!")
        {
            
        }
    }
}

using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Products.Exceptions;
using HepsiBuradaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNoBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}

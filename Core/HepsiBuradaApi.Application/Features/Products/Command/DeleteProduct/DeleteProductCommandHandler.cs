﻿using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
         public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,  IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor) { }
        
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;

        }

    }
}

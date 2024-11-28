﻿using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


     
        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x=> x.Id == request.Id && !x.IsDeleted);

            var map = _mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x=>x.ProductId==product.Id);

            await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds) 
                await _unitOfWork.GetWriteRepository<ProductCategory>()
                    .AddAsync(new() { CategoryId = categoryId, ProductId = product.Id });

            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }
    }
}

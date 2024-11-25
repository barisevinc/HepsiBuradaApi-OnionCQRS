using Bogus;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Discount).HasPrecision(18, 2);

            Faker faker = new Faker();

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = 5.0m,
                Price = 100.0m,
                CreatedDate = DateTime.Now,
                IsDeleted=false
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = 10.0m,
                Price = 200.0m,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            builder.HasData(product1, product2);

        }
    }
}

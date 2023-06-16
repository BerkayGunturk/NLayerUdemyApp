using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnıtOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCateogryDto>>> GetProductWithCateogry()
        {
            var products = await _productRepository.GetProductsWithCategory(); // tüm datayı aldım
            var productsDTO = _mapper.Map<List<ProductWithCateogryDto>>(products);

            return CustomResponseDto<List<ProductWithCateogryDto>>.Succes(200, productsDTO);

        }
    }
}

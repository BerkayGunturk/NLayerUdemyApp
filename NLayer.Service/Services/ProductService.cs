using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnıtOfWorks;
using System.Collections.Generic;

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

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCateogry()
        {
            var products = await _productRepository.GetProductsWithCategory(); // tüm datayı aldım
            var productsDTO = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Succes(200,productsDTO);

        }
    }
}

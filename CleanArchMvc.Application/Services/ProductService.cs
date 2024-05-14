using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsQuery = new GetProductsQuery() ?? throw new Exception($"Entity could not be found");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO> >(result);
        }
    }

    //public async Task<ProductDTO> GetByIdAsync(int? id)
    //{
    //    var productEntity = await _productRepository.GetByIdAsync(id);
    //    return _mapper.Map<ProductDTO>(productEntity);
    //}

    //public async Task<ProductDTO> GetWithCategoryByIdAsync(int? id)
    //{
    //    var productEntity = await _productRepository.GetWithCategoryByIdAsync(id);
    //    return _mapper.Map<ProductDTO>(productEntity);
    //}

    //public async Task CreateAsync(ProductDTO productDto)
    //{
    //    var productEntity = _mapper.Map<Product>(productDto);
    //    await _productRepository.CreateAsync(productEntity);
    //}

    //public async Task UpdateAsync(ProductDTO productDto)
    //{
    //    var productEntity = _mapper.Map<Product>(productDto);
    //    await _productRepository.UpdateAsync(productEntity);
    //}

    //public async Task RemoveAsync(int? id)
    //{
    //    var productEntity = _productRepository.GetByIdAsync(id).Result;
    //    await _productRepository.RemoveAsync(productEntity);
    //}
}

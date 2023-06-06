using Application.IServices;
using Domain;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DataContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _data;
        private readonly IConfiguration _configuration;

        public ProductService(DataContext data, IConfiguration configuration)
        {
            _data = data;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<ProductDTO>> Create(ProductDTO productDTO)
        {
            var product = new Product{ 
            
                Name = productDTO.Name,
                Description = productDTO.Description,
                isIngredient=productDTO.isIngredient,
                CategoryId = productDTO.CategoryId,
                Images = productDTO.Images,
                ConfigurationPositionId = productDTO.ConfigurationPositionId,
                PriceBrutto = productDTO.PriceBrutto,
                AmountInStock = productDTO.AmountInStock,
                IsActive = productDTO.IsActive, 
            
            };

            _data.Products.Add(product);
            await _data.SaveChangesAsync();
            return new ServiceResponse<ProductDTO> {ReturnMesage = "Created a Prdouct", Success = true };
        }

        public async Task<ServiceResponse<bool>> Delete(int productId)
        {
            var dbProduct = await _data.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Value = false,
                    ReturnMesage = "Product not found."
                };
            }

            dbProduct.IsDeleted = true;

            await _data.SaveChangesAsync();
            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "Product Deleted" };
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetAllAdminProducts()
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response = await _data.Products.Where(p => !p.IsDeleted).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category)
              .ToListAsync();
            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return new ServiceResponse<List<ProductDTO>> { Value= dbProduct, ReturnMesage = "Product List", Success = true };
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetAllProducts()
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response  = await _data.Products.Where(p => p.IsActive && !p.IsDeleted).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).ToListAsync();

            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return  new ServiceResponse<List<ProductDTO>> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetIngridients()
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.isIngredient).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).ToListAsync();

            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return new ServiceResponse<List<ProductDTO>> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetIngridientsByPosition(string position)
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.isIngredient && p.Position.Name == position).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).ToListAsync();
            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return new ServiceResponse<List<ProductDTO>> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetProductByCategory(string Category)
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.Category.Name == Category).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).ToListAsync();
            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return new ServiceResponse<List<ProductDTO>> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<ProductDTO>> GetProductByID(int Id)
        {
            var response = new Product();
            var dbProduct = new ProductDTO();
            response = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);

                var product = new ProductDTO
                {
                    Id = response.Id,
                    Name = response.Name,
                    Description = response.Description,
                    isIngredient = response.isIngredient,
                    CategoryId = response.CategoryId,
                    Images = response.Images,
                    ConfigurationPositionId = response.ConfigurationPositionId,
                    PriceBrutto = response.PriceBrutto,
                    AmountInStock = response.AmountInStock,
                    IsActive = response.IsActive,

                };
            
            return new ServiceResponse<ProductDTO> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<List<ProductDTO>>> GetProductByPosition(string position)
        {
            var response = new List<Product>();
            var dbProduct = new List<ProductDTO>();
            response = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.Position.Name == position).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).ToListAsync();

            foreach (var productDTO in response)
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    isIngredient = productDTO.isIngredient,
                    CategoryId = productDTO.CategoryId,
                    Images = productDTO.Images,
                    ConfigurationPositionId = productDTO.ConfigurationPositionId,
                    PriceBrutto = productDTO.PriceBrutto,
                    AmountInStock = productDTO.AmountInStock,
                    IsActive = productDTO.IsActive,

                };

                dbProduct.Add(product);
            }
            return new ServiceResponse<List<ProductDTO>> { Value = dbProduct, ReturnMesage = "Product List", Success = true }; ;
        }

        public async Task<ServiceResponse<ProductDTO>> Update(ProductDTO product,int Id)
        {
            Product Product=new Product();
            try
            {
                Product = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
                Product.Name = product.Name;
                Product.Description = product.Description;
                Product.isIngredient = product.isIngredient;
                Product.CategoryId = product.CategoryId;
                Product.Images = product.Images;
                Product.ConfigurationPositionId = product.ConfigurationPositionId;
                Product.PriceBrutto = product.PriceBrutto;
                Product.AmountInStock = product.AmountInStock;
                Product.IsActive = product.IsActive;

            }
            catch (Exception ex)
            {
                new ServiceResponse<ProductDTO> { ReturnMesage = "No ProductFound", Success = false };
            }


            
            _data.SaveChanges();
            return  new ServiceResponse<ProductDTO> { Value = product, ReturnMesage = "Updated the Prdouct", Success = true };


        }

        //public static string GetTimestamp(DateTime value)
        //{
        //    return value.ToString("yyyyMMddHHmmssffff");
        //}


        //public async Task Upload(IFormFile file,string Name)
        //{
        //    string ftpPassword = _configuration.GetSection("FtpSettings:Password").Value;
        //    string url = "win6047.site4now.net\t\\cukiernia" + Name;
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
        //    request.Credentials = new NetworkCredential("kowiel", ftpPassword);
        //    request.Method = WebRequestMethods.Ftp.UploadFile;

        //    using (Stream ftpStream = request.GetRequestStream())
        //    {
        //        file.CopyTo(ftpStream);
        //    }
        //}
    }
}

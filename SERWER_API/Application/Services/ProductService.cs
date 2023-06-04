using Application.IServices;
using Domain;
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
        public async Task<ServiceResponse<Product>> Create(Product product)
        {
            _data.Products.Add(product);
            await _data.SaveChangesAsync();
            return new ServiceResponse<Product> { Value = product, ReturnMesage = "Created a Prdouct", Success = true };
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

        public async Task<ServiceResponse<List<Product>>> GetAllAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _data.Products.Where(p => !p.IsDeleted).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category)
               .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _data.Products.Where(p => p.IsActive && !p.IsDeleted).Include(p => p.Images).Include(b => b.Position).Include(c=>c.Category)
               .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string Category)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.Category.Name==Category).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category)
              .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductByID(int Id)
        {
            var response = new ServiceResponse<Product>()
            {
                Value = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted)
        };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductByPosition(string position)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Value = await _data.Products.Where(p => p.IsActive && !p.IsDeleted && p.Position.Name == position  ).Include(p => p.Images).Include(b => b.Position).Include(c => c.Category)
             .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> Update(Product product,int Id)
        {
            var Product = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);

            Product.Name = product.Name;
            Product.Description = product.Description;
            Product.isIngredient = product.isIngredient;
            Product.CategoryId= product.CategoryId;
            Product.Images = product.Images;
            Product.ConfigurationPositionId = product.ConfigurationPositionId;
            Product.PriceBrutto = product.PriceBrutto;
            Product.AmountInStock = product.AmountInStock;
            Product.IsActive= product.IsActive;
            Product.IsDeleted= product.IsDeleted;

            _data.SaveChanges();
            return  new ServiceResponse<Product> { Value = Product, ReturnMesage = "Updated the Prdouct", Success = true };


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

using APISemana11A.Models;
using APISemana11A.Requests;
using APISemana11A.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace APISemana11A.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsCustomController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public ProductsCustomController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public  List<Product> GetAll()
        {
            return _context.Products.ToList();
        }


        [HttpGet]
        //public List<Product> GetByName([FromQuery] string name)
        public List<Product> GetByName(string name)
        {
            return _context.Products.Where(x=>x.Name.Contains(name)).ToList();
        }

        [HttpGet]
        public Product GetById(int Id)
        {
            return _context.Products.Where(x => x.ProductID == Id).FirstOrDefault();
            //var products = _context.Products.Where(x => x.ProductID == Id).ToList();
            //if (products.Count > 0)
            //    return products[0];
            //else
            //    return new Product();            
        }

        //[HttpPost]
        //public void Insert( Product product)
        //{
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //}


        [HttpPost]
        public void InsertRange(List<Product> products)
        {
            //foreach (var item in products)
            //{
            //    _context.Products.Add(item);
            //    _context.SaveChanges();
            //}            
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        [HttpPut]        
        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPut]
        public void UpdatePrice(ProductRequestV1 request)
        {
            //Busco el producto con la información
            Product product = _context.Products.Where(x => x.ProductID == request.Id).FirstOrDefault();

            product.Price = request.Price;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

        }

        [HttpPost]
        public void Insert(ProductInsert request)
        {

            Product product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Active = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }


        [HttpGet]
        public List<ProductResponseV1> GetAllPrice()
        {
            List<Product> products= _context.Products.ToList();

            var response = products.Select(x => 
                                            new ProductResponseV1 { 
                                            Id=x.ProductID,
                                            Price=x.Price   }
                                    ).ToList();

            return response;

        }

        [HttpGet]
        public List<ProductResponseV2> GetAllCategory()
        {
            List<Product> products = _context.Products.ToList();

            var response = products.Select(x =>
                                            new ProductResponseV2
                                            {
                                                Id = x.ProductID,
                                                Category = x.Category
                                            }
                                    ).ToList();

            return response;
        }


    }
}

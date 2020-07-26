﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // public IProductsRepository ProductsRepository { get; set; } 
        // = new InMemoryProductsRepository();

        public IProductController ProductsRepository { get; set; }

       // private IProductsRepository _productsRepository;
       // public ProductController(IProductsRepository productsRepository)
       // {
       //    _productsRepository = productsRepository;
       // }
        public ViewResult List()
        {
            // return View(ProductsRepository.Products);
            var model = ProductsRepository.Products;
            return View(model);
        }
    }
}
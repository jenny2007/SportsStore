using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    // A->B,C,D
    //A a=new A(b,c,d)
    //B b= new B(e,f,g)
    //C c=new C(h,i,j)
    //D d=new D(k,l,m)
    //E e=new E();
    public class ProductController : Controller
    {
        // public IProductsRepository ProductsRepository { get; set; } 
        // = new InMemoryProductsRepository();

        public IProductsRepository ProductsRepository { get; set; }

        // private IProductsRepository _productsRepository;
        // public ProductController(IProductsRepository productsRepository)
        // {
        //    _productsRepository = productsRepository;
        // }

        public int PageSize = 5;
        // public ViewResult List(int page = 1)
        // {
        // return View(ProductsRepository.Products);
        //     var model = ProductsRepository
        //         .Products
        //         .OrderBy(p->p.ProductId)
        //         .Skip((page - 1) * PageSize)
        //         .Take(PageSize);

        //     return View(model);
        // }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
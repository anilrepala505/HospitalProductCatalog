using AutoMapper;
using HospitalProductCatalog.Models;
using HospitalProductCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.Mapper
{
    public class Mapping : Profile
    {
        /// <summary>
        /// created maps between classes
        /// </summary>
        public Mapping()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<BarcodeList, BarcodeResource>();
            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>();
        }
    }
}

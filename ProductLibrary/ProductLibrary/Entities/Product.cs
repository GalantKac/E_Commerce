using System;

namespace ProductLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}

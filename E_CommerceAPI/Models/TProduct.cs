using System;
using System.Collections.Generic;

namespace E_CommerceAPI
{
    public partial class TProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PicturePath { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }

        public virtual TProductType ProductBrand { get; set; }
        public virtual TProductBrand ProductType { get; set; }
    }
}

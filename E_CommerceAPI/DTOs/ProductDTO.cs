using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.DTOs
{
    /// <summary>
    /// Product data transfer object - klasa której obiekt przenosi dane miedzy procesami
    /// </summary>
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PicturePath { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
    }
}

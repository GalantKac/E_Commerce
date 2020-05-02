using System;
using System.Collections.Generic;

namespace E_CommerceAPI
{
    public partial class TProductBrand
    {
        public TProductBrand()
        {
            TProduct = new HashSet<TProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TProduct> TProduct { get; set; }
    }
}

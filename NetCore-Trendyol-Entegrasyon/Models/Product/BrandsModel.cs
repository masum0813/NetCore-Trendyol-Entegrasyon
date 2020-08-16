using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace NetCore_Trendyol_Entegrasyon.Models.Product
{

    public class BrandsList{

        public List<BrandsModel> brands { get; set; }

    }
    public class BrandsModel{


        public int id { get; set; }
        public string name { get; set; }

    }

}
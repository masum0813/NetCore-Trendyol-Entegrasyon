using System;
using System.Collections.Generic;

namespace NetCore_Trendyol_Entegrasyon.Models.Product
{

    public class CategoryList
    {
        public List<CategoryModel> categories { get; set; }

    }
    public class CategoryModel
    {

        public int id { get; set; }
        public int parentId { get; set; }

        // public string code { get; set; }

        public string name { get; set; }

        public List<CategoryModel> subCategories { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using NetCore_Trendyol_Entegrasyon.Models.Product;

namespace NetCore_Trendyol_Entegrasyon.Models.Product
{

    public class CategoryAttributeModel
    {

        public int id { get; set; }

        public string name { get; set; }

        public string displayName { get; set; }

        public List<CategoryAttributeListModel> categoryAttributes { get; set; }

    }
    public class CategoryAttributeListModel
    {

        public int categoryId { get; set; }

        public AttributeModel attribute { get; set; }

        public bool required { get; set; }

        public bool allowCustom { get; set; }

        public bool varianter { get; set; }

        public bool slicer { get; set; }

        public List<AttributeModel> attributeValues { get; set; }





    }

}
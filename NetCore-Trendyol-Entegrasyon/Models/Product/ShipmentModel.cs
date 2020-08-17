using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;

namespace NetCore_Trendyol_Entegrasyon.Models.Product
{

    public class ShipmentModel
    {

        public int id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public string taxNumber { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using NetCore_Trendyol_Entegrasyon.Models.Product;
using System.Text.Json;

namespace NetCore_Trendyol_Entegrasyon.Controllers.Product
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {




        /// <summary>
        /// Get BrandListFrom Trendyol
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Brands
        ///
        /// </remarks>
        /// <returns>List of Brands</returns>
        [HttpGet]
        public async Task<List<BrandsModel>> GetBrands()
        {
            var brandList = new List<BrandsModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.trendyol.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("sapigw/brands");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    brandList = JsonSerializer.Deserialize<BrandsList>(content).brands;
                }

            }

            return brandList;
        }

    }

}
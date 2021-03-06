using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using NetCore_Trendyol_Entegrasyon.Models.Product;
using System.Text.Json;
using NetCore_Trendyol_Entegrasyon.Models.Api;
using Microsoft.Extensions.Options;

namespace NetCore_Trendyol_Entegrasyon.Controllers.Product
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {

        private ApiModel _apiModel { get; }
        public BrandsController(IOptions<ApiModel> apiModel)
        {
            _apiModel = apiModel.Value;
        }

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
            try
            {
                var content = await GetResponse();
                brandList = JsonSerializer.Deserialize<BrandsList>(content).brands;

            }
            catch (System.Exception)
            {

                throw;
            }

            return brandList;
        }

        /// <summary>
        /// Get BrandListFrom Trendyol
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Brands/by-name?name={0}
        ///
        /// </remarks>
        /// <param name="brandName">Markanın adı</param>
        /// <returns>List of Brands</returns>
        [HttpGet("{brandName}")]
        // [HttpGet("{city}/{country}")]
        public async Task<List<BrandsModel>> GetBrandsWithName(string brandName)
        {
            var brandList = new List<BrandsModel>();

            var content = await GetResponse(brandName);
            brandList = JsonSerializer.Deserialize<List<BrandsModel>>(content);

            return brandList;
        }



        private async Task<string> GetResponse(string brandName = "")
        {
            var retVal = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiModel.ProdRootUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestUrl = "brands";
                if (!string.IsNullOrEmpty(brandName))
                {
                    requestUrl = string.Format("brands/by-name?name={0}", brandName);
                }

                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    retVal = await response.Content.ReadAsStringAsync();

                }
            }

            return retVal;


        }

    }

}
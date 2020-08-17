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
    public class ShipmentController : ControllerBase
    {

        private ApiModel _apiModel { get; }
        public ShipmentController(IOptions<ApiModel> apiModel)
        {
            _apiModel = apiModel.Value;
        }

        /// <summary>
        /// Trendyol Shipment Providers List
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Shipment
        ///
        /// </remarks>
        /// <returns>List of Brands</returns>
        [HttpGet]
        public async Task<List<ShipmentModel>> GetBrands()
        {
            var brandList = new List<ShipmentModel>();
            try
            {
                var content = await GetResponse();
                brandList = JsonSerializer.Deserialize<List<ShipmentModel>>(content);

            }
            catch (System.Exception)
            {

                throw;
            }

            return brandList;
        }

        private async Task<string> GetResponse()
        {
            var retVal = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiModel.ProdRootUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestUrl = "shipment-providers";

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
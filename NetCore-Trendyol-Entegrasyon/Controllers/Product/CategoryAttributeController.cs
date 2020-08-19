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
using NetCore_Trendyol_Entegrasyon.Library;

namespace NetCore_Trendyol_Entegrasyon.Controllers.Product
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryAttributeController : ControllerBase
    {

        public string applicationUrl { get { return "product-categories/{0}/attributes"; } }

        private ApiModel _apiModel { get; }
        public CategoryAttributeController(IOptions<ApiModel> apiModel)
        {
            _apiModel = apiModel.Value;
        }


        /// <summary>
        /// Trendyol Category Attribute List
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /CategoryAttribute
        ///
        /// </remarks>
        /// <returns>List of CategoryAttribute</returns>
        [HttpGet]
        public async Task<CategoryAttributeModel> GetCategoryAttribute(int categoryId)
        {
            var categoryAttributeList = new CategoryAttributeModel();
            try
            {
                var myHttpClient = new MyHttpClient();
                var content = await myHttpClient.GetResponse(_apiModel.ProdRootUrl, string.Format(applicationUrl, categoryId));
                categoryAttributeList = JsonSerializer.Deserialize<CategoryAttributeModel>(content);

            }
            catch (System.Exception)
            {

                throw;
            }

            return categoryAttributeList;

        }

    }
}

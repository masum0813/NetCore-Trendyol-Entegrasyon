using System;



using System.Net.Http;
using System.Net.Http.Headers;
using NetCore_Trendyol_Entegrasyon.Models.Product;
using System.Text.Json;
using NetCore_Trendyol_Entegrasyon.Models.Api;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using NetCore_Trendyol_Entegrasyon.Library;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NetCore_Trendyol_Entegrasyon.Controllers.Product
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        public string applicationUrl { get { return "product-categories"; } }
        private ApiModel _apiModel { get; }
        public CategoryController(IOptions<ApiModel> apiModel)
        {
            _apiModel = apiModel.Value;
        }

        /// <summary>
        /// Trendyol Category List
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Category
        ///
        /// </remarks>
        /// <returns>List of Category</returns>
        [HttpGet]
        public async Task<List<CategoryModel>> GetBrands()
        {
            var categoryList = new List<CategoryModel>();
            try
            {
                var myHttpClient = new MyHttpClient();
                var content = await myHttpClient.GetResponse(_apiModel.ProdRootUrl, applicationUrl);
                categoryList = JsonSerializer.Deserialize<CategoryList>(content).categories;

            }
            catch (System.Exception)
            {

                throw;
            }

            return categoryList;
        }

    }
}

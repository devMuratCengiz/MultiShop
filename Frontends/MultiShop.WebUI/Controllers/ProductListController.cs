using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }
        public async Task<IActionResult> ProductDetail(string idx)
        {
            ViewBag.x = idx;
            return View();
        }
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto,string pid)
        {
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.Rating = 3;
            createCommentDto.ImageUrl = "test";
            createCommentDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View();
        }
    }

}

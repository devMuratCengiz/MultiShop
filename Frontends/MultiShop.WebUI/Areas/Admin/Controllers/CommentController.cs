using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _commentService.GetAllCommentsAsync();
            return View(values);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto createCommentDto)
        {
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string id)
        {
            var value = await _commentService.GetByIdCommentAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index");
        }
    }
}

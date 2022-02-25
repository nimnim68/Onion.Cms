using Microsoft.AspNetCore.Mvc;
using Store.Blazor.Shared.Models;

namespace Store.Blazor.Server.Api.Blog.Post
{
    [Route("api/blog/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        [HttpGet]
        public ApiBlogListResponse Get(int page = 1)
        {
            return null;
        }
    }
}

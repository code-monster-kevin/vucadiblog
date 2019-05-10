using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogService.Models;
using BlogService.Repositories;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogsRepository _blogsRepository;

        public BlogsController(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _blogsRepository.GetAll();
        }
    }
}
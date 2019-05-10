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
            return await _blogsRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<string> AddBlog(string title, string description, string body)
        {
            Blog blog = new Blog();
            blog.ID = Guid.NewGuid().ToString();
            blog.Title = title;
            blog.Description = description;
            blog.Body = body;
            blog.CreateDateTime = DateTime.UtcNow;
            blog.Author = CreateTestAuthor();

            return await _blogsRepository.AddBlogAsync(blog);
        }

        // TODO: Removed and replaced with actual author repo
        private Author CreateTestAuthor()
        {
            return new Author
            {
                ID = Guid.NewGuid().ToString(),
                CreateDateTime = DateTime.UtcNow,
                UserName = "Testuser1",
                Email = "test@blogservice.com",
                Image = String.Empty,
                Bio = "A test user specifically for test project"                
            };
        }
    }
}
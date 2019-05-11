using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogService.Repositories;
using BlogService.Models;

namespace BlogService.IntegrationTest.MockRepositories
{
    /*
       Memory Blog Repository
    */
    public class MBlogsRepository : IBlogsRepository
    {
        private Author _author;
        private ICollection<Blog> _blogs;

        public MBlogsRepository()
        {
            _author = CreateTestAuthor();
            _blogs = CreateTestBlog();
        }

        public async Task<IQueryable<Blog>> GetAllAsync()
        {
            return await Task.Run(() => _blogs.AsQueryable());
        }

        public async Task<string> AddBlogAsync(Blog blog)
        {
            await Task.Run(() => _blogs.Add(blog));
            return blog.ID;
        }

        private Blog CreateBlog(string title, string description, string body)
        {
            Blog blog = new Blog();
            blog.ID = Guid.NewGuid().ToString();
            blog.Title = title;
            blog.Description = description;
            blog.Body = body;
            blog.CreateDateTime = DateTime.UtcNow;
            blog.Author = _author;

            return blog;
        }

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

        private ICollection<Blog> CreateTestBlog()
        {
            ICollection<Blog> blogs = new List<Blog>();
            blogs.Add(CreateBlog(
                "My first blog",
                "A simple test blog for testing",
                "This is a blog to test the blog service and see how well it works"
            ));
            blogs.Add(CreateBlog(
                "My second blog",
                "A second test blog for testing",
                "This is another blog to test the blog service and see how well it works"
            ));

            return blogs;
        }
    }

}
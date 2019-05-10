using Xunit;
using System.Collections.Generic;
using System.Linq;
using BlogService.Models;
using BlogService.Repositories;
using BlogService.IntegrationTest.MockRepositories;

namespace BlogService.Controllers
{
    public class BlogsControllerTest
    {
        private MBlogsRepository _blogsRepository;
        private BlogsController _blogsController;
        public BlogsControllerTest()
        {
            _blogsRepository = new MBlogsRepository();
            _blogsController = new BlogsController(_blogsRepository);
        }

        [Fact]
        public async void QueryBlogsListReturnBlogs()
        {
            // Act
            List<Blog> blogs = new List<Blog>
            (
                await _blogsController.GetBlogs()
            );
            // Assert
            Assert.Equal(2, blogs.Count);
        }

        [Fact]
        public async void CreateNewBlog()
        {
            string blogId = await _blogsController.AddBlog("api blog", "a blog added from api", "Testing adding a new blog from API");

            Assert.NotNull(blogId);
        }
    }
}
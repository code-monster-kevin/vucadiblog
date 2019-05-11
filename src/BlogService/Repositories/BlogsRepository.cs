using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogService.Models;
using BlogService.Persistence;

namespace BlogService.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private BlogServiceContext _context;

        public BlogsRepository(BlogServiceContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Blog>> GetAllAsync()
        {
            return await Task.Run(() => _context.Blogs);
        }

        public async Task<string> AddBlogAsync(Blog blog)
        {
            await Task.Run(() => {
                _context.Add(blog);
                _context.SaveChangesAsync();
            });
            return blog.ID;
        }
    }

}
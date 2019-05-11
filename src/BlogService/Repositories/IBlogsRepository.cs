using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogService.Models;

namespace BlogService.Repositories
{
    public interface IBlogsRepository
    {
        Task<IQueryable<Blog>> GetAllAsync();
        Task<string> AddBlogAsync(Blog blog);
    }
}
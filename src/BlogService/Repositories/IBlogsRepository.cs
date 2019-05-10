using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogService.Models;

namespace BlogService.Repositories
{
    public interface IBlogsRepository
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<string> AddBlogAsync(Blog blog);
    }
}
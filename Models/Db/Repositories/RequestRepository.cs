﻿using Microsoft.EntityFrameworkCore;
using WebApp.Models.Db.Entities;

namespace WebApp.Models.Db.Repositories
{
    public class RequestRepository: IRequestRepository
    {
        private BlogContext _blogContext;

        public RequestRepository(BlogContext blogContext) { _blogContext = blogContext; }

        public async Task AddRequest(Request request)
        {
            
            var entry = _blogContext.Entry(request);
            if (entry.State == EntityState.Detached)
                await _blogContext.Requests.AddAsync(request);

            await _blogContext.SaveChangesAsync();
        }
        public async Task<Request[]> GetRequest()
        {
            return await _blogContext.Requests.ToArrayAsync();
        }
    }
}

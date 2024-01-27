using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class BookMakerQuery
    {

        [UseFiltering]
        public async Task<List<Bookmarker>> GetBookmarkers(CancellationToken ct, MyAppDbContext dbContext)
        {
            return await dbContext.Bookmarkers.ToListAsync(ct);
        }

        // public async Task<Bookmarker?> GetBookmarker(MyAppDbContext dbContext, int id)
        // {
        //     return await dbContext.Bookmarkers
        //     .Include(b => b.Bookmarkers)
        //     .FirstOrDefaultAsync(b => b.Id == id);
        // }
    }
}
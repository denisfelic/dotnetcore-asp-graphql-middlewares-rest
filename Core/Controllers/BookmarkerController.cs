
using System.Threading;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Database;
using dotnetcore_asp.Core.Models;
using dotnetcore_asp.Core.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkerController : ControllerBase
    {

        private readonly MyAppDbContext _dbContext;

        public BookmarkerController(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookmarkersAsync(CancellationToken cancellationToken)
        {

            var bookmarkers = await _dbContext.Bookmarkers.Include(b => b.Bookmarkers)
            .ToListAsync();
            return Ok(bookmarkers);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBookmarker(int Id)
        {
            var bookmarker = await _dbContext.Bookmarkers.Include(b => b.Bookmarkers).FirstOrDefaultAsync(b => b.Id == Id);

            if (bookmarker is null)
            {
                return NotFound();
            }

            return Ok(bookmarker);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBookmarker([FromBody] CreateBookmarkerModel createBookmarkerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdBookmarker = new Bookmarker
            {
                Name = createBookmarkerModel.Name,
                Url = createBookmarkerModel.Url,
                BookmarkerId = createBookmarkerModel.Bookmarkerid
            };

            await _dbContext.AddAsync(createdBookmarker);
            await _dbContext.SaveChangesAsync();

            return Ok(createdBookmarker);
        }
    }
}
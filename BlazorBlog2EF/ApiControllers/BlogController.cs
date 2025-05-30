using BlazorBlog2EF.Data;
using BlazorBlog2EF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog2EF.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController(ApplicationDbContext db) : ControllerBase
    {
        private readonly ApplicationDbContext _db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dbData = await _db.PostModels.ToListAsync();
            return Ok(dbData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok( await _db.PostModels.FindAsync(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(value + ". Returned from controller!");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PostModel postModel)
        {
            _db.Update(postModel);
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var dbData = await _db.PostModels.FindAsync(id);

            if (dbData == null) return;
            
            _db.PostModels.Remove(dbData);
            _db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientApi.Models;

namespace BOSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorSheetController : ControllerBase
    {
        private readonly FloorSheetContext _context;

        public FloorSheetController(FloorSheetContext context)
        {
            _context = context;
        }

        // GET: api/FloorSheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorSheet>>> GetFloorSheet()
        {
            if (_context.FloorSheet == null)
            {
                return NotFound();
            }
            return await _context.FloorSheet.ToListAsync();
        }

        // GET: api/FloorSheet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FloorSheet>> GetFloorSheet(Guid id)
        {
            if (_context.FloorSheet == null)
            {
                return NotFound();
            }
            var floorSheet = await _context.FloorSheet.FindAsync(id);

            if (floorSheet == null)
            {
                return NotFound();
            }

            return floorSheet;
        }

        // PUT: api/FloorSheet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutFloorSheet(Guid id, FloorSheet floorSheet)
        {
            if (id != floorSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(floorSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloorSheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FloorSheet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please provide a file.");

            var fileName = Path.GetFileName(file.FileName); //declaring file name "file"
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var filePath = Path.Combine(homeDir, "Downloads", fileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok($"File {fileName} has been uploaded.");
        }


        // DELETE: api/FloorSheet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloorSheet(Guid id)
        {
            if (_context.FloorSheet == null)
            {
                return NotFound();
            }
            var floorSheet = await _context.FloorSheet.FindAsync(id);
            if (floorSheet == null)
            {
                return NotFound();
            }

            _context.FloorSheet.Remove(floorSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FloorSheetExists(Guid id)
        {
            return (_context.FloorSheet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

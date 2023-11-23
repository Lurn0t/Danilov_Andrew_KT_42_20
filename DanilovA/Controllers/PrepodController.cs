using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DanilovA.Filters.PrepodKafedraFilters;
using DanilovA.Database;
using Microsoft.EntityFrameworkCore;
using DanilovA.Models;
using DanilovA.Interfaces;

namespace DanilovA.Controllers
{
    [ApiController]
    [Route("prepod")]
    public class PrepodController : Controller
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;
        private PrepodDbContext _context;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService, PrepodDbContext context)
        {
            _logger = logger;
            _prepodService = prepodService;
            _context = context;
        }

        [HttpPost(Name = "GetPrepodsByKafedra")]
        public async Task<IActionResult> GetPrepodsByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodsByKafedraAsync(filter, cancellationToken);

            return Ok(prepod);
        }
        //добавление для преподов
        [HttpPost("AddPrepod", Name = "AddPrepod")]
        public IActionResult CreatePrepod([FromBody] Prepod prepod)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var gr = _context.Kafedra.FirstOrDefault(g => g.KafedraId == prepod.KafedraId);
            if (gr != null)
            {
                prepod.Kafedra = gr;
            }

            var deg = _context.Degree.FirstOrDefault(d => d.DegreeId == prepod.DegreeId);
            if (deg != null)
            {
                prepod.Degree = deg;
            }

            _context.Prepod.Add(prepod);
            _context.SaveChanges();
            return Ok(prepod);
        }

        [HttpPut("EditPrepod")]
        public IActionResult UpdatePrepod(string firstname, [FromBody] Prepod updatedPrepod)
        {
            var existingPrepod = _context.Prepod.FirstOrDefault(g => g.FirstName == firstname);

            if (existingPrepod == null)
            {
                return NotFound();
            }

            existingPrepod.FirstName = updatedPrepod.FirstName;
            existingPrepod.LastName = updatedPrepod.LastName;
            existingPrepod.MiddleName = updatedPrepod.MiddleName;
            existingPrepod.Telephone = updatedPrepod.Telephone;
            existingPrepod.Mail = updatedPrepod.Mail;
            existingPrepod.KafedraId = updatedPrepod.KafedraId;
            existingPrepod.DegreeId = updatedPrepod.DegreeId;
            _context.SaveChanges();

            return Ok();
        }
        //добавление для кафедры
        [HttpPost("AddKafedra", Name = "AddKafedra")]
        public IActionResult CreateKafedra([FromBody] DanilovA.Models.Kafedra kafedra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kafedra.Add(kafedra);
            _context.SaveChanges();
            return Ok(kafedra);
        }

        [HttpPut("EditKafedra")]
        public IActionResult UpdateKafedra(string kafedraname, [FromBody] Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraname);

            if (existingKafedra == null)
            {
                return NotFound();
            }

            existingKafedra.KafedraName = updatedKafedra.KafedraName;
            _context.SaveChanges();

            return Ok();
        }
        //удаление для кафедры
        [HttpDelete("DeleteKafedra")]
        public IActionResult DeleteKafedra(string kafedraName, DanilovA.Models.Kafedra updatedKafedra)
        {
            var existingKafedra = _context.Kafedra.FirstOrDefault(g => g.KafedraName == kafedraName);

            if (existingKafedra == null)
            {
                return NotFound();
            }
            _context.Kafedra.Remove(existingKafedra);
            _context.SaveChanges();

            return Ok();
        }
    }
}

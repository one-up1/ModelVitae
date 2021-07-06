using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModelVitae.Data.Models;
using ModelVitae.Data.Services;

namespace ModelVitae.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly ModelDbContext _context;
        private readonly IHostEnvironment hostingEnvironment;

        public ModelsController(ModelDbContext context, IHostEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            return View(await _context.Models.ToListAsync());
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,Gender,DateOfBirth,Weight,Height,Waist,Image,PhoneNumber,EmailAdress,EyeColor,HairColor")] Model model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    model.ImageName = model.Image.FileName;
                    model.Image.CopyTo(new FileStream(Path.Combine(Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/uploads"), model.ImageName), FileMode.Create));
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,Gender,DateOfBirth,Weight,Height,Waist,Image,PhoneNumber,EmailAdress,EyeColor,HairColor")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Image != null)
                    {
                        model.ImageName = model.Image.FileName;
                        model.Image.CopyTo(new FileStream(Path.Combine(Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/uploads"), model.ImageName), FileMode.Create));
                    }

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Models.FindAsync(id);
            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.Id == id);
        }
    }
}

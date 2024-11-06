using ExpertsGulfPortal.Data;
using ExpertsGulfPortal.Models;
using ExpertsGulfPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertsGulfPortal.Controllers
{
    public class ArbitratorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ArbitratorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddArbitratorsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, return the same view with the model to display validation errors
                return View(viewModel);
            }
            var arbitrator = new Arbitrators
            {
               
                Nationality = viewModel.Nationality, // الجنسية
                PreferredLanguage = viewModel.PreferredLanguage, // اللغه المفضلة
                Gender = viewModel.Gender, // الجنس
                Entities = viewModel.Entities, // الجهات
                
                Country = viewModel.Country, // الدولة
                City = viewModel.City, // المدينة
                AcademicDegree = viewModel.AcademicDegree, // الدرجة العلمية الحاصل عليها
                GeneralSpecialization = viewModel.GeneralSpecialization, // التخصص العام
                SpecificSpecialization = viewModel.SpecificSpecialization, // التخصص الدقيق
                MastersThesisTitle = viewModel.MastersThesisTitle, // موضوع رسالة الماجستير
                DoctoralThesisTitle = viewModel.DoctoralThesisTitle // موضوع رسالة الدكتوراه
            };

            await dbContext.Arbitrators.AddAsync(arbitrator);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Arbitrators");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var arbitrators = await dbContext.Arbitrators.ToListAsync();
            return View(arbitrators);
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            // Retrieve the arbitrator by ID from the database
            var arbitrator = await dbContext.Arbitrators.FindAsync(id);

            // Check if the arbitrator exists
            if (arbitrator == null)
            {
                return NotFound(); // Return a 404 if not found
            }

            // Return the view with the arbitrator details
            return View(arbitrator);
        }

    }
}

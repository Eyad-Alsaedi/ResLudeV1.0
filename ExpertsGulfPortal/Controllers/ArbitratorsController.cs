using ExpertsGulfPortal.Data;
using ExpertsGulfPortal.Models;
using ExpertsGulfPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpertsGulfPortal.Services;
using System;
using System.Threading.Tasks;

namespace ExpertsGulfPortal.Controllers
{
    public class ArbitratorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly EmailService _emailService;

        public ArbitratorsController(ApplicationDbContext dbContext, EmailService emailService)
        {
            this.dbContext = dbContext;
            _emailService = emailService;
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

            string subject = "ResLude - طلب محكم";
            string body = $"طلب محكم جديد:\n\n" +
                          $"الجنسية: {arbitrator.Nationality}\n" +
                          $"اللغة المفضلة: {arbitrator.PreferredLanguage}\n" +
                          $"الجنس: {arbitrator.Gender}\n" +
                          $"الجهات: {arbitrator.Entities}\n" +
                          $"الدولة: {arbitrator.Country}\n" +
                          $"المدينة: {arbitrator.City}\n" +
                          $"الدرجة العلمية: {arbitrator.AcademicDegree}\n" +
                          $"التخصص العام: {arbitrator.GeneralSpecialization}\n" +
                          $"التخصص الدقيق: {arbitrator.SpecificSpecialization}\n" +
                          $"عنوان رسالة الماجستير: {arbitrator.MastersThesisTitle}\n" +
                          $"عنوان رسالة الدكتوراه: {arbitrator.DoctoralThesisTitle}";


            await _emailService.SendEmailAsync(subject, body);

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
            var arbitrator = await dbContext.Arbitrators.FindAsync(id);

            if (arbitrator == null)
            {
                return NotFound();
            }

            return View(arbitrator);
        }
    }
}

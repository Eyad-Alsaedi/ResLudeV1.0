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
                FirstName = viewModel.FirstName, // First Name
                LastName = viewModel.LastName, // Last Name
                ConsultationType = viewModel.ConsultationType, // نوع الاستشارة
                Nationality = viewModel.Nationality, // الجنسية
                PreferredLanguage = viewModel.PreferredLanguage, // اللغة المفضلة
                Gender = viewModel.Gender, // الجنس
                Entities = viewModel.Entities, // الجهات
                Country = viewModel.Country, // الدولة
                City = viewModel.City, // المدينة
                AcademicDegree = viewModel.AcademicDegree, // الدرجة العلمية
                GeneralSpecialization = viewModel.GeneralSpecialization, // التخصص العام
                SpecificSpecialization1 = viewModel.SpecificSpecialization1, // التخصص الدقيق 1
                SpecificSpecialization2 = viewModel.SpecificSpecialization2, // التخصص الدقيق 2
                MastersThesisTitle = viewModel.MastersThesisTitle, // موضوع رسالة الماجستير
                DoctoralThesisTitle = viewModel.DoctoralThesisTitle, // موضوع رسالة الدكتوراه
                ResidencePlace = viewModel.ResidencePlace, // مكان الإقامة
                WorkPlace = viewModel.WorkPlace, // مكان العمل
                LaborMarketSpecialization = viewModel.LaborMarketSpecialization, // تخصصات سوق العمل
                ScientificAssociation = viewModel.ScientificAssociation, // الجمعية العلمية
                ProfessionalCertificate = viewModel.ProfessionalCertificate, // شهادة مزاولة المهنة
                Qualification = viewModel.Qualification // المؤهل
            };

            await dbContext.Arbitrators.AddAsync(arbitrator);
            await dbContext.SaveChangesAsync();

            string subject = "ResLude - إضافة محكم جديد";
            string body = $"إضافة محكم جديد:\n\n" +
                          $"نوع الاستشارة: {arbitrator.ConsultationType}\n" +
                          $"الاسم الأول: {arbitrator.FirstName}\n" +
                          $"الاسم الأخير: {arbitrator.LastName}\n" +
                          $"الجنسية: {arbitrator.Nationality}\n" +
                          $"اللغة المفضلة: {arbitrator.PreferredLanguage}\n" +
                          $"الجنس: {arbitrator.Gender}\n" +
                          $"الجهات: {arbitrator.Entities}\n" +
                          $"الدولة: {arbitrator.Country}\n" +
                          $"المدينة: {arbitrator.City}\n" +
                          $"الدرجة العلمية: {arbitrator.AcademicDegree}\n" +
                          $"التخصص العام: {arbitrator.GeneralSpecialization}\n" +
                          $"التخصص الدقيق 1: {arbitrator.SpecificSpecialization1}\n" +
                          $"التخصص الدقيق 2: {arbitrator.SpecificSpecialization2}\n" +
                          $"عنوان رسالة الماجستير: {arbitrator.MastersThesisTitle}\n" +
                          $"عنوان رسالة الدكتوراه: {arbitrator.DoctoralThesisTitle}\n" +
                          $"مكان الإقامة: {arbitrator.ResidencePlace}\n" +
                          $"مكان العمل: {arbitrator.WorkPlace}\n" +
                          $"تخصصات سوق العمل: {arbitrator.LaborMarketSpecialization}\n" +
                          $"الجمعية العلمية: {arbitrator.ScientificAssociation}\n" +
                          $"شهادة مزاولة المهنة: {arbitrator.ProfessionalCertificate}\n" +
                          $"المؤهل: {arbitrator.Qualification}";

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
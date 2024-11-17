using ExpertsGulfPortal.Data;
using ExpertsGulfPortal.Models;
using ExpertsGulfPortal.Models.Entities;
using ExpertsGulfPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ExpertsGulfPortal.Controllers
{
    public class RequestArbitratorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly EmailService _emailService;

        // Constructor that initializes the _dbContext and _emailService
        public RequestArbitratorsController(ApplicationDbContext dbContext, EmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        // GET method to render the Create view
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new RequestArbitratorsViewModel
            {
                // Populating dropdowns with data from _dbContext.Arbitrators
                ConsultationTypes = new List<SelectListItem>
                {
                    new SelectListItem { Value = "استشارات اكاديمية", Text = "استشارات اكاديمية" },
                    new SelectListItem { Value = "استشارات اعمال", Text = "استشارات اعمال" }
                },
                Nationalities = await _dbContext.Arbitrators.Select(a => a.Nationality).Distinct()
                    .Select(n => new SelectListItem { Value = n, Text = n }).ToListAsync(),
                Languages = await _dbContext.Arbitrators.Select(a => a.PreferredLanguage).Distinct()
                    .Select(l => new SelectListItem { Value = l, Text = l }).ToListAsync(),
                Genders = await _dbContext.Arbitrators.Select(a => a.Gender).Distinct()
                    .Select(g => new SelectListItem { Value = g, Text = g }).ToListAsync(),
                EntitiesList = await _dbContext.Arbitrators.Select(a => a.Entities).Distinct()
                    .Select(e => new SelectListItem { Value = e, Text = e }).ToListAsync(),
                Countries = await _dbContext.Arbitrators.Select(a => a.Country).Distinct()
                    .Select(c => new SelectListItem { Value = c, Text = c }).ToListAsync(),
                Cities = await _dbContext.Arbitrators.Select(a => a.City).Distinct()
                    .Select(c => new SelectListItem { Value = c, Text = c }).ToListAsync(),
                AcademicDegrees = await _dbContext.Arbitrators.Select(a => a.AcademicDegree).Distinct()
                    .Select(d => new SelectListItem { Value = d, Text = d }).ToListAsync(),
                GeneralSpecializations = await _dbContext.Arbitrators.Select(a => a.GeneralSpecialization).Distinct()
                    .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync(),
                SpecificSpecializations1 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization1).Distinct()
                    .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync(),
                SpecificSpecializations2 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization2).Distinct()
                    .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync(),
                ResidencePlaces = await _dbContext.Arbitrators.Select(a => a.ResidencePlace).Distinct()
                    .Select(r => new SelectListItem { Value = r, Text = r }).ToListAsync(),
                WorkPlaces = await _dbContext.Arbitrators.Select(a => a.WorkPlace).Distinct()
                    .Select(w => new SelectListItem { Value = w, Text = w }).ToListAsync(),
                LaborMarketSpecializations = await _dbContext.Arbitrators.Select(a => a.LaborMarketSpecialization).Distinct()
                    .Select(l => new SelectListItem { Value = l, Text = l }).ToListAsync(),
                ScientificAssociations = await _dbContext.Arbitrators.Select(a => a.ScientificAssociation).Distinct()
                    .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync(),
                ProfessionalCertificates = await _dbContext.Arbitrators.Select(a => a.ProfessionalCertificate).Distinct()
                    .Select(p => new SelectListItem { Value = p, Text = p }).ToListAsync(),
                Qualifications = await _dbContext.Arbitrators.Select(a => a.Qualification).Distinct()
                    .Select(q => new SelectListItem { Value = q, Text = q }).ToListAsync()
            };

            return View("RequestArbitrators", viewModel);  // Explicitly specify the view
        }

        // POST method to handle form submission
        [HttpPost]
        public async Task<IActionResult> Create(RequestArbitratorsViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                // Repopulate dropdown lists in case of invalid form submission
                viewModel.ConsultationTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "استشارات اكاديمية", Text = "استشارات اكاديمية" },
            new SelectListItem { Value = "استشارات اعمال", Text = "استشارات اعمال" }
        };

                // Repopulate string fields
                //await _dbContext.RequestArbitrators.Select(a => a.FirstName).FirstOrDefaultAsync() = viewModel.FirstName;
                //viewModel.LastName = await _dbContext.Arbitrators.Select(a => a.LastName).FirstOrDefaultAsync();
                //viewModel.ConsultationType = await _dbContext.Arbitrators.Select(a => a.ConsultationType).FirstOrDefaultAsync();
                //viewModel.Nationality = await _dbContext.Arbitrators.Select(a => a.Nationality).FirstOrDefaultAsync();
                //viewModel.PreferredLanguage = await _dbContext.Arbitrators.Select(a => a.PreferredLanguage).FirstOrDefaultAsync();
                //viewModel.Gender = await _dbContext.Arbitrators.Select(a => a.Gender).FirstOrDefaultAsync();
                //viewModel.Entities = await _dbContext.Arbitrators.Select(a => a.Entities).FirstOrDefaultAsync();
                //viewModel.Country = await _dbContext.Arbitrators.Select(a => a.Country).FirstOrDefaultAsync();
                //viewModel.City = await _dbContext.Arbitrators.Select(a => a.City).FirstOrDefaultAsync();
                //viewModel.AcademicDegree = await _dbContext.Arbitrators.Select(a => a.AcademicDegree).FirstOrDefaultAsync();
                //viewModel.GeneralSpecialization = await _dbContext.Arbitrators.Select(a => a.GeneralSpecialization).FirstOrDefaultAsync();
                //viewModel.SpecificSpecialization1 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization1).FirstOrDefaultAsync();
                //viewModel.SpecificSpecialization2 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization2).FirstOrDefaultAsync();
                //viewModel.MastersThesisTitle = await _dbContext.Arbitrators.Select(a => a.MastersThesisTitle).FirstOrDefaultAsync();
                //viewModel.DoctoralThesisTitle = await _dbContext.Arbitrators.Select(a => a.DoctoralThesisTitle).FirstOrDefaultAsync();
                //viewModel.ResidencePlace = await _dbContext.Arbitrators.Select(a => a.ResidencePlace).FirstOrDefaultAsync();
                //viewModel.WorkPlace = await _dbContext.Arbitrators.Select(a => a.WorkPlace).FirstOrDefaultAsync();
                //viewModel.LaborMarketSpecialization = await _dbContext.Arbitrators.Select(a => a.LaborMarketSpecialization).FirstOrDefaultAsync();
                //viewModel.ScientificAssociation = await _dbContext.Arbitrators.Select(a => a.ScientificAssociation).FirstOrDefaultAsync();
                //viewModel.ProfessionalCertificate = await _dbContext.Arbitrators.Select(a => a.ProfessionalCertificate).FirstOrDefaultAsync();
                //viewModel.Qualification = await _dbContext.Arbitrators.Select(a => a.Qualification).FirstOrDefaultAsync();

                // Repopulate dropdown lists
                //    viewModel.Nationalities = await _dbContext.Arbitrators.Select(a => a.Nationality).Distinct()
                //        .Select(n => new SelectListItem { Value = n, Text = n }).ToListAsync();
                //    viewModel.Languages = await _dbContext.Arbitrators.Select(a => a.PreferredLanguage).Distinct()
                //        .Select(l => new SelectListItem { Value = l, Text = l }).ToListAsync();
                //    viewModel.Genders = await _dbContext.Arbitrators.Select(a => a.Gender).Distinct()
                //        .Select(g => new SelectListItem { Value = g, Text = g }).ToListAsync();
                //    viewModel.EntitiesList = await _dbContext.Arbitrators.Select(a => a.Entities).Distinct()
                //        .Select(e => new SelectListItem { Value = e, Text = e }).ToListAsync();
                //    viewModel.Countries = await _dbContext.Arbitrators.Select(a => a.Country).Distinct()
                //        .Select(c => new SelectListItem { Value = c, Text = c }).ToListAsync();
                //    viewModel.Cities = await _dbContext.Arbitrators.Select(a => a.City).Distinct()
                //        .Select(c => new SelectListItem { Value = c, Text = c }).ToListAsync();
                //    viewModel.AcademicDegrees = await _dbContext.Arbitrators.Select(a => a.AcademicDegree).Distinct()
                //        .Select(d => new SelectListItem { Value = d, Text = d }).ToListAsync();
                //    viewModel.GeneralSpecializations = await _dbContext.Arbitrators.Select(a => a.GeneralSpecialization).Distinct()
                //        .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync();
                //    viewModel.SpecificSpecializations1 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization1).Distinct()
                //        .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync();
                //    viewModel.SpecificSpecializations2 = await _dbContext.Arbitrators.Select(a => a.SpecificSpecialization2).Distinct()
                //        .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync();
                //    viewModel.ResidencePlaces = await _dbContext.Arbitrators.Select(a => a.ResidencePlace).Distinct()
                //        .Select(r => new SelectListItem { Value = r, Text = r }).ToListAsync();
                //    viewModel.WorkPlaces = await _dbContext.Arbitrators.Select(a => a.WorkPlace).Distinct()
                //        .Select(w => new SelectListItem { Value = w, Text = w }).ToListAsync();
                //    viewModel.LaborMarketSpecializations = await _dbContext.Arbitrators.Select(a => a.LaborMarketSpecialization).Distinct()
                //        .Select(l => new SelectListItem { Value = l, Text = l }).ToListAsync();
                //    viewModel.ScientificAssociations = await _dbContext.Arbitrators.Select(a => a.ScientificAssociation).Distinct()
                //        .Select(s => new SelectListItem { Value = s, Text = s }).ToListAsync();
                //    viewModel.ProfessionalCertificates = await _dbContext.Arbitrators.Select(a => a.ProfessionalCertificate).Distinct()
                //        .Select(p => new SelectListItem { Value = p, Text = p }).ToListAsync();
                //    viewModel.Qualifications = await _dbContext.Arbitrators.Select(a => a.Qualification).Distinct()
                //        .Select(q => new SelectListItem { Value = q, Text = q }).ToListAsync();

                //    return View("RequestArbitrators", viewModel);  // Return to the view with populated data
            }

            // If ModelState is valid, create and save a new RequestArbitrators object
            var requestArbitrator = new RequestArbitrators
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

            // Add the new RequestArbitrator to the database and save changes
            await _dbContext.RequestArbitrators.AddAsync(requestArbitrator);
            await _dbContext.SaveChangesAsync();

            string subject = "ResLude - طلب محكم جديد";
            string body = $"طلب محكم جديد:\n\n" +
                          $"نوع الاستشارة: {requestArbitrator.ConsultationType}\n" +
                          $"الاسم الأول: {requestArbitrator.FirstName}\n" +
                          $"الاسم الأخير: {requestArbitrator.LastName}\n" +
                          $"الجنسية: {requestArbitrator.Nationality}\n" +
                          $"اللغة المفضلة: {requestArbitrator.PreferredLanguage}\n" +
                          $"الجنس: {requestArbitrator.Gender}\n" +
                          $"الجهات: {requestArbitrator.Entities}\n" +
                          $"الدولة: {requestArbitrator.Country}\n" +
                          $"المدينة: {requestArbitrator.City}\n" +
                          $"الدرجة العلمية: {requestArbitrator.AcademicDegree}\n" +
                          $"التخصص العام: {requestArbitrator.GeneralSpecialization}\n" +
                          $"التخصص الدقيق 1: {requestArbitrator.SpecificSpecialization1}\n" +
                          $"التخصص الدقيق 2: {requestArbitrator.SpecificSpecialization2}\n" +
                          $"عنوان رسالة الماجستير: {requestArbitrator.MastersThesisTitle}\n" +
                          $"عنوان رسالة الدكتوراه: {requestArbitrator.DoctoralThesisTitle}\n" +
                          $"مكان الإقامة: {requestArbitrator.ResidencePlace}\n" +
                          $"مكان العمل: {requestArbitrator.WorkPlace}\n" +
                          $"تخصصات سوق العمل: {requestArbitrator.LaborMarketSpecialization}\n" +
                          $"الجمعية العلمية: {requestArbitrator.ScientificAssociation}\n" +
                          $"شهادة مزاولة المهنة: {requestArbitrator.ProfessionalCertificate}\n" +
                          $"المؤهل: {requestArbitrator.Qualification}";

            await _emailService.SendEmailAsync(subject, body);
        
            // Redirect after successful submission
            return RedirectToAction("RequestsList", "RequestArbitrators");
        }
        [HttpGet]
        public async Task<IActionResult> RequestsList()
        {
            var requestArbitrators = await _dbContext.RequestArbitrators.ToListAsync();
            return View(requestArbitrators);
        }
        [HttpGet]
        public async Task<IActionResult> RequestView(Guid id)
        {
            var requestArbitrators = await _dbContext.RequestArbitrators.FindAsync(id);

            if (requestArbitrators == null)
            {
                return NotFound();
            }

            return View(requestArbitrators);
        }

    }
}

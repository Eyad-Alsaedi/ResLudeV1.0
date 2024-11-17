using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ExpertsGulfPortal.Models
{
    public class RequestArbitratorsViewModel
    {
        // Basic Fields
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ConsultationType { get; set; }
        public string? Nationality { get; set; }
        public string? PreferredLanguage { get; set; }
        public string? Gender { get; set; }
        public string? Entities { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? AcademicDegree { get; set; }
        public string? GeneralSpecialization { get; set; }
        public string? SpecificSpecialization1 { get; set; }
        public string? SpecificSpecialization2 { get; set; }
        public string? ResidencePlace { get; set; }
        public string? WorkPlace { get; set; }
        public string? LaborMarketSpecialization { get; set; }
        public string? ScientificAssociation { get; set; }
        public string? ProfessionalCertificate { get; set; }
        public string? Qualification { get; set; }

        // Thesis Titles (as strings)
        public string? MastersThesisTitle { get; set; } // عنوان رسالة الماجستير
        public string? DoctoralThesisTitle { get; set; } // عنوان رسالة الدكتوراه

        // Dropdown options (as SelectListItems)
        public List<SelectListItem>? ConsultationTypes { get; set; }
        public List<SelectListItem>? Nationalities { get; set; }
        public List<SelectListItem>? Languages { get; set; }
        public List<SelectListItem>? Genders { get; set; }
        public List<SelectListItem>? EntitiesList { get; set; }
        public List<SelectListItem>? Countries { get; set; }
        public List<SelectListItem>? Cities { get; set; }
        public List<SelectListItem>? AcademicDegrees { get; set; }
        public List<SelectListItem>? GeneralSpecializations { get; set; }
        public List<SelectListItem>? SpecificSpecializations1 { get; set; }
        public List<SelectListItem>? SpecificSpecializations2 { get; set; }
        public List<SelectListItem>? ResidencePlaces { get; set; }
        public List<SelectListItem>? WorkPlaces { get; set; }
        public List<SelectListItem>? LaborMarketSpecializations { get; set; }
        public List<SelectListItem>? ScientificAssociations { get; set; }
        public List<SelectListItem>? ProfessionalCertificates { get; set; }
        public List<SelectListItem>? Qualifications { get; set; }
    }
}

namespace ExpertsGulfPortal.Models.Entities
{
    public class Arbitrators
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConsultationType { get; set; }
        public string Nationality { get; set; }
        public string PreferredLanguage { get; set; }
        public string Gender { get; set; }
        public string Entities { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AcademicDegree { get; set; }
        public string MastersThesisTitle { get; set; } // موضوع رسالة الماجستير
        public string DoctoralThesisTitle { get; set; } // موضوع رسالة الدكتوراه
        public string GeneralSpecialization { get; set; }
        public string SpecificSpecialization1 { get; set; }
        public string SpecificSpecialization2 { get; set; }
        public string ResidencePlace { get; set; } // محل الإقامة
        public string WorkPlace { get; set; } // مكان العمل
        public string LaborMarketSpecialization { get; set; } // تخصصات سوق العمل
        public string ScientificAssociation { get; set; } // الجمعية العلمية
        public string ProfessionalCertificate { get; set; } // شهادة مزاولة المهنة
        public string Qualification { get; set; } // المؤهل


    }
}
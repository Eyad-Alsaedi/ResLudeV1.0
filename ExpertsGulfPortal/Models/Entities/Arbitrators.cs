namespace ExpertsGulfPortal.Models.Entities
{
    public class Arbitrators
    {
        public Guid Id { get; set; }
        public string Nationality { get; set; } // الجنسية
        public string PreferredLanguage { get; set; } // اللغه المفضلة
        public string Gender { get; set; } // الجنس
        public string Entities { get; set; } // الجهات
        public string Country { get; set; } // الدولة
        public string City { get; set; } // المدينة
        public string AcademicDegree { get; set; } // الدرجة العلمية الحاصل عليها
        public string GeneralSpecialization { get; set; } // التخصص العام
        public string SpecificSpecialization { get; set; } // التخصص الدقيق
        public string MastersThesisTitle { get; set; } // موضوع رسالة الماجستير
        public string DoctoralThesisTitle { get; set; } // موضوع رسالة الدكتوراه

    }
}

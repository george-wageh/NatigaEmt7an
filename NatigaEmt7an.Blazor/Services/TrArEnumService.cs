using NatigaEmt7an.Models.Enums;

namespace NatigaEmt7an.Blazor.Services
{
    public static class TrArEnumService
    {
        public static string GetArabicCategory(StudentCategory? category)
        {
            if (category == null)
                return "الكل";
            return category switch
            {
                StudentCategory.Literary => "أدبي",
                StudentCategory.ScientificMath => "علمي رياضة",
                StudentCategory.ScientificScience => "علمي علوم",
                StudentCategory.Unspecified => "غير محدد",
                _ => "غير معروف"
            };
        }

        public static string GetArabicStatus(StudentStatus? status)
        {
            if (status == null)
                return "الكل";
            return status switch
            {
                StudentStatus.Failed => "راسب",
                StudentStatus.SecondRound => "دور ثاني",
                StudentStatus.Passed => "ناجح",
                _ => "غير معروف"
            };
        }
    }
}

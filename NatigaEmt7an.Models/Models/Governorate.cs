namespace NatigaEmt7an.Models.Models
{
    public class Governorate: EntityBase
    {
        public string Name { get; set; }

        public List<SchoolAdministration> SchoolAdministrations { get; set; }
        public List<Student> Students { get; set; }
        public List<School> Schools { get; set; }

    }
}

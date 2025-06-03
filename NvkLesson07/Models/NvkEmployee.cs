namespace NvkLesson07.Models
{
    public class NvkEmployee
    {
        public string NvkId { get; set; }
        public string NvkName { get; set; }
        public DateTime NvkBirthDay { get; set; }
        public string NvkEmail { get; set; }
        public string NvkPhone { get; set; }
        public decimal NvkSalary { get; set; }
        public bool NvkStatus { get; set; } // True = Active, False = Inactive
    }
}

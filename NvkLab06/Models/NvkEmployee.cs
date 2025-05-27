namespace NvkLab06.Models
{
    public class NvkEmployee
    {
        public static int Count { get; internal set; }
        public string NvkId { get; set; }
        public string NvkName { get; set; }
        public DateTime NvkBirthDay { get; set; }
        public string NvkEmail { get; set; }
        public string NvkPhone { get; set; }
        public decimal NvkSalary { get; set; }
        public bool NvkStatus { get; set; } // True = Active, False = Inactive

        internal static int Max(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
} 

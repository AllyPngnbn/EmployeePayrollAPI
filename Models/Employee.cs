using System.ComponentModel.DataAnnotations;

namespace EmployeePayrollAPI.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public string WorkingDays { get; set; } // "MWF" or "TTHS"

        public static string GenerateEmployeeId(string name, DateTime dob)
        {
            string cleanedName = name.Replace(" ", "").ToUpper();
            string prefix = cleanedName.Length >= 3 ? cleanedName.Substring(0, 3) : cleanedName.PadRight(3, 'X');
            string randomDigits = new Random().Next(1, 99999).ToString("D5");
            string datePart = dob.ToString("ddMMMyyyy").ToUpper();

            return $"{prefix}-{randomDigits}-{datePart}";
        }
    }
}
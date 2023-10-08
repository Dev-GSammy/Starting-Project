

namespace Starting_Project.DTOs
{
    public class ApplicationForm
    {
        public string Id { get; set; }
        public string? image { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? Email { get; set; }
        public string? phoneNumber { get; set; }
        public string? nationality { get; set; }
        public string? currentResidence { get; set; }
        public string? idNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? questionType { get; set; }
        public List<Education>? education { get; set; }
        public List<Experience>? experience { get; set; }
        public string? AddQuestionOne { get; set; }
        public string? AddQuestionTwo { get; set; }
        public string? AddQuestionThree { get; set; }
    }
}
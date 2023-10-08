

namespace StartingProjectDemo.DTOs
{
    public class ProgramsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string programDescription { get; set; }
        public string programType { get; set; }
        public DateTime? programStartDate { get; set; }
        public string? Duration { get; set; }
        public string programLocation { get; set; }
    }
}

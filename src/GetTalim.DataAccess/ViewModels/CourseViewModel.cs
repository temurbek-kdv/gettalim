using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.ViewModels;

public class CourseViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public int Lessons { get; set; }
    public double Hours { get; set; }
    public string Level { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public double Price { get; set; }
    public double DiscountPrice { get; set; }
    public long MentorId { get; set; }
    public long CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Mentor { get; set; } = string.Empty;
    public List<CourseBenefit> Benefits { get; set; } = new List<CourseBenefit>();
    public List<CourseRequirment> Requirments { get; set; } = new List<CourseRequirment> { };

}

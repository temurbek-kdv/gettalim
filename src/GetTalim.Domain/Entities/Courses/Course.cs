using GetTalim.Domain.Enums;

namespace GetTalim.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public int Lessons { get; set; }
    public double Hours { get; set; }
    public CourseLevel Level { get; set; }
    public CourseLanguage Language { get; set; } = CourseLanguage.Uzbek;
    public string ImagePath { get; set; } = string.Empty;
    public double Price { get; set; }
    public double DiscountPrice { get; set; }
    public long MentorId { get; set; }
    public long CategoryId { get; set; }

}

using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.ViewModels;

public class CourseCommentViewModel : CourseComment
{
    public string fullName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}

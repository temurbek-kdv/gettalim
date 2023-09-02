
using GetTalim.DataAccess.Interfaces.CourseBenefits;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Interfaces.Mentors;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Service.Interfaces.CourseViewModels;

namespace GetTalim.Service.Services.CourseViewModels;

public class CourseViewModelService : ICourseViewModelService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICourseBenefitRepository _courseBenefit;
    private readonly ICourseRequiermentRepository _courseRequierment;
    private readonly IMentorRepository _mentorRepository;

    public CourseViewModelService(ICourseBenefitRepository benefit, 
        ICourseRepository course, ICourseRequiermentRepository requirments,
        IMentorRepository mentor
        )
    {
        this._courseBenefit = benefit;
        this._courseRepository = course;
        this._courseRequierment = requirments;
        this._mentorRepository = mentor;
    }
    public async Task<CourseViewModel> GetCourcseBenefitsAsync(long Id)
    {
        var course = await _courseRepository.GetByIdAsync(Id);
        var benefits = await _courseBenefit.GetCourcseBenefitsAsync(Id);
        var requirments = await _courseRequierment.GetCourcseRequirmentsAsync(Id);
        var mentor = await _mentorRepository.GetByIdAsync(Id);

        CourseViewModel model = new();
        model.Id = Id;
        model.Name = course.Name!;
        model.Description = course.Description;
        model.Information = course.Information;
        model.Lessons = course.Lessons;
        model.Hours = course.Hours;
        model.Level = course.Level;
        model.Language = course.Language;
        model.ImagePath = course.ImagePath;
        model.Price = course.Price;
        model.DiscountPrice = course.DiscountPrice;
        model.MentorId = course.MentorId;
        model.Mentor = mentor.FirstName! + " "+mentor.LastName!;
        model.CategoryId = course.CategoryId;
        model.CreatedAt = course.CreatedAt;
        model.UpdatedAt = course.UpdatedAt; 
        model.Benefits.AddRange(benefits);
        model.Requirments.AddRange(requirments);

        return model;
    }
}

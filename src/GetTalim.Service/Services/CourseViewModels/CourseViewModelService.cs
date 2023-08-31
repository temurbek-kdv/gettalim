
using GetTalim.DataAccess.Interfaces.CourseBenefits;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Service.Interfaces.CourseViewModels;

namespace GetTalim.Service.Services.CourseViewModels;

public class CourseViewModelService : ICourseViewModelService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICourseBenefitRepository _courseBenefit;
    private readonly ICourseRequiermentRepository _courseRequierment;
    public CourseViewModelService(ICourseBenefitRepository benefit, 
        ICourseRepository course, ICourseRequiermentRepository requirments
        )
    {
        this._courseBenefit = benefit;
        this._courseRepository = course;
        this._courseRequierment = requirments;
    }
    public async Task<CourseViewModel> GetCourcseBenefitsAsync(long Id)
    {
        var course = await _courseRepository.GetByIdAsync(Id);
        var benefits = await _courseBenefit.GetCourcseBenefitsAsync(Id);
        var requirments = await _courseRequierment.GetCourcseRequirmentsAsync(Id);


        CourseViewModel model = new();
        model.Id = Id;
        model.Name = course.Name;
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
        model.CategoryId = course.CategoryId;
        model.Benefits.AddRange(benefits);
        model.Requirments.AddRange(requirments);

        return model;
    }
}

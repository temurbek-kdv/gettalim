using GetTalim.DataAccess.Interfaces.Categories;
using GetTalim.DataAccess.Interfaces.CourseBenefits;
using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Interfaces.CourseModuls;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Interfaces.Mentors;
using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.DataAccess.Interfaces.Videos;
using GetTalim.DataAccess.Repositories.Categories;
using GetTalim.DataAccess.Repositories.CourseBenefits;
using GetTalim.DataAccess.Repositories.CourseComments;
using GetTalim.DataAccess.Repositories.CourseModuls;
using GetTalim.DataAccess.Repositories.CourseRequierments;
using GetTalim.DataAccess.Repositories.Courses;
using GetTalim.DataAccess.Repositories.Mentors;
using GetTalim.DataAccess.Repositories.Students;
using GetTalim.DataAccess.Repositories.Videos;

namespace GetTalim.Api.Configurations.Layers;

public static class DataAccessConfiguration
{
   public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<ICourseCommentsRepository, CourseCommentsRepository>();
        builder.Services.AddScoped<ICourseRequiermentRepository, CourseRequirmentRepository>();
        builder.Services.AddScoped<ICourseBenefitRepository, CourseBenefitRepository>();
        builder.Services.AddScoped<ICourseModulRepository, CourseModulRepository>();
        builder.Services.AddScoped<IMentorRepository, MentorRepository>();
        builder.Services.AddScoped<IVideoRepository, VideoRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    }
}

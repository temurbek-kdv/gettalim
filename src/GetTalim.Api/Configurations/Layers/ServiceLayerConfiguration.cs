using GetTalim.Service.Interfaces.Categories;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.CourseBenefits;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Interfaces.CourseModuls;
using GetTalim.Service.Interfaces.CourseRequirments;
using GetTalim.Service.Interfaces.Courses;
using GetTalim.Service.Interfaces.Mentors;
using GetTalim.Service.Interfaces.Notifications;
using GetTalim.Service.Interfaces.Students;
using GetTalim.Service.Interfaces.Videos;
using GetTalim.Service.Services.Categories;
using GetTalim.Service.Services.Common;
using GetTalim.Service.Services.CourseBenefits;
using GetTalim.Service.Services.CourseComments;
using GetTalim.Service.Services.CourseModuls;
using GetTalim.Service.Services.CourseRequirments;
using GetTalim.Service.Services.Courses;
using GetTalim.Service.Services.Mentors;
using GetTalim.Service.Services.Notifications;
using GetTalim.Service.Services.Students;
using GetTalim.Service.Services.Videos;

namespace GetTalim.Api.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<ICourseCommentService, CourseCommentService>();
        builder.Services.AddScoped<ICourseRequirmentService, CourseRequirmentService>();
        builder.Services.AddScoped<ICourseBenefitService, CourseBenefitService>();
        builder.Services.AddScoped<ICourseModulService, CourseModulService>();
        builder.Services.AddScoped<IMentorService, MentorService>();
        builder.Services.AddScoped<IVideoService, VideoService>();
        builder.Services.AddScoped<IAuthStudentService, AuthStudentService>();
        builder.Services.AddScoped<ITokenStudentService, TokenStudentService>();
        builder.Services.AddSingleton<IMailSender, MailSender>();

    }
}

using GetTalim.DataAccess.Interfaces.Categories;
using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Repositories.Categories;
using GetTalim.DataAccess.Repositories.CourseComments;
using GetTalim.DataAccess.Repositories.CourseRequierments;
using GetTalim.DataAccess.Repositories.Courses;
using GetTalim.Service.Interfaces.Categories;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Interfaces.CourseRequirments;
using GetTalim.Service.Interfaces.Courses;
using GetTalim.Service.Services.Categories;
using GetTalim.Service.Services.Common;
using GetTalim.Service.Services.CourseComments;
using GetTalim.Service.Services.CourseRequirments;
using GetTalim.Service.Services.Courses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//-> DI container, IoC containers
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseCommentsRepository, CourseCommentsRepository>();
builder.Services.AddScoped<ICourseRequiermentRepository, CourseRequirmentRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseCommentService, CourseCommentService>();
builder.Services.AddScoped<ICourseRequirmentService, CourseRequirmentService>();
//->

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

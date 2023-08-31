using GetTalim.Api.Configurations;
using GetTalim.Api.Configurations.Layers;
using GetTalim.Api.Middlewares;
using GetTalim.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfiguraWeb();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();

builder.Services.AddCors(options =>
options.AddPolicy("MyPolicy", config =>
{
    config.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
}));

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

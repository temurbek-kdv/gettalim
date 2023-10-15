using GetTalim.Api.Configurations;

namespace GetTalim.Api.Configurations.Layers;

public static class WebConfiguration
{
    public static void ConfiguraWeb(this WebApplicationBuilder builder)
    {
        builder.ConfigureJwtAuth();
        builder.Services.AddAutoMapper(typeof(Program));
        builder.ConfigureSwaggerAuth();
    }
}
﻿namespace GetTalim.Api.Configurations;


public static class CorsPolicyConfiguration
{
    public static void ConfigureCORSPolicy(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });


            //option.AddPolicy("OnlySite", builder =>
            //{
               // builder.WithOrigins("https://www.gettalim.uz")
                   // .AllowAnyMethod().AllowAnyHeader();
            //});
        });
    }
}

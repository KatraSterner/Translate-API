using Scalar.AspNetCore;
using Translator.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TranslateService>(); // added ----------------------------------------
builder.Services.AddControllers(); // added -----------------------------------------------------

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // added -------------------------------------------------------
}

app.UseHttpsRedirection();

app.UseAuthorization(); // added ----------------------------------------------------------------
app.MapControllers(); // added ------------------------------------------------------------------
app.UseCors(policy => policy // added -----------------------------------------------------------
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.Run();

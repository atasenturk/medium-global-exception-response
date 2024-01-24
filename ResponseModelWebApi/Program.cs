using FluentValidation;
using FluentValidation.AspNetCore;
using ResponseModelWebApi.Extensions;
using ResponseModelWebApi.Middlewares;
using ResponseModelWebApi.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddContextRegistration(builder.Configuration);

builder.Services.AddRepositoriesRegistration();

builder.Services.ConfigureAuth(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

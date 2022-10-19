using Exam_Api.Models;
using Microsoft.EntityFrameworkCore;
using Exam_Api.Controllers;
using Exam_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExamContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConn")));

builder.Services.AddTransient<IExamServices<ExamTitle>, ExamServices>();

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

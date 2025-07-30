// See https://aka.ms/new-console-template for more information
using Company.Entities;

Console.WriteLine("Hello, World!");


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CompanyDbContext>();

var app = builder.Build();
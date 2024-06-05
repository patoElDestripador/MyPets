
using Microsoft.EntityFrameworkCore;
using MyPets.Data;
using MyPets.Repository.Owners;
using MyPets.Repository.Pets;
using MyPets.Repository.Quotes;
using MyPets.Repository.Vets;
using MyPets.Services.ExternalApis;
using MyPets.Services.Owners;
using MyPets.Services.Pets;
using MyPets.Services.Quotes;
using MyPets.Services.Vets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MyPetsDbContext>(op => op.UseMySql(builder.Configuration.GetConnectionString("MyPetsDB"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));
builder.Services.AddCors(op => op.AddPolicy("AllowAnyOrigin", builder => { builder.AllowAnyOrigin(); builder.AllowAnyMethod(); builder.AllowAnyHeader(); }));

builder.Services.AddScoped<IOwnersRepository, OwnersRepository>();
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IQuotesRepository, QuotesRepository>();
builder.Services.AddScoped<IVetsRepository, VetsRepository>();

builder.Services.AddScoped<IOwnersService, OwnersService>();
builder.Services.AddScoped<IPetsService, PetsService>();
builder.Services.AddScoped<IQuotesService, QuotesService>();
builder.Services.AddScoped<IVetsService, VetsService>();
builder.Services.AddScoped<IMailSenderApiService, MailSenderApiService>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
app.MapControllers();
app.Run();


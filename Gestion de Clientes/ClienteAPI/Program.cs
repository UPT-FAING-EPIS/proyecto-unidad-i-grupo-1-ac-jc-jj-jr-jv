using AutoMapper;
using ClienteAPI;
using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BdClientesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));


builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<Program>();

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// **************************MAPPER
var mapperConfig = new MapperConfiguration(m => 
{
    m.AddProfile(new MappingProfile());
});


IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();
// use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
/* var mapper = configuration.CreateMapper(); */
// **********************FIN MAPPER   

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment() )
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

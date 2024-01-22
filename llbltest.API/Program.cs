using AutoMapper;
using llbltest;
using llbltest.API.AutoMapperProfiles;
using llbltest.Repositories;
using llbltest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LlbltestDataContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("TestDBConnection")));

// Auto Mapper Configurations
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new DealerAutoMapperProfile());
//});

//IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//Repo
builder.Services.AddScoped<IDealerRepository, DealerRepository>();

//Service
builder.Services.AddScoped<IDealerService, DealerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
